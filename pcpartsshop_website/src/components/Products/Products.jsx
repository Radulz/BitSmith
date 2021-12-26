import React, { useState, useEffect } from "react";
import { Typography, Grid } from "@material-ui/core";
import Product from "./Product/Product";
import useStyles from "./styles";
import Dropdown from "./Dropdown/Dropdown";

import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import * as shoppingActions from "../../redux/Shopping/shopping-actions";

const Products = (props) => {
  const { products = [], isLoadingParts = false } = props;
  const [selected, setSelected] = useState("");
  const classes = useStyles();
  useEffect(() => {
    props.fetchProducts();
  }, []);
  if (isLoadingParts)
    return (
      <Grid align="center">
        <Typography>Loading parts...</Typography>
      </Grid>
    );
  let filteredProducts = [];
  switch (selected) {
    case "CPU":
      filteredProducts = products.filter((p) => p.componentType === "CPU");
      console.log(filteredProducts);
      break;
    case "GPU":
      filteredProducts = products.filter((p) => p.componentType === "GPU");
      console.log(filteredProducts);
      break;
    case "Motherboards":
      filteredProducts = products.filter((p) => p.componentType === "MOBO");
      console.log(filteredProducts);
      break;
    case "Power Units":
      filteredProducts = products.filter((p) => p.componentType === "PSU");
      console.log(filteredProducts);
      break;
    case "Ram memory sticks":
      filteredProducts = products.filter((p) => p.componentType === "RAM");
      console.log(filteredProducts);
      break;
    case "Remove Filter":
      filteredProducts = products;
      console.log(filteredProducts);

      break;
    default:
      filteredProducts = products;
      console.log(filteredProducts);
      console.log(process.env.REACT_APP_API_URL);
  }

  return (
    <main className={classes.content}>
      <div className={classes.toolbar} />
      <div className={classes.container}>
        <div
          style={{
            display: "flex",
            justifyContent: "start",
            alignSelf: "flex-start",
            maxWidth: "200px",
          }}
        >
          <Dropdown selected={selected} setSelected={setSelected}></Dropdown>
        </div>
        <div className={classes.smallContainer}>
          <Grid
            container
            justify="center"
            spacing={4}
            style={{ height: "100 vh" }}
            lg={8}
          >
            {filteredProducts &&
              filteredProducts.map((product, key) => (
                <Grid
                  item
                  key={product.componentId}
                  xs={12}
                  sm={6}
                  md={4}
                  lg={4}
                >
                  <Product product={product} addToCart={props.addToCart} />
                </Grid>
              ))}

            {console.log(selected)}
          </Grid>
        </div>
      </div>
    </main>
  );
};

function mapStateToProps(state) {
  const {
    shopReducer: { products, productsAddedToCart, isLoadingProducts },
  } = state;
  return {
    products: products.map((p) => {
      const isAddedToCart = productsAddedToCart.includes(p.componentId);
      return { ...p, isAddedToCart };
    }),

    isLoadingProducts,
  };
}

function mapDispatchToProps(dispatch) {
  return { ...bindActionCreators(shoppingActions, dispatch) };
}

export default connect(mapStateToProps, mapDispatchToProps)(Products);
