import React from "react";
import CPUProduct from "./CPUProduct";
import GPUProduct from "./GPUProduct";
import MOBOProduct from "./MOBOProduct";
import PSUProduct from "./PSUProduct";
import RAMProduct from "./RAMProduct";

const Product = (props) => {
  const { product } = props;
  switch (product.componentType) {
    case "CPU":
      return <CPUProduct product={product} addToCart={props.addToCart} />;
    case "GPU":
      return <GPUProduct product={product} addToCart={props.addToCart} />;
    case "MOBO":
      return <MOBOProduct product={product} addToCart={props.addToCart} />;
    case "PSU":
      return <PSUProduct product={product} addToCart={props.addToCart} />;
    case "RAM":
      return <RAMProduct product={product} addToCart={props.addToCart} />;
    default:
      return null;
  }
};

export default Product;
