import React from "react";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";
import InfoOutlinedIcon from "@mui/icons-material/InfoOutlined";
import AddCircleOutlineOutlinedIcon from "@mui/icons-material/AddCircleOutlineOutlined";
import RemoveCircleOutlineOutlinedIcon from "@mui/icons-material/RemoveCircleOutlineOutlined";
import UpdateOutlinedIcon from "@mui/icons-material/UpdateOutlined";

const SubListCommand = ({ text, op, setFormSelect }) => {
  const handleClick = () => {
    setFormSelect(text);
  };
  return (
    <ListItemButton sx={{ pl: 4 }} onClick={handleClick}>
      <ListItemIcon>
        {op === "Add" ? (
          <AddCircleOutlineOutlinedIcon />
        ) : op === "Remove" ? (
          <RemoveCircleOutlineOutlinedIcon />
        ) : op === "Update" ? (
          <UpdateOutlinedIcon />
        ) : op === "Info" ? (
          <InfoOutlinedIcon />
        ) : null}
      </ListItemIcon>
      <ListItemText primary={text} />
    </ListItemButton>
  );
};

export default SubListCommand;
