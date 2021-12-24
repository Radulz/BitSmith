import { Typography, Grid } from "@material-ui/core";
import React from "react";
import { useState } from "react";
import "./styles.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCaretDown, faCaretUp } from "@fortawesome/free-solid-svg-icons";

const Dropdown = ({ selected, setSelected }) => {
  const [isActive, setIsActive] = useState(false);
  const options = [
    "CPU",
    "GPU",
    "Motherboards",
    "Power Units",
    "Ram memory sticks",
    "Remove Filter",
  ];
  return (
    <div className="dropdown">
      <meta charSet="utf-8" />
      <div
        className="dropdown_btn"
        defaultValue="Filter"
        onClick={(e) => setIsActive(!isActive)}
      >
        {selected
          ? selected === "Remove Filter"
            ? "Filter"
            : selected
          : "Filter"}
        <div>
          {isActive ? (
            <FontAwesomeIcon icon={faCaretUp} />
          ) : (
            <FontAwesomeIcon icon={faCaretDown} />
          )}
        </div>
      </div>
      {isActive && (
        <div className="dropdown_content">
          {options.map((op) => (
            <div
              className="dropdown_item"
              onClick={(e) => {
                setSelected(op);
                setIsActive(false);
              }}
            >
              {op}
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default Dropdown;
