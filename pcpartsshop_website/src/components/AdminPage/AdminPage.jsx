import React, { useState } from "react";
import { Typography, Grid, Paper, Divider } from "@material-ui/core";
import ListSubheader from "@mui/material/ListSubheader";
import List from "@mui/material/List";
import useStyles from "./styles";
import ListCommand from "./ListCommand";
import FormSelector from "./FormSelector";
import LoginLogo from "../../images/BitSmithLogo.png";
import { connect } from "react-redux";
import { Navigate } from "react-router-dom";

const AdminPage = ({ admin, isLoggedIn }) => {
  const [formSelect, setFormSelect] = useState("");
  const classes = useStyles();
  if (!admin || !isLoggedIn) {
    return <Navigate to="/" />;
  }
  return (
    <main className={classes.content}>
      <div className={classes.toolbar} />
      <Grid container spacing={1}>
        <Grid item lg={2} md={3} sm={4} xs={6}>
          <div className={classes.dashboardMenu}>
            <List
              sx={{ width: "100%", maxWidth: 360, bgcolor: "background.paper" }}
              component="nav"
              aria-labelledby="nested-list-subheader"
              subheader={
                <ListSubheader component="div" id="nested-list-subheader">
                  Components controls
                </ListSubheader>
              }
            >
              <ListCommand listText="CPU" setFormSelect={setFormSelect} />
              <ListCommand listText="GPU" setFormSelect={setFormSelect} />
              <ListCommand
                listText="Motherboard"
                setFormSelect={setFormSelect}
              />
              <ListCommand
                listText="Power Unit"
                setFormSelect={setFormSelect}
              />
              <ListCommand listText="RAM Stick" setFormSelect={setFormSelect} />
              <ListCommand listText="Case" setFormSelect={setFormSelect} />
              <ListCommand listText="Cooler" setFormSelect={setFormSelect} />
              <ListCommand listText="SSD" setFormSelect={setFormSelect} />
              <ListSubheader component="div" id="nested-list-subheader">
                Users controls
              </ListSubheader>
              <ListCommand listText="User" setFormSelect={setFormSelect} />
              <ListSubheader component="div" id="nested-list-subheader">
                Order controls
              </ListSubheader>
              <ListCommand listText="Order" setFormSelect={setFormSelect} />
            </List>
          </div>
        </Grid>
        <Grid item lg={10} md={9} sm={8} xs={6}>
          <div className={classes.smallContainer}>
            <main className={classes.layout}>
              <Paper className={classes.paper} elevation={6}>
                {!formSelect ? (
                  <div
                    className="image"
                    style={{
                      display: "flex",
                      marginTop: "25px",
                      justifyContent: "center",
                      flexDirection: "column",
                    }}
                  >
                    <Typography variant="h4" gutterBottom align="center">
                      Admin Page
                    </Typography>
                    <img src={LoginLogo} alt="" />
                  </div>
                ) : (
                  <>
                    <Typography variant="h5" gutterBottom align="center">
                      {formSelect && formSelect + " form"}
                    </Typography>
                    <Divider style={{ marginBottom: "20px" }} />
                    <FormSelector formKeyword={formSelect} />
                  </>
                )}
              </Paper>
            </main>
          </div>
        </Grid>
      </Grid>
    </main>
  );
};

const mapStateToProps = (state) => {
  return {
    isLoggedIn: state.userReducer.isLoggedIn,
    admin: state.userReducer.admin,
  };
};

export default connect(mapStateToProps)(AdminPage);
