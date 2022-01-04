import React, { useState, useEffect } from "react";

import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { removeAllFromCart } from "../../redux/Shopping/shopping-actions";

import { Container, Typography, Button, Grid } from "@material-ui/core";
import useStyles from "./styles";
import CartItem from "./CartItem/CartItem";
import { Link } from "react-router-dom";

const Cart = ({
  productsAddedToCart,
  isLoadingProducts,
  removeAllFromCart,
}) => {
  const isEmpty = !productsAddedToCart.length;
  const classes = useStyles();
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
  if (isLoadingProducts)
    return (
      <Grid align="center">
        <Typography>Loading parts...</Typography>
      </Grid>
    );

  const EmptyCart = () => (
    <Typography variant="subtitle1"> Your cart is empty!</Typography>
  );

  const FilledCart = () => (
    <>
      <Grid container spacing={3}>
        {productsAddedToCart &&
          productsAddedToCart.map((item) => (
            <Grid item xs={12} sm={4} key={item.componentId}>
              <CartItem product={item} key={item.componentId} />
            </Grid>
          ))}
        <div className={classes.cardDetails}>
          {totalItems ? (
            <Typography variant="h4">
              Total ({totalItems} items): {totalPrice.toFixed(2)} $
            </Typography>
          ) : (
            <Typography variant="h4">Total: 0 $</Typography>
          )}
          <div>
            <Button
              className={classes.emptyButton}
              size="large"
              type="button"
              variant="contained"
              color="secondary"
              onClick={() => removeAllFromCart()}
            >
              Empty Cart
            </Button>
            <Button
              component={Link}
              to="/checkout"
              className={classes.checkoutButton}
              size="large"
              type="button"
              variant="contained"
              color="primary"
            >
              Checkout
            </Button>
          </div>
        </div>
      </Grid>
    </>
  );

  return (
    <Container>
      <div className={classes.toolbar} />
      <Typography className={classes.title} variant="h3" gutterBottom>
        Your Shopping Cart{" "}
      </Typography>
      {isEmpty ? <EmptyCart /> : <FilledCart />}
    </Container>
  );
};

const mapStateToProps = (state) => {
  return {
    productsAddedToCart: state.shopReducer.productsAddedToCart,
    isLoadingProducts: state.shopReducer.isLoadingProducts,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    removeAllFromCart: () => dispatch(removeAllFromCart()),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(Cart);
