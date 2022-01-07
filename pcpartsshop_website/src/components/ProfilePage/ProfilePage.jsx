import React, { useState, useEffect } from "react";
import { Typography, Grid } from "@material-ui/core";
import OrderAccordion from "./OrderAccordion/OrderAccordion";
import useStyles from "./styles";
import { connect } from "react-redux";
import ProfileMenu from "./ProfileMenu";
import axios from "axios";
import { Navigate } from "react-router-dom";

const ProfilePage = ({
  email,
  firstName,
  lastName,
  county,
  city,
  address,
  isLoggedIn,
  admin,
}) => {
  const classes = useStyles();
  const [orders, setOrders] = useState([]);
  const [screenWidth, getScreenWidth] = useState(window.innerWidth);
  const setWidth = () => {
    getScreenWidth(window.innerWidth);
  };
  useEffect(() => {
    window.addEventListener("resize", setWidth);
    return () => {
      window.removeEventListener("resize", setWidth);
    };
  }, [screenWidth]);
  const fetchOrders = async (email) => {
    const response = await axios
      .get(process.env.REACT_APP_API_URL + `Order/orders/byEmail/${email}`)
      .catch((e) => console.log(e));
    console.log(response);
    if (response) {
      let orderDetails = [];
      for (const i of response.data) {
        let items = [];
        let num = 1;
        for (const iterator of i.items) {
          const item = {
            id: num,
            make: iterator.componentMake,
            model: iterator.componentModel,
            price: iterator.componentPrice,
            quantity: iterator.orderItemQuantity,
          };
          items.push(item);
          num++;
        }
        const order = {
          orderId: i.orderId,
          email: i.userEmail,
          firstName: i.userFirstName,
          lastName: i.userLastName,
          county: i.userCounty,
          city: i.userCity,
          address: i.userAddress,
          totalPrice: i.totalPrice,
          status: i.shippingStatus ? "Shipped" : "Not yet shipped",
          items: items,
        };
        orderDetails.push(order);
      }
      console.log(orderDetails);
      setOrders(orderDetails);
    }
  };
  useEffect(() => {
    fetchOrders(email);
    return () => {};
  }, [email]);
  if (!isLoggedIn || admin) {
    return <Navigate to="/" />;
  }
  return (
    <main className={classes.content}>
      <div className={classes.toolbar} />
      <Grid container>
        {/* <Grid item lg={2} md={3} sm={4} xs={5}>
          <div className={classes.dashboardMenu}>
            <ProfileMenu selected={selected} setSelected={setSelected} />
          </div>
        </Grid> */}
        <Grid item lg={12} md={12} sm={12} xs={12}>
          <div className={classes.smallContainer}>
            <Typography variant="h5">Order History</Typography>
            <OrderAccordion
              email={email}
              size={0.65 * screenWidth}
              data={orders}
            />
          </div>
        </Grid>
      </Grid>
    </main>
  );
};

const mapStateToProps = (state) => {
  return {
    email: state.userReducer.email,
    firstName: state.userReducer.firstName,
    lastName: state.userReducer.lastName,
    county: state.userReducer.county,
    city: state.userReducer.city,
    address: state.userReducer.address,
    isLoggedIn: state.userReducer.isLoggedIn,
    admin: state.userReducer.admin,
  };
};

export default connect(mapStateToProps)(ProfilePage);
