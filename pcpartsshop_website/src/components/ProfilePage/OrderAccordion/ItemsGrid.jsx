import * as React from "react";
import { DataGrid } from "@mui/x-data-grid";
import { Paper } from "@mui/material";

const columns = [
  { field: "id", headerName: "Item", width: 90 },
  {
    field: "make",
    headerName: "Make",
    width: 150,
  },
  {
    field: "model",
    headerName: "Model",
    width: 150,
    editable: true,
  },
  {
    field: "price",
    headerName: "Price",
    type: "number",
    width: 110,
  },
  {
    field: "quantity",
    headerName: "Quantity",
    type: "number",
    width: 90,
  },
];

const ItemsGrid = ({ rows }) => {
  return (
    <div>
      <Paper
        elevation={4}
        style={{ height: 400, width: "100%", marginBottom: 25 }}
      >
        <DataGrid
          rows={rows}
          columns={columns}
          pageSize={5}
          rowsPerPageOptions={[5]}
        />
      </Paper>
    </div>
  );
};

export default ItemsGrid;
