import React, { useState } from "react";
import {
  Paper,
  Stepper,
  Step,
  StepLabel,
  Typography,
  CircularProgress,
  Divider,
  Button,
} from "@material-ui/core";
import useStyles from "./styles";
import AddressForm from "../AddressForm";
import PaymentForm from "../PaymentForm";
import { connect } from "react-redux";
import { removeAllFromCart } from "../../../redux/Shopping/shopping-actions";
import { Link } from "react-router-dom";

const steps = ["Shipping address", "Payment Details"];

const Checkout = ({ productsAddedToCart, removeAllFromCart }) => {
  const [activeStep, setActiveStep] = useState(0);
  const [shippingData, setShippingData] = useState({});
  const classes = useStyles();

  const nextStep = () => setActiveStep((prevActiveStep) => prevActiveStep + 1);
  const backStep = () => setActiveStep((prevActiveStep) => prevActiveStep - 1);

  const next = (data) => {
    setShippingData(data);
    nextStep();
  };
  const Confirmation = () =>
    !productsAddedToCart.length ? (
      <>
        <div>
          <Typography variant="h5">
            Thank you for your purchase!
            <Divider className={classes.divider} />
          </Typography>
        </div>
        <br />
        <Button component={Link} to="/" variant="outlined" type="button">
          Back To Home
        </Button>
      </>
    ) : (
      <div className={classes.spinner}>
        <CircularProgress />
      </div>
    );
  const Form = () =>
    activeStep === 0 ? (
      <AddressForm next={next} />
    ) : (
      <PaymentForm
        shippingData={shippingData}
        productsAddedToCart={productsAddedToCart}
        removeAllFromCart={removeAllFromCart}
        backStep={backStep}
        nextStep={nextStep}
      />
    );
  return (
    <>
      <div className={classes.toolbar} />
      <main className={classes.layout}>
        <Paper className={classes.paper}>
          <Typography variant="h4" align="center">
            Checkout
          </Typography>
          <Stepper activeStep={activeStep} className={classes.stepper}>
            {steps.map((step) => (
              <Step key={step}>
                <StepLabel>{step}</StepLabel>
              </Step>
            ))}
          </Stepper>
          {activeStep === steps.length ? <Confirmation /> : <Form />}
        </Paper>
      </main>
    </>
  );
};

const mapStateToProps = (state) => {
  return {
    productsAddedToCart: state.shopReducer.productsAddedToCart,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    removeAllFromCart: () => dispatch(removeAllFromCart()),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(Checkout);
