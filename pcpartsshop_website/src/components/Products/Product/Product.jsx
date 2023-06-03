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
        title="Component"
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
        {product.componentType === "CASE" && product.radiatorSupport ? (
          <Typography
            dangerouslySetInnerHTML={{ __html: "Has radiator support: Yes" }}
            variant="body2"
            color="textSecondary"
          />
        ) : (
          product.componentType === "CASE" && (
            <Typography
              dangerouslySetInnerHTML={{
                __html: "Has radiator support: No",
              }}
              variant="body2"
              color="textSecondary"
            />
          )
        )}
        {product.componentType === "CASE" &&
        product.radiatorSupportLength === 0 ? (
          <Typography
            dangerouslySetInnerHTML={{ __html: "Radiator support length: N/A" }}
            variant="body2"
            color="textSecondary"
          />
        ) : (
          product.componentType === "CASE" && (
            <Typography
              dangerouslySetInnerHTML={{
                __html:
                  "Radiator support length: " +
                  product.radiatorSupportLength +
                  " mm ",
              }}
              variant="body2"
              color="textSecondary"
            />
          )
        )}
        {product.componentType === "COOLER" && product.height === 0 ? (
          <Typography
            dangerouslySetInnerHTML={{ __html: "Height: N/A" }}
            variant="body2"
            color="textSecondary"
          />
        ) : (
          product.componentType === "COOLER" && (
            <Typography
              dangerouslySetInnerHTML={{
                __html: "Height: " + product.height + " mm ",
              }}
              variant="body2"
              color="textSecondary"
            />
          )
        )}
        {product.componentType === "COOLER" &&
        product.numberOfHeatPipes === 0 ? (
          <Typography
            dangerouslySetInnerHTML={{ __html: "Number of heat pipes: N/A" }}
            variant="body2"
            color="textSecondary"
          />
        ) : (
          product.componentType === "COOLER" && (
            <Typography
              dangerouslySetInnerHTML={{
                __html: "Number of heat pipes: " + product.numberOfHeatPipes,
              }}
              variant="body2"
              color="textSecondary"
            />
          )
        )}
        {product.componentType === "COOLER" && product.radiatorLength === 0 ? (
          <Typography
            dangerouslySetInnerHTML={{ __html: "Cooler radiator length: N/A" }}
            variant="body2"
            color="textSecondary"
          />
        ) : (
          product.componentType === "COOLER" && (
            <Typography
              dangerouslySetInnerHTML={{
                __html:
                  "Cooler radiator length: " + product.radiatorLength + " mm ",
              }}
              variant="body2"
              color="textSecondary"
            />
          )
        )}
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
