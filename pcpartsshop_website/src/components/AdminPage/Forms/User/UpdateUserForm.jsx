import React from "react";
import {
  Button,
  Grid,
  FormControl,
  Input,
  InputLabel,
  FormHelperText,
  MenuItem,
  Select,
  Typography,
} from "@material-ui/core";
import { useForm, Controller } from "react-hook-form";
import { joiResolver } from "@hookform/resolvers/joi";
import Joi from "joi";
import * as constants from "../../../../constants/UserConstants";

const schema = Joi.object({
  userId: Joi.string().guid().required(),
  email: Joi.string()
    .email({ tlds: { allow: false } })
    .required(),
  password: Joi.string().min(8).max(64).required(),
  firstName: Joi.string().required(),
  lastName: Joi.string().required(),
  county: Joi.string().required(),
  city: Joi.string().required(),
  address: Joi.string().required(),
  admin: Joi.boolean().required(),
});

const UpdateUserForm = () => {
  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm({
    defaultValues: {
      userId: "",
      email: "",
      password: "",
      firstName: "",
      lastName: "",
      county: "",
      city: "",
      address: "",
      admin: "",
    },
    resolver: joiResolver(schema),
  });
  console.log(errors);
  const onSubmit = (data) => {
    console.log(data);
  };
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <Grid container spacing={2}>
        <Grid item xs={12} sm={6}>
          <Controller
            name={constants.USERID}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {" "}
                  {constants.USERID_LABEL}{" "}
                </InputLabel>
                <Input {...field} error={!!errors.userId} />
                {errors.userId ? (
                  <FormHelperText error>Guid. Field required.</FormHelperText>
                ) : (
                  <FormHelperText>Unique identifier. (Guid)</FormHelperText>
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
            name={constants.PASSWORD}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {" "}
                  {constants.PASSWORD_LABEL}{" "}
                </InputLabel>
                <Input {...field} error={!!errors.password} type="password" />
                {errors.password ? (
                  <FormHelperText error>Field required.</FormHelperText>
                ) : (
                  <FormHelperText>
                    Length between 8 and 64 symbols
                  </FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
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
        <Grid item xs={12} sm={6}>
          <Controller
            name={constants.ADMIN}
            control={control}
            render={({ field }) => (
              <FormControl variant="standard" sx={{ minWidth: 195 }}>
                <InputLabel htmlFor="component-simple">
                  {constants.ADMIN_LABEL}
                </InputLabel>
                <Select {...field} error={!!errors.admin}>
                  <MenuItem value={false}>No</MenuItem>
                  <MenuItem value={true}>Yes</MenuItem>
                </Select>
                {errors.admin ? (
                  <FormHelperText error>
                    User admin role must be selected.
                  </FormHelperText>
                ) : (
                  <FormHelperText>
                    Select if the user role is an admin.
                  </FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
      </Grid>
      <br />
      <Typography variant="subtitle2" gutterBottom>
        *If the new email already exists under a different ID, the user cannot
        be updated.
      </Typography>
      <div
        style={{
          display: "flex",
          marginTop: "25px",
          justifyContent: "center",
        }}
      >
        <Button variant="contained" type="submit" color="primary">
          Submit
        </Button>
      </div>
    </form>
  );
};

export default UpdateUserForm;
