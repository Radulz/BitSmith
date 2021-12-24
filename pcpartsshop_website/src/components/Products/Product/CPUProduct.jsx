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

const CPUProduct = (props) => {
  const { product } = props;
  const classes = useStyles();
  return (
    <Card className={classes.root}>
      <CardMedia
        component="img"
        height="140"
        title="prodf"
        image={product.image}
        alt="procesor"
      />
      <CardContent>
        <div className={classes.cardContent}>
          <Typography variant="h5" gutterBottom>
            {product.make + " " + product.model}
          </Typography>
        </div>
        <Typography
          dangerouslySetInnerHTML={{ __html: "Socket: " + product.socket }}
          variant="body2"
          color="textSecondary"
        />
        <Typography
          dangerouslySetInnerHTML={{
            __html: "Frequency: " + product.freq + " GHz ",
          }}
          variant="body2"
          color="textSecondary"
        />
        <Typography
          dangerouslySetInnerHTML={{
            __html: "Technology: " + product.tech + " nm",
          }}
          variant="body2"
          color="textSecondary"
        />
        <Typography
          dangerouslySetInnerHTML={{
            __html: "Number of cores: " + product.cores,
          }}
          variant="body2"
          color="textSecondary"
        />
        <Typography
          dangerouslySetInnerHTML={{
            __html: "Memory frequency: " + product.mFreq + " MHz",
          }}
          variant="body2"
          color="textSecondary"
        />
        <Typography
          dangerouslySetInnerHTML={{
            __html: "TDP: " + product.tdp + " W",
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

export default CPUProduct;
