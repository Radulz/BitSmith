import React, { useState } from "react";
import ListSubheader from "@mui/material/ListSubheader";
import List from "@mui/material/List";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";
import Collapse from "@mui/material/Collapse";
import ExpandLess from "@mui/icons-material/ExpandLess";
import ExpandMore from "@mui/icons-material/ExpandMore";
import FilterListIcon from "@mui/icons-material/FilterList";
import { Divider } from "@material-ui/core";
import SubListFilter from "./SubListFilter";

const FilterDropdown = ({ selected, setSelected }) => {
  const [open, setOpen] = useState(false);

  const handleClick = () => {
    setOpen(!open);
  };
  return (
    <List
      sx={{ width: "100%", maxWidth: 250, bgcolor: "background.paper" }}
      component="nav"
      aria-labelledby="nested-list-subheader"
      subheader={
        <ListSubheader component="div" id="nested-list-subheader">
          Filters
        </ListSubheader>
      }
    >
      <ListItemButton onClick={handleClick}>
        <ListItemIcon>
          <FilterListIcon />
        </ListItemIcon>
        <ListItemText primary="Component type" />
        {open ? <ExpandLess /> : <ExpandMore />}
      </ListItemButton>
      <Collapse in={open} timeout="auto" unmountOnExit>
        <List component="div" disablePadding>
          <SubListFilter
            text="CPU"
            selected={selected}
            setSelected={setSelected}
          />
          <Divider variant="inset" />
          <SubListFilter
            text="Graphics card"
            selected={selected}
            setSelected={setSelected}
          />
          <Divider variant="inset" />
          <SubListFilter
            text="Motherboard"
            selected={selected}
            setSelected={setSelected}
          />
          <Divider variant="inset" />
          <SubListFilter
            text="Power unit"
            selected={selected}
            setSelected={setSelected}
          />
          <Divider variant="inset" />
          <SubListFilter
            text="Ram memory stick"
            selected={selected}
            setSelected={setSelected}
          />
          <Divider variant="inset" />
          <SubListFilter
            text="Remove filter"
            selected={selected}
            setSelected={setSelected}
          />
          <Divider variant="inset" />
        </List>
      </Collapse>
    </List>
  );
};

export default FilterDropdown;
