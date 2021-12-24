import { LOG_IN, LOG_OUT } from "./user-types";

import { REHYDRATE } from "redux-persist";

const INITIAL_STATE = {
  email: "",
  firstName: "",
  lastName: "",
  county: "",
  city: "",
  address: "",
  admin: false,
  isLoggedIn: false,
};

const userReducer = (state = INITIAL_STATE, action) => {
  switch (action.type) {
    case REHYDRATE: {
      return {
        ...INITIAL_STATE,
        email: action.payload ? action.payload.userReducer.email : "",
        firstName: action.payload ? action.payload.userReducer.firstName : "",
        lastName: action.payload ? action.payload.userReducer.lastName : "",
        county: action.payload ? action.payload.userReducer.county : "",
        city: action.payload ? action.payload.userReducer.city : "",
        address: action.payload ? action.payload.userReducer.address : "",
        admin: action.payload ? action.payload.userReducer.admin : false,
        isLoggedIn: action.payload
          ? action.payload.userReducer.isLoggedIn
          : false,
      };
    }
    case LOG_IN: {
      const userEmail = action.email;
      const userFirstName = action.firstName;
      const userLastName = action.lastName;
      const userCounty = action.county;
      const userCity = action.city;
      const userAddress = action.address;
      const userAdmin = action.admin;
      return {
        ...state,
        email: userEmail,
        firstName: userFirstName,
        lastName: userLastName,
        county: userCounty,
        city: userCity,
        address: userAddress,
        admin: userAdmin,
        isLoggedIn: true,
      };
    }
    case LOG_OUT: {
      return {
        ...state,
        email: "",
        firstName: "",
        lastName: "",
        county: "",
        city: "",
        address: "",
        admin: false,
        isLoggedIn: false,
      };
    }
    default:
      return state;
  }
};

export default userReducer;
