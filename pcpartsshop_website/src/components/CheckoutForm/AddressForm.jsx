import React from "react";
import * as constants from "../../constants/AddressFormConstants";
import {
  Button,
  Grid,
  Typography,
  FormControl,
  Input,
  InputLabel,
  FormHelperText,
} from "@material-ui/core";
import { useForm, Controller } from "react-hook-form";
import { joiResolver } from "@hookform/resolvers/joi";
import Joi from "joi";
import { Link } from "react-router-dom";
import { connect } from "react-redux";

const schema = Joi.object({
  email: Joi.string()
    .email({ tlds: { allow: false } })
    .required(),
  firstName: Joi.string().required(),
  lastName: Joi.string().required(),
  county: Joi.string().required(),
  city: Joi.string().required(),
  address: Joi.string().required(),
});

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
  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm({
    defaultValues: {
      email: email,
      firstName: firstName,
      lastName: lastName,
      county: county,
      city: city,
      address: address,
    },
    resolver: joiResolver(schema),
  });
  console.log(errors);
  const onSubmit = (data) => {
    next(data);
  };
  return (
    <>
      <Typography variant="h6" gutterBottom>
        Shipping Address
      </Typography>
      <form onSubmit={handleSubmit(onSubmit)}>
        <Grid container spacing={4}>
          <Grid item xs={12} sm={6}>
            <Controller
              name={constants.FIRST_NAME}
              control={control}
              render={({ field }) => (
                <FormControl>
                  <InputLabel htmlFor="component-simple">
                    {constants.FIRST_NAME_LABEL}
                  </InputLabel>
                  <Input {...field} error={!!errors.firstName} />
                  {errors.firstName ? (
                    <FormHelperText error>Field required.</FormHelperText>
                  ) : (
                    <FormHelperText disabled> </FormHelperText>
                  )}
                </FormControl>
              )}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <Controller
              name={constants.LAST_NAME}
              control={control}
              render={({ field }) => (
                <FormControl>
                  <InputLabel htmlFor="component-simple">
                    {constants.LAST_NAME_LABEL}
                  </InputLabel>
                  <Input {...field} error={!!errors.lastName} />
                  {errors.lastName ? (
                    <FormHelperText error>Field required.</FormHelperText>
                  ) : (
                    <FormHelperText disabled> </FormHelperText>
                  )}
                </FormControl>
              )}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <Controller
              name={constants.EMAIL}
              control={control}
              render={({ field }) => (
                <FormControl>
                  <InputLabel htmlFor="component-simple">
                    {" "}
                    {constants.EMAIL_LABEL}{" "}
                  </InputLabel>
                  <Input {...field} error={!!errors.email} />
                  {errors.email ? (
                    <FormHelperText error>Field required.</FormHelperText>
                  ) : (
                    <FormHelperText>ex. something@domain.com </FormHelperText>
                  )}
                </FormControl>
              )}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <Controller
              name={constants.COUNTY}
              control={control}
              render={({ field }) => (
                <FormControl>
                  <InputLabel htmlFor="component-simple">
                    {constants.COUNTY_LABEL}
                  </InputLabel>
                  <Input {...field} error={!!errors.county} />
                  {errors.county ? (
                    <FormHelperText error>Field required.</FormHelperText>
                  ) : (
                    <FormHelperText disabled> </FormHelperText>
                  )}
                </FormControl>
              )}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <Controller
              name={constants.CITY}
              control={control}
              render={({ field }) => (
                <FormControl>
                  <InputLabel htmlFor="component-simple">
                    {constants.CITY_LABEL}
                  </InputLabel>
                  <Input {...field} error={!!errors.city} />
                  {errors.city ? (
                    <FormHelperText error>Field required.</FormHelperText>
                  ) : (
                    <FormHelperText disabled></FormHelperText>
                  )}
                </FormControl>
              )}
            />
          </Grid>
          <Grid item xs={12} sm={6}>
            <Controller
              name={constants.ADDRESS}
              control={control}
              render={({ field }) => (
                <FormControl>
                  <InputLabel htmlFor="component-simple">
                    {constants.ADDRESS_LABEL}
                  </InputLabel>
                  <Input {...field} error={!!errors.address} />
                  {errors.address ? (
                    <FormHelperText error>Field required.</FormHelperText>
                  ) : (
                    <FormHelperText disabled></FormHelperText>
                  )}
                </FormControl>
              )}
            />
          </Grid>
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
