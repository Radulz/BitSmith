import React, { useState } from "react";
import MenuItem from "@mui/material/MenuItem";
import Select from "@mui/material/Select";
import { FormControl, InputLabel, OutlinedInput } from "@material-ui/core";
import useStyles from "./styles";

const filterOptions = {
  components: [
    "CPU",
    "Graphics card",
    "Motherboard",
    "Power unit",
    "Ram memory stick",
    "Case",
    "Cooler",
    "Storage unit",
  ],
  sortBy: ["Price ascending", "Price descending"],
};

const SelectComponent = ({ selected, setSelected, label, options }) => {
  const handleChange = (event) => {
    setSelected(event.target.value ?? "");
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleOpen = () => {
    setOpen(true);
  };

  const [open, setOpen] = useState(false);
  const classes = useStyles();

  return (
    <FormControl fullWidth className={classes.filterDropdown}>
      <InputLabel color="primary" id="filterLabel" variant="outlined">
        {label}
      </InputLabel>
      <Select
        labelId="filterLabel"
        id={label}
        open={open}
        onClose={() => handleClose()}
        onOpen={() => handleOpen()}
        onChange={(e) => handleChange(e)}
        value={selected ?? ""}
        defaultValue={""}
        input={<OutlinedInput label={label} />}
        sx={{ backgroundColor: "#fff" }}
      >
        <MenuItem key="none" value={""}>
          None
        </MenuItem>
        {filterOptions[options].map((item) => (
          <MenuItem key={item} value={item}>
            {item}
          </MenuItem>
        ))}
      </Select>
    </FormControl>
  );
};

export default SelectComponent;
