import React, { useState, useEffect } from "react";
import { Typography, Button, Divider } from "@material-ui/core";
import {
  Elements,
  CardElement,
  ElementsConsumer,
} from "@stripe/react-stripe-js";
import { loadStripe } from "@stripe/stripe-js";
import axios from "axios";
import useStyles from "./styles";
import { toast } from "react-toastify";

import Review from "./Review";

const stripePromise = loadStripe(process.env.REACT_APP_STRIPE_PRIVATE_KEY);

const PaymentForm = ({
  productsAddedToCart,
  shippingData,
  backStep,
  nextStep,
  removeAllFromCart,
}) => {
  const [totalPrice, setTotalPrice] = useState(0);
  const [totalItems, setTotalItems] = useState(0);
  useEffect(() => {
    let items = 0;
    let price = 0;
    productsAddedToCart.forEach((item) => {
      items += item.qty;
      price += item.qty * item.price;
    });
    price = Math.round((price + Number.EPSILON) * 100) / 100;
    setTotalPrice(price);
    setTotalItems(items);
  }, [
    productsAddedToCart,
    totalPrice,
    totalItems,
    setTotalItems,
    setTotalPrice,
  ]);
  const handleSubmit = async (event, elements, stripe) => {
    event.preventDefault();
    if (!stripe || !elements) return;

    const cardElement = elements.getElement(CardElement);

    const { error, paymentMethod } = await stripe.createPaymentMethod({
      type: "card",
      card: cardElement,
    });

    if (error) {
      console.log(error);
    } else {
      const orderId = await axios.post(
        process.env.REACT_APP_API_URL + "Order",
        {
          userEmail: shippingData.email,
          userFirstName: shippingData.firstName,
          userLastName: shippingData.lastName,
          userCity: shippingData.city,
          userCounty: shippingData.county,
          userAddress: shippingData.address,
          totalPrice: totalPrice,
        }
      );

      for (const p of productsAddedToCart) {
        const item = await axios
          .patch(
            process.env.REACT_APP_API_URL +
              `Order/${orderId.data.orderId}/orderItems`,
            {
              componentId: p.componentId,
              componentMake: p.make,
              componentModel: p.model,
              componentImage: p.image,
              componentType: p.componentType,
              componentPrice: p.price,
              orderItemQuantity: p.qty,
              orderId: orderId.data.orderId,
            }
          )
          .catch((e) => console.log(e));
      }

      const email = await axios
        .post(
          process.env.REACT_APP_API_URL +
            `Email/compose/${orderId.data.orderId}`
        )
        .catch((e) => console.log(e));

      if (email.data.messageId) {
        toast.success(
          `An order confirmation email has been sent to ${shippingData.email}.`,
          {
            position: toast.POSITION.TOP_CENTER,
            autoClose: 3000,
          }
        );
      }

      removeAllFromCart();
      nextStep();
    }
  };
  const classes = useStyles();
  return (
    <>
      <Review
        productsAddedToCart={productsAddedToCart}
        totalItems={totalItems}
        totalPrice={totalPrice}
      />
      <Divider />
      <Typography variant="h6" gutterBottom style={{ margin: "20px 0" }}>
        Payment Method
      </Typography>
      <Elements stripe={stripePromise}>
        <ElementsConsumer>
          {({ elements, stripe }) => (
            <form onSubmit={(e) => handleSubmit(e, elements, stripe)}>
              <CardElement />
              <br /> <br />
              <div style={{ display: "flex", justifyContent: "space-between" }}>
                <Button variant="outlined" onClick={backStep}>
                  Back
                </Button>
                <Button
                  type="submit"
                  variant="contained"
                  disabled={!stripe}
                  className={classes.nextButton}
                >
                  Pay {totalPrice} $
                </Button>
              </div>
            </form>
          )}
        </ElementsConsumer>
      </Elements>
    </>
  );
};

export default PaymentForm;
