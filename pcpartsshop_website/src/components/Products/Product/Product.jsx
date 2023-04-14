import React from "react";
// import CPUProduct from "./CPUProduct";
// import GPUProduct from "./GPUProduct";
// import MOBOProduct from "./MOBOProduct";
// import PSUProduct from "./PSUProduct";
// import RAMProduct from "./RAMProduct";
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
import { displayedProductsDetails } from "../../../constants/ProductsConstants";

const Product = (props) => {
  const { product, isAdmin } = props;
  const classes = useStyles();

  // switch (product.componentType) {
  //   case "CPU":
  //     return <CPUProduct product={product} addToCart={props.addToCart} />;
  //   case "GPU":
  //     return <GPUProduct product={product} addToCart={props.addToCart} />;
  //   case "MOBO":
  //     return <MOBOProduct product={product} addToCart={props.addToCart} />;
  //   case "PSU":
  //     return <PSUProduct product={product} addToCart={props.addToCart} />;
  //   case "RAM":
  //     return <RAMProduct product={product} addToCart={props.addToCart} />;
  //   default:
  //     return null;
  // }

  return (
    <Card className={classes.root}>
      <CardMedia
        component="img"
        height="140"
        title="prodf"
        image={product.image}
        alt={product.componentType}
      />
      <CardContent>
        <div className={classes.cardContent}>
          <Typography variant="h5" gutterBottom>
            {product.make + " " + product.model}
          </Typography>
        </div>
        {Object.keys(displayedProductsDetails).map((d) => {
          return (
            product[d] && (
              <Typography
                key={product.componentId + ` ${d}`}
                dangerouslySetInnerHTML={{
                  __html:
                    displayedProductsDetails[d]?.label +
                    product[d] +
                    displayedProductsDetails[d]?.unit[product.componentType],
                }}
                variant="body2"
                color="textSecondary"
              />
            )
          );
        })}
      </CardContent>
      <CardActions disableSpacing className={classes.cardActions}>
        <Typography variant="h5">{product.price.toFixed(2) + "$"}</Typography>
        <IconButton
          aria-label="Add to Cart"
          disabled={isAdmin ?? false}
          onClick={() => props.addToCart(product.componentId)}
        >
          <AddShoppingCart />
        </IconButton>
      </CardActions>
    </Card>
  );
};

export default Product;
