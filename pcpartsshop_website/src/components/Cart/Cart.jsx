import React, { useState, useEffect } from "react";
import { alpha, styled } from "@mui/material/styles";
import { connect } from "react-redux";
import { removeAllFromCart } from "../../redux/Shopping/shopping-actions";
import {
  Typography,
  Button,
  Grid,
  Box,
  Paper,
  Switch,
  Divider,
  CircularProgress,
} from "@material-ui/core";
import useStyles from "./styles";
import CartItem from "./CartItem/CartItem";
import { Link } from "react-router-dom";
import axios from "axios";
import CompatibilityCard from "./CompatibilityCard/CompatibilityCard";

const Cart = ({
  productsAddedToCart,
  isLoadingProducts,
  removeAllFromCart,
}) => {
  const isEmpty = !productsAddedToCart.length;
  const classes = useStyles();
  const [totalPrice, setTotalPrice] = useState(0);
  const [totalItems, setTotalItems] = useState(0);
  const [compatibility, setCompatibility] = useState(false);
  const [compatibilityMessages, setCompatibilityMessages] = useState([]);
  const [isPsu, setIsPsu] = useState(false);

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

  useEffect(() => {
    setIsPsu(false);
    productsAddedToCart.forEach((item) => {
      if (item.componentType === "PSU") {
        setIsPsu(true);
      }
    });
  }, [isPsu, productsAddedToCart]);

  useEffect(() => {
    const getCompatibilityMessages = async () => {
      const res = await axios.post(
        process.env.REACT_APP_API_URL + `Compatibility/parts`,
        {
          parts: productsAddedToCart,
        }
      );
      setCompatibilityMessages(res.data);
    };
    if (compatibility) {
      getCompatibilityMessages();
    } else {
      setCompatibilityMessages([]);
    }
  }, [compatibility, productsAddedToCart]);

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
    <div className={classes.filledCartContainer}>
      <Grid container spacing={2} columns={10}>
        {productsAddedToCart &&
          productsAddedToCart.map((item) => (
            <Grid
              item
              xs={12}
              sm={12}
              md={6}
              lg={4}
              xl={4}
              key={item.componentId}
            >
              <CartItem product={item} key={item.componentId} />
            </Grid>
          ))}
      </Grid>
    </div>
  );

  const ColorSwitch = styled(Switch)(({ theme }) => ({
    "& .MuiSwitch-switchBase.Mui-checked": {
      color: "#046380",
      "&:hover": {
        backgroundColor: alpha("#1b2271", theme.palette.action.hoverOpacity),
      },
    },
    "& .MuiSwitch-switchBase.Mui-checked + .MuiSwitch-track": {
      backgroundColor: "#046380",
    },
  }));

  const ColorCircularProgress = styled(CircularProgress)(({ theme }) => ({
    color: "#046380",
  }));

  return (
    <div>
      <div className={classes.toolbar} />
      <Grid container spacing={3}>
        <Grid item xs={12} className={classes.cartHeader}>
          <Grid container>
            <Grid item xs={12} sm={12} md={12} lg={6}>
              <Typography className={classes.title} variant="h3" gutterBottom>
                Your Shopping Cart
              </Typography>
            </Grid>
            {!isEmpty && (
              <Grid
                item
                xs={12}
                sm={12}
                md={12}
                lg={6}
                style={{ display: "flex", padding: "10px" }}
              >
                <Grid container spacing={2} alignItems="center">
                  <Grid item xs={12} sm={12} md={4} lg={6}>
                    <Typography variant="h5">
                      Total ({totalItems} items): {totalPrice.toFixed(2)} $
                    </Typography>
                  </Grid>

                  <Grid
                    item
                    xs={6}
                    sm={6}
                    md={4}
                    lg={3}
                    className={classes.buttonsHeader}
                  >
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
                  </Grid>
                </Grid>
              </Grid>
            )}
          </Grid>
        </Grid>
        <Grid item xs={12} className={classes.cartContainer}>
          <Grid container spacing={2}>
            <Grid item xs={12} sm={12} md={12} lg={9}>
              {isEmpty ? <EmptyCart /> : <FilledCart />}
            </Grid>
            <Grid item xs={12} sm={12} md={12} lg={3}>
              {!isEmpty && (
                <Paper className={classes.compatibilitySection}>
                  <Grid container>
                    <Grid item xs={12} className={classes.compatibilityTitle}>
                      <Typography variant="h5">
                        Are you building a PC?
                      </Typography>
                    </Grid>
                    <Grid item xs={12} className={classes.compatibilityHeader}>
                      <div className={classes.compatibilityLabelContainer}>
                        <Typography variant="body1">
                          Check the parts compatibility.
                        </Typography>
                      </div>
                      <ColorSwitch
                        checked={compatibility}
                        onChange={() => {
                          setCompatibility(!compatibility);
                        }}
                        inputProps={{ "aria-label": "controlled" }}
                      />
                    </Grid>
                    <Grid item xs={12} className={classes.compatibilityBody}>
                      {compatibility &&
                        (compatibilityMessages.length === 0 ? (
                          <>
                            <ColorCircularProgress variant="indeterminate" />
                            <br />
                            <Typography>
                              Checking cart's compatibility
                            </Typography>
                          </>
                        ) : (
                          <>
                            <div className={classes.cardContainer}>
                              {compatibilityMessages.map((item, index) => (
                                <CompatibilityCard key={index} item={item} />
                              ))}
                            </div>
                            {isPsu && (
                              <div>
                                <Divider style={{ marginTop: "20px" }} />
                                <Typography>
                                  Please note that the power consumption is
                                  calculated using the 'worst case scenario'
                                  (maximum power consumption).
                                </Typography>
                              </div>
                            )}
                          </>
                        ))}
                    </Grid>
                  </Grid>
                </Paper>
              )}
            </Grid>
          </Grid>
        </Grid>
      </Grid>
    </div>
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
