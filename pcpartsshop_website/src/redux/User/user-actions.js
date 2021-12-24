import { LOG_IN, LOG_OUT } from "./user-types";

export const logIn = (
  email,
  firstName,
  lastName,
  county,
  city,
  address,
  admin
) => {
  return (dispatch, getState) => {
    dispatch({
      type: LOG_IN,
      email,
      firstName,
      lastName,
      county,
      city,
      address,
      admin,
    });
  };
};

export const logOut = (email) => {
  return (dispatch, getState) => {
    dispatch({ type: LOG_OUT, email });
  };
};
