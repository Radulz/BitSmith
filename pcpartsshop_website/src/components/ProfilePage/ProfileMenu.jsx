import React from "react";
import Box from "@mui/material/Box";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";
import InfoOutlinedIcon from "@mui/icons-material/InfoOutlined";
import ListSubheader from "@mui/material/ListSubheader";

const ProfileMenu = ({ selected, setSelected }) => {
  return (
    <Box sx={{ width: "100%", maxWidth: 250, bgcolor: "background.paper" }}>
      <nav aria-label="main mailbox folders">
        <List>
          <ListSubheader component="div" id="nested-list-subheader">
            Menu
          </ListSubheader>
          <ListItem disablePadding>
            <ListItemButton onClick={setSelected("Order History")}>
              <ListItemIcon>
                <InfoOutlinedIcon />
              </ListItemIcon>
              <ListItemText primary="Order History" />
            </ListItemButton>
          </ListItem>
        </List>
      </nav>
    </Box>
  );
};

export default ProfileMenu;
