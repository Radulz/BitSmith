import React, { useState, useEffect } from "react";
import {
  AppBar,
  Toolbar,
  IconButton,
  Badge,
  Typography,
  Button,
} from "@material-ui/core";
import { ShoppingCart } from "@material-ui/icons";
import { Link, useLocation } from "react-router-dom";
import logo from "../../images/LoginLogo.png";
import useStyles from "./styles";
import { connect } from "react-redux";
import { logOut } from "../../redux/User/user-actions";

const NavBar = ({ productsAddedToCart, isLoggedIn, logOut, email }) => {
  const [cartCount, setCartCount] = useState(0);
  useEffect(() => {
    let count = 0;
    productsAddedToCart.forEach((x) => {
      count += x.qty;
    });
    setCartCount(count);
  }, [productsAddedToCart, cartCount]);
  const classes = useStyles();
  const location = useLocation();
  return (
    <AppBar position="fixed" className={classes.appBar} color="inherit">
      <Toolbar>
        <Typography
          component={Link}
          to="/"
          variant="h6"
          className={classes.title}
          color="inherit"
        >
          <img
            src={logo}
            alt="PCPartsShop"
            height="25px"
            className={classes.image}
          />
          PCPartsShop
        </Typography>
        <div className={classes.grow} />
        {location.pathname === "/" && (
          <div className={classes.button}>
            <IconButton
              component={Link}
              to="/cart"
              aria-label="Show cart items"
              color="inherit"
            >
              <Badge badgeContent={cartCount} color="secondary">
                <ShoppingCart />
              </Badge>
            </IconButton>
            {!isLoggedIn ? (
              <Button
                component={Link}
                to="/login"
                variant="outlined"
                style={{ marginLeft: "20px" }}
              >
                Login
              </Button>
            ) : (
              <Button
                variant="outlined"
                style={{ marginLeft: "20px" }}
                onClick={() => logOut(email)}
              >
                Logout
              </Button>
            )}
          </div>
        )}
      </Toolbar>
    </AppBar>
  );
};

const mapStateToProps = (state) => {
  return {
    productsAddedToCart: state.shopReducer.productsAddedToCart,
    isLoggedIn: state.userReducer.isLoggedIn,
    email: state.userReducer.email,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    logOut: (email) => {
      dispatch(logOut(email));
    },
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(NavBar);
