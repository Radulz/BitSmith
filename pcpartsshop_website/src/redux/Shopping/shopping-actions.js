import {
  ADD_TO_CART,
  FETCHING_PRODUCTS,
  FETCHING_PRODUCTS_SUCCESS,
  REMOVE_FROM_CART,
  REMOVE_ALL_FROM_CART,
  ADJUST_QTY,
} from "./shopping-types";
import axios from "axios";

export const fetchProducts = () => {
  return async (dispatch, getState) => {
    dispatch({ type: FETCHING_PRODUCTS });
    var result = await axios.get("https://localhost:44326/CPU");
    const cpus = result.data;

    result = await axios.get("https://localhost:44326/GPU");
    const gpus = result.data;

    result = await axios.get("https://localhost:44326/MOBO");
    const mobos = result.data;

    result = await axios.get("https://localhost:44326/PSU");
    const psus = result.data;

    result = await axios.get("https://localhost:44326/RAM");
    const rams = result.data;

    const products = [].concat(cpus, gpus, mobos, psus, rams);

    dispatch({ type: FETCHING_PRODUCTS_SUCCESS, products });
  };
};

export const addToCart = (itemId) => {
  return (dispatch, getState) => {
    dispatch({ type: ADD_TO_CART, itemId });
  };
};

export const removeFromCart = (itemId) => {
  console.log("Removed from cart");
  return (dispatch, getState) => {
    dispatch({ type: REMOVE_FROM_CART, itemId });
  };
};

export const removeAllFromCart = () => {
  return (dispatch, getState) => {
    dispatch({ type: REMOVE_ALL_FROM_CART });
  };
};

export const adjustQty = (itemId, value) => {
  return (dispatch, getState) => {
    dispatch({ type: ADJUST_QTY, itemId, value });
  };
};
