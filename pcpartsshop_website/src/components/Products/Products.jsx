import React, { useState, useEffect } from "react";
import {
  Typography,
  Grid,
  TextField,
  InputAdornment,
  IconButton,
} from "@material-ui/core";
import SearchOutlinedIcon from "@mui/icons-material/SearchOutlined";
import Product from "./Product/Product";
import useStyles from "./styles";
import ClearOutlinedIcon from "@mui/icons-material/ClearOutlined";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import * as shoppingActions from "../../redux/Shopping/shopping-actions";
import SelectComponent from "../Products/FilterProducts/SelectComponent";
import axios from "axios";

const componentMapping = {
  CPU: "CPU",
  GPU: "Graphics card",
  MOBO: "Motherboard",
  PSU: "Power unit",
  RAM: "Ram memory stick",
  CASE: "Case",
  COOLER: "Cooler",
  SSD: "Storage unit",
};

const searchFields = ["make", "model"];

const getKeyByValue = (obj, val) => {
  return Object.keys(obj).find((key) => obj[key] === val);
};

const Products = (props) => {
  const { products = [], isLoadingParts = false, admin = false } = props;
  const [selected, setSelected] = useState("");
  const [sortSelection, setSortSelection] = useState("");
  const [search, setSearch] = useState("");
  const [productsFiltered, setProductsFiltered] = useState(products);
  const classes = useStyles();

  useEffect(() => {
    props.fetchProducts();
  }, []);

  useEffect(() => {
    const getProducts = async () => {
      const res = await axios.get(
        process.env.REACT_APP_API_URL +
          getKeyByValue(componentMapping, selected)
      );
      setProductsFiltered(res.data);
    };

    if (selected === "") setProductsFiltered(products);
    if (selected) {
      getProducts();
    }
  }, [selected, products]);

  const applyFilters = (products) => {
    const products_aux = JSON.parse(JSON.stringify(products));
    switch (sortSelection) {
      case "Price ascending":
        return products_aux
          .sort((a, b) => a.price - b.price)
          .filter((item) =>
            searchFields.some((key) =>
              item[key].toLowerCase().includes(search.toLowerCase())
            )
          );
      case "Price descending":
        return products_aux
          .sort((a, b) => b.price - a.price)
          .filter((item) =>
            searchFields.some((key) =>
              item[key].toLowerCase().includes(search.toLowerCase())
            )
          );
      default:
        if (search) {
          return products_aux.filter((item) =>
            searchFields.some((key) =>
              item[key].toLowerCase().includes(search.toLowerCase())
            )
          );
        }
        return products;
    }
  };

  if (isLoadingParts)
    return (
      <Grid align="center">
        <Typography>Loading parts...</Typography>
      </Grid>
    );

  return (
    <main className={classes.content}>
      <Grid container spacing={2}>
        <Grid item lg={4} md={4} sm={12} xs={12}>
          <SelectComponent
            selected={selected}
            setSelected={setSelected}
            options="components"
            label="Component type"
          />
        </Grid>
        <Grid item lg={4} md={4} sm={12} xs={12}>
          <SelectComponent
            selected={sortSelection}
            setSelected={setSortSelection}
            options="sortBy"
            label="Sort by price"
          />
        </Grid>
        <Grid item lg={4} md={4} sm={12} xs={12}>
          <TextField
            className={classes.searchFilter}
            id="SearchBar"
            fullWidth
            label="Search"
            variant="outlined"
            value={search}
            onChange={(e) => setSearch(e.target.value)}
            InputProps={{
              endAdornment: (
                <>
                  <IconButton disabled={!search} onClick={() => setSearch("")}>
                    <ClearOutlinedIcon />
                  </IconButton>
                  <InputAdornment position="end">
                    <SearchOutlinedIcon />
                  </InputAdornment>
                </>
              ),
            }}
          />
        </Grid>
        <Grid item lg={12} md={12} sm={12} xs={12}>
          <Grid container className={classes.smallContainer} spacing={3}>
            {productsFiltered &&
              applyFilters(productsFiltered).map((product, key) => (
                <Grid
                  item
                  key={product.componentId}
                  xs={12}
                  sm={6}
                  md={4}
                  lg={3}
                >
                  <Product
                    product={product}
                    addToCart={props.addToCart}
                    isAdmin={admin}
                  />
                </Grid>
              ))}
          </Grid>
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
    admin: state.userReducer.admin,
  };
}

function mapDispatchToProps(dispatch) {
  return { ...bindActionCreators(shoppingActions, dispatch) };
}

export default connect(mapStateToProps, mapDispatchToProps)(Products);
