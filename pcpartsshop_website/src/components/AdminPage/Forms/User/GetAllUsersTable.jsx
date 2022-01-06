import React, { useState } from "react";
import { DataGrid } from "@mui/x-data-grid";
import { Typography, Button } from "@material-ui/core";
import axios from "axios";

const columns = [
  { field: "id", headerName: "UserID", width: 300 },
  { field: "email", headerName: "Email", width: 200 },
  { field: "firstName", headerName: "First Name", width: 130 },
  { field: "lastName", headerName: "Last Name", width: 130 },
  { field: "county", headerName: "County", width: 130 },
  { field: "city", headerName: "City", width: 130 },
  { field: "address", headerName: "Address", width: 130 },
  { field: "admin", headerName: "Admin", width: 70 },
];

const GetAllUsersTable = () => {
  const [users, setUsers] = useState([]);
  const fetchProducts = async () => {
    const prod = await axios
      .get(process.env.REACT_APP_API_URL + "User")
      .catch((e) => console.log(e));
    const items = [];
    for (const iterator of prod.data) {
      const item = {
        id: iterator.userId,
        email: iterator.email,
        firstName: iterator.firstName,
        lastName: iterator.lastName,
        county: iterator.county,
        city: iterator.city,
        address: iterator.address,
        admin: iterator.admin ? "Yes" : "No",
      };
      items.push(item);
    }
    setUsers(items);
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
          rows={users}
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

export default GetAllUsersTable;
