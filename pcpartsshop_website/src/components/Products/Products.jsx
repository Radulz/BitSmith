import React, { useState, useEffect } from "react";
import { Typography, Grid } from "@material-ui/core";
import Product from "./Product/Product";
import useStyles from "./styles";
import Dropdown from "./Dropdown/Dropdown";
import FilterDropdown from "./FilterDropdown/FilterDropdown";
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
    case "Graphics card":
      filteredProducts = products.filter((p) => p.componentType === "GPU");
      console.log(filteredProducts);
      break;
    case "Motherboard":
      filteredProducts = products.filter((p) => p.componentType === "MOBO");
      console.log(filteredProducts);
      break;
    case "Power unit":
      filteredProducts = products.filter((p) => p.componentType === "PSU");
      console.log(filteredProducts);
      break;
    case "Ram memory stick":
      filteredProducts = products.filter((p) => p.componentType === "RAM");
      console.log(filteredProducts);
      break;
    case "Remove filter":
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
      <Grid container>
        <Grid item lg={2} md={3} sm={4} xs={6}>
          <div className={classes.dashboardMenu}>
            <FilterDropdown selected={selected} setSelected={setSelected} />
          </div>
        </Grid>
        <Grid item lg={10} md={9} sm={8} xs={6}>
          <div className={classes.smallContainer}>
            <Grid
              container
              justifyContent="center"
              spacing={3}
              style={{ height: "100 vh" }}
              lg={10}
              md={8}
              sm={6}
              xs={4}
            >
              {filteredProducts &&
                filteredProducts.map((product, key) => (
                  <Grid
                    item
                    key={product.componentId}
                    xs={12}
                    sm={6}
                    md={4}
                    lg={3}
                  >
                    <Product product={product} addToCart={props.addToCart} />
                  </Grid>
                ))}
            </Grid>
          </div>
        </Grid>
      </Grid>
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
