import React from "react";
import * as constants from "../../constants/AddressFormConstants";
import { Button, Grid, Typography } from "@material-ui/core";
import { useForm, FormProvider } from "react-hook-form";
import { Link } from "react-router-dom";
import { connect } from "react-redux";
import FormInputField from "../FormInputField/FormInputField";

const AddressForm = ({
  next,
  email,
  firstName,
  lastName,
  county,
  city,
  address,
  isLoggedIn,
}) => {
  const { register, handleSubmit } = useForm();
  const onSubmit = (data) => {
    next(data);
  };
  return (
    <>
      <Typography variant="h6" gutterBottom>
        Shipping Address
      </Typography>
      <FormProvider>
        <form onSubmit={handleSubmit(onSubmit)}>
          <Grid container spacing={4}>
            {!isLoggedIn ? (
              <>
                <FormInputField
                  name={constants.FIRST_NAME}
                  labelText={constants.FIRST_NAME_LABEL}
                  register={register}
                  isLoggedIn={false}
                />
                <FormInputField
                  name={constants.LAST_NAME}
                  labelText={constants.LAST_NAME_LABEL}
                  register={register}
                  isLoggedIn={false}
                />
                <FormInputField
                  name={constants.EMAIL}
                  labelText={constants.EMAIL_LABEL}
                  register={register}
                  isLoggedIn={false}
                />
                <FormInputField
                  name={constants.COUNTY}
                  labelText={constants.COUNTY_LABEL}
                  register={register}
                  isLoggedIn={false}
                />
                <FormInputField
                  name={constants.CITY}
                  labelText={constants.CITY_LABEL}
                  register={register}
                  isLoggedIn={false}
                />
                <FormInputField
                  name={constants.ADDRESS}
                  labelText={constants.ADDRESS_LABEL}
                  register={register}
                  isLoggedIn={false}
                />
              </>
            ) : (
              <>
                <FormInputField
                  name={constants.FIRST_NAME}
                  labelText={constants.FIRST_NAME_LABEL}
                  register={register}
                  defaultValue={firstName}
                  isLoggedIn={true}
                />
                <FormInputField
                  name={constants.LAST_NAME}
                  labelText={constants.LAST_NAME_LABEL}
                  register={register}
                  defaultValue={lastName}
                  isLoggedIn={true}
                />
                <FormInputField
                  name={constants.EMAIL}
                  labelText={constants.EMAIL_LABEL}
                  register={register}
                  defaultValue={email}
                  isLoggedIn={true}
                />
                <FormInputField
                  name={constants.COUNTY}
                  labelText={constants.COUNTY_LABEL}
                  register={register}
                  defaultValue={county}
                  isLoggedIn={true}
                />
                <FormInputField
                  name={constants.CITY}
                  labelText={constants.CITY_LABEL}
                  register={register}
                  defaultValue={city}
                  isLoggedIn={true}
                />
                <FormInputField
                  name={constants.ADDRESS}
                  labelText={constants.ADDRESS_LABEL}
                  register={register}
                  defaultValue={address}
                  isLoggedIn={true}
                />
              </>
            )}
          </Grid>
          <br />
          <div
            style={{
              display: "flex",
              justifyContent: "space-between",
              marginTop: "25px",
            }}
          >
            <Button component={Link} to="/cart" variant="outlined">
              Back to Cart
            </Button>
            <Button type="submit" variant="contained" color="primary">
              Next
            </Button>
          </div>
        </form>
      </FormProvider>
    </>
  );
};

const mapStateToProps = (state) => {
  return {
    email: state.userReducer.email,
    firstName: state.userReducer.firstName,
    lastName: state.userReducer.lastName,
    county: state.userReducer.county,
    city: state.userReducer.city,
    address: state.userReducer.address,
    isLoggedIn: state.userReducer.isLoggedIn,
  };
};

export default connect(mapStateToProps)(AddressForm);
