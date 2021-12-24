import React from "react";
import { Typography, List, ListItem, ListItemText } from "@material-ui/core";

const Review = ({ productsAddedToCart, totalItems, totalPrice }) => {
  return (
    <>
      <Typography variant="h6" gutterBottom>
        Order Summary
      </Typography>
      <List disablePadding>
        {productsAddedToCart.map((p) => (
          <ListItem style={{ padding: "10px 0" }} key={p.componentId}>
            <ListItemText
              primary={p.make + " " + p.model}
              secondary={`Quantity: ${p.qty}`}
            />
            <Typography variant="body2">{p.price + " $"}</Typography>
          </ListItem>
        ))}
        <ListItem style={{ padding: "10px 0" }}>
          <ListItemText primary={`Total (${totalItems} items):`} />
          <Typography variant="subtitle1" style={{ fontWeight: 700 }}>
            {totalPrice} $
          </Typography>
        </ListItem>
      </List>
    </>
  );
};

export default Review;
