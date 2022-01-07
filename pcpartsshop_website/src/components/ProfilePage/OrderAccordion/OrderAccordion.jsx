import React, { useState } from "react";
import Accordion from "@mui/material/Accordion";
import AccordionDetails from "@mui/material/AccordionDetails";
import AccordionSummary from "@mui/material/AccordionSummary";
import Typography from "@mui/material/Typography";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import ItemsGrid from "./ItemsGrid";

const OrderAccordion = ({ size, data }) => {
  const [expanded, setExpanded] = useState(false);

  const handleChange = (panel) => (event, isExpanded) => {
    setExpanded(isExpanded ? panel : false);
  };

  return (
    <div>
      {data.map((o) => (
        <Accordion
          expanded={expanded === o.orderId}
          onChange={handleChange(o.orderId)}
          key={o.orderId}
        >
          <AccordionSummary
            expandIcon={<ExpandMoreIcon />}
            aria-controls="panel1bh-content"
            id="panel1bh-header"
          >
            <Typography sx={{ width: "33%", flexShrink: 0 }}>
              Order Number:
            </Typography>
            <Typography sx={{ color: "text.secondary", marginLeft: 25 }}>
              {o.orderId}
            </Typography>
          </AccordionSummary>
          <AccordionDetails sx={{ width: size }}>
            <ItemsGrid rows={o.items} />
            <Typography variant="h5">Client details:</Typography>
            <Typography variant="h6">
              Full name: {o.firstName + " " + o.lastName}
            </Typography>
            <Typography variant="h6">
              Address: {o.address + ", " + o.county + ", " + o.city}
            </Typography>
            <Typography variant="h6">
              Order total price: {o.totalPrice} $
            </Typography>
            <Typography variant="h6">Shipping status: {o.status}</Typography>
          </AccordionDetails>
        </Accordion>
      ))}
    </div>
  );
};

export default OrderAccordion;
