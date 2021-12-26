import React from "react";
import {
  Card,
  CardMedia,
  CardContent,
  CardActions,
  Typography,
  IconButton,
} from "@material-ui/core";
import { AddShoppingCart } from "@material-ui/icons";
import useStyles from "./styles";

const GPUProduct = (props) => {
  const { product } = props;
  const classes = useStyles();
  return (
    <Card className={classes.root}>
      <CardMedia
        component="img"
        height="140"
        title="prodf"
        image={product.image}
        alt="placa video"
      />
      <CardContent>
        <div className={classes.cardContent}>
          <Typography variant="h5" gutterBottom>
            {product.make + " " + product.model}
          </Typography>
        </div>
        <Typography
          dangerouslySetInnerHTML={{
            __html: "Frequency: " + product.frequency + " MHz ",
          }}
          variant="body2"
          color="textSecondary"
        />
        <Typography
          dangerouslySetInnerHTML={{
            __html: "Virtual Memory: " + product.memoryCapacity + " GB",
          }}
          variant="body2"
          color="textSecondary"
        />
        <Typography
          dangerouslySetInnerHTML={{
            __html: "Memory type: " + product.memoryType,
          }}
          variant="body2"
          color="textSecondary"
        />
        <Typography
          dangerouslySetInnerHTML={{
            __html: "Technology: " + product.technology + " nm",
          }}
          variant="body2"
          color="textSecondary"
        />
        <Typography
          dangerouslySetInnerHTML={{
            __html: "Length: " + product.length + " mm",
          }}
          variant="body2"
          color="textSecondary"
        />
        <Typography
          dangerouslySetInnerHTML={{
            __html:
              "Maximum power consumption: " + product.powerConsumption + " W",
          }}
          variant="body2"
          color="textSecondary"
        />
      </CardContent>
      <CardActions disableSpacing className={classes.cardActions}>
        <Typography variant="h5">{product.price.toFixed(2) + "$"}</Typography>
        <IconButton
          aria-label="Add to Cart"
          onClick={() => props.addToCart(product.componentId)}
        >
          <AddShoppingCart />
        </IconButton>
      </CardActions>
    </Card>
  );
};

export default GPUProduct;
