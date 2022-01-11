import React, { useState } from "react";
import { DataGrid } from "@mui/x-data-grid";
import { Typography, Button } from "@material-ui/core";
import axios from "axios";

const columns = [
  { field: "id", headerName: "Order ID", width: 100 },
  { field: "userEmail", headerName: "Email", width: 240 },
  { field: "userFirstName", headerName: "First Name", width: 130 },
  { field: "userLastName", headerName: "Last Name", width: 130 },
  { field: "userCounty", headerName: "County", width: 130 },
  { field: "userCity", headerName: "City", width: 130 },
  { field: "userAddress", headerName: "Address", width: 130 },
  {
    field: "totalPrice",
    headerName: "Total Price",
    type: "number",
    width: 130,
  },
  { field: "shippingStatus", headerName: "Shipment Status", width: 150 },
];

const GetAllOrdersForm = () => {
  const [orders, setOrders] = useState([]);
  const fetchOrders = async () => {
    const prod = await axios
      .get(process.env.REACT_APP_API_URL + "Order")
      .catch((e) => console.log(e));
    if (prod) {
      const items = [];
      for (const iterator of prod.data) {
        const item = {
          id: iterator.orderId,
          userEmail: iterator.userEmail,
          userFirstName: iterator.userFirstName,
          userLastName: iterator.userLastName,
          userCounty: iterator.userCounty,
          userCity: iterator.userCity,
          userAddress: iterator.userAddress,
          totalPrice: iterator.totalPrice,
          shippingStatus: iterator.shippingStatus
            ? "Shipped"
            : "Not yet shipped",
        };
        items.push(item);
      }
      setOrders(items);
    }
  };
  return (
    <>
      <div
        style={{
          height: 400,
          width: "100%",
          marginTop: 25,
          marginBottom: 25,
        }}
      >
        <Typography variant="h5">Orders list: </Typography>
        <DataGrid
          rows={orders}
          columns={columns}
          pageSize={5}
          rowsPerPageOptions={[5]}
        />
      </div>
      <br />
      <div style={{ display: "flex", justifyContent: "center" }}>
        <Button
          variant="contained"
          color="primary"
          onClick={(e) => fetchOrders()}
        >
          Submit
        </Button>
      </div>
    </>
  );
};

export default GetAllOrdersForm;
