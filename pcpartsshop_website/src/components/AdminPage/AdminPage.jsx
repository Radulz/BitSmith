import React, { useState } from "react";
import { Typography, Grid, Paper, Divider } from "@material-ui/core";
import ListSubheader from "@mui/material/ListSubheader";
import List from "@mui/material/List";
import useStyles from "./styles";
import ListCommand from "./ListCommand";
import FormSelector from "./FormSelector";

const AdminPage = () => {
  const [formSelect, setFormSelect] = useState("");
  const classes = useStyles();
  return (
    <main className={classes.content}>
      <div className={classes.toolbar} />
      <Grid container>
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
              <ListSubheader component="div" id="nested-list-subheader">
                Users controls
              </ListSubheader>
              <ListCommand listText="User" setFormSelect={setFormSelect} />
            </List>
          </div>
        </Grid>
        <Grid item lg={10} md={9} sm={8} xs={6}>
          <div className={classes.smallContainer}>
            <main className={classes.layout}>
              <Paper className={classes.paper} elevation="6">
                <Typography variant="h5" gutterBottom align="center">
                  {formSelect && formSelect + " form"}
                </Typography>
                <Divider style={{ marginBottom: "20px" }} />
                <FormSelector formKeyword={formSelect} />
              </Paper>
            </main>
          </div>
        </Grid>
      </Grid>
    </main>
  );
};

export default AdminPage;
