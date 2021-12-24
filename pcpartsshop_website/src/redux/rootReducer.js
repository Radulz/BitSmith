import { combineReducers } from "redux";

import shopReducer from "./Shopping/shopping-reducer";
import userReducer from "./User/user-reducer";

const products = combineReducers({
  shopReducer,
  userReducer,
});

export default products;
