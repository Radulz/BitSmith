import React, { useState } from "react";

import {
  Typography,
  Button,
  Card,
  CardActions,
  CardContent,
  CardMedia,
  IconButton,
  Input,
} from "@material-ui/core";
import useStyles from "./styles";

import { connect } from "react-redux";
import {
  removeFromCart,
  adjustQty,
} from "../../../redux/Shopping/shopping-actions";

const CartItem = ({ product, removeFromCart, adjustQty }) => {
  const classes = useStyles();
  const [input, setInput] = useState(product.qty);
  const onChangeHandler = (e) => {
    setInput(e.target.value);
    adjustQty(product.componentId, e.target.value);
  };
  const plusOneQty = () => {
    setInput(product.qty + 1);
    adjustQty(product.componentId, product.qty + 1);
  };
  const minusOneQty = () => {
    if (product.qty === 1) {
      setInput(product.qty);
      adjustQty(product.componentId, product.qty);
    } else {
      setInput(product.qty - 1);
      adjustQty(product.componentId, product.qty - 1);
    }
  };
  const price = product.price * product.qty;
  const productPrice = Math.round((price + Number.EPSILON) * 100) / 100;
  return (
    <Card>
      <CardMedia
        component="img"
        image={product.image}
        alt={product.make + " " + product.model}
        className={classes.media}
      />
      <CardContent className={classes.cardContent}>
        <Typography variant="h5">
          {product.make + " " + product.model}
        </Typography>
      </CardContent>
      <CardActions disableSpacing className={classes.cartActions}>
        <div class={classes.cartActionsDivLeft}>
          <IconButton type="button" size="medium" onClick={minusOneQty}>
            -
          </IconButton>
          <Input
            id="quantity"
            //margin="normal"
            min="1"
            type="readonly"
            value={input}
            onChange={onChangeHandler}
            inputProps={{
              inputMode: "numeric",
              pattern: "[0-9]*",
              style: { width: 50, textAlign: "center" },
            }}
          />
          <IconButton type="button" size="medium" onClick={plusOneQty}>
            +
          </IconButton>
        </div>
        <div class={classes.cartActionsDivRight}>
          <Typography variant="h6" style={{ marginRight: "10px" }}>
            {productPrice + "$"}
          </Typography>
          <Button
            variant="contained"
            type="button"
            color="secondary"
            onClick={() => removeFromCart(product.componentId)}
          >
            Remove
          </Button>
        </div>
      </CardActions>
    </Card>
  );
};

const mapDispatchToProps = (dispatch) => {
  return {
    removeFromCart: (id) => dispatch(removeFromCart(id)),
    adjustQty: (id, value) => dispatch(adjustQty(id, value)),
  };
};

export default connect(null, mapDispatchToProps)(CartItem);
