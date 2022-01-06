import React, { useState } from "react";
import { DataGrid } from "@mui/x-data-grid";
import { Typography, Button } from "@material-ui/core";
import axios from "axios";

const columns = [
  { field: "id", headerName: "ComponentID", width: 300 },
  { field: "make", headerName: "Make", width: 130 },
  { field: "model", headerName: "Model", width: 130 },
  {
    field: "price",
    headerName: "Price",
    type: "number",
    width: 90,
  },
];

const GetAllCPUsTable = () => {
  const [components, setComponents] = useState([]);
  const fetchProducts = async () => {
    const prod = await axios
      .get(process.env.REACT_APP_API_URL + "CPU")
      .catch((e) => console.log(e));
    const items = [];
    for (const iterator of prod.data) {
      const item = {
        id: iterator.componentId,
        make: iterator.make,
        model: iterator.model,
        price: iterator.price,
      };
      items.push(item);
    }
    setComponents(items);
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
        <Typography variant="h5">Item list: </Typography>
        <DataGrid
          rows={components}
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
          onClick={(e) => fetchProducts()}
        >
          Submit
        </Button>
      </div>
    </>
  );
};

export default GetAllCPUsTable;
