import React, { useState } from "react";
import List from "@mui/material/List";
import SubListCommand from "./SubListCommand";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";
import Collapse from "@mui/material/Collapse";
import ExpandLess from "@mui/icons-material/ExpandLess";
import ExpandMore from "@mui/icons-material/ExpandMore";
import MenuOutlinedIcon from "@mui/icons-material/MenuOutlined";
import { Divider } from "@material-ui/core";

const ListCommand = ({ listText, setFormSelect }) => {
  const [open, setOpen] = useState(false);

  const handleClick = () => {
    setOpen(!open);
  };
  return (
    <>
      <ListItemButton onClick={handleClick}>
        <ListItemIcon>
          <MenuOutlinedIcon />
        </ListItemIcon>
        <ListItemText primary={listText} />
        {open ? <ExpandLess /> : <ExpandMore />}
      </ListItemButton>
      <Collapse in={open} timeout="auto" unmountOnExit>
        <List component="div" disablePadding>
          <SubListCommand
            text={"Add " + listText}
            op="Add"
            setFormSelect={setFormSelect}
          />
          <Divider variant="inset" />
          <SubListCommand
            text={"Remove " + listText}
            op="Remove"
            setFormSelect={setFormSelect}
          />
          <Divider variant="inset" />
          <SubListCommand
            text={"Update " + listText}
            op="Update"
            setFormSelect={setFormSelect}
          />
          <Divider variant="inset" />
          <SubListCommand
            text={"Get " + listText}
            op="Info"
            setFormSelect={setFormSelect}
          />
        </List>
      </Collapse>
    </>
  );
};

export default ListCommand;
