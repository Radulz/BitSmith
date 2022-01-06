import * as React from "react";
import { DataGrid } from "@mui/x-data-grid";
import { Typography } from "@material-ui/core";

const columns = [
  { field: "id", headerName: "ID", width: 70 },
  { field: "componentId", headerName: "ComponentID", width: 300 },
  { field: "make", headerName: "Make", width: 130 },
  { field: "model", headerName: "Model", width: 130 },
  {
    field: "price",
    headerName: "Price",
    type: "number",
    width: 90,
  },
  { field: "quantity", headerName: "Quantity", width: 100 },
];

const OrderItemsTable = ({ rows }) => {
  return (
    <div
      style={{ height: 400, width: "100%", marginTop: 25, marginBottom: 25 }}
    >
      <Typography variant="h5">Item list: </Typography>
      <DataGrid
        rows={rows}
        columns={columns}
        pageSize={5}
        rowsPerPageOptions={[5]}
      />
    </div>
  );
};

export default OrderItemsTable;
