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
import useStyles from "../../styles";
import { useForm, Controller } from "react-hook-form";
import { joiResolver } from "@hookform/resolvers/joi";
import Joi from "joi";
import * as constants from "../../../../constants/UserConstants";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import axios from "axios";

const schema = Joi.object({
  userId: Joi.string().guid().required(),
  email: Joi.string()
    .email({ tlds: { allow: false } })
    .required(),
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
  const classes = useStyles();
  const notify = (response) => {
    if (!response) {
      toast.error("Something went wrong.", {
        position: toast.POSITION.TOP_CENTER,
        autoClose: 5000,
      });
    } else if (response.status === 200) {
      toast.success(
        `User with ID: ${response.data.userId} was updated successfully.`,
        {
          position: toast.POSITION.TOP_CENTER,
          autoClose: 5000,
        }
      );
    }
  };
  const onSubmit = async (data) => {
    console.log(data);
    const user = await axios
      .get(process.env.REACT_APP_API_URL + `User/users/${data.email}`)
      .catch((e) => console.log(e));
    if (user && user.data.userId !== data.userId) {
      toast.error("User cannot be updated. Read the note!", {
        position: toast.POSITION.TOP_CENTER,
        autoClose: 5000,
      });
      return;
    } else if (!user || user.data.userId === data.userId) {
      const response = await axios
        .put(process.env.REACT_APP_API_URL + `User/${data.userId}`, {
          userId: data.userId,
          email: data.email,
          firstName: data.firstName,
          lastName: data.lastName,
          county: data.county,
          city: data.city,
          address: data.address,
          admin: data.admin,
        })
        .catch((e) => console.log(e));
      notify(response);
    }
  };
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <Grid container spacing={2}>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
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
        <Grid item xs={12} sm={6} className={classes.gridItem}>
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
        <Grid item xs={12} sm={6} className={classes.gridItem}>
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
        <Grid item xs={12} sm={6} className={classes.gridItem}>
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
        <Grid item xs={12} sm={6} className={classes.gridItem}>
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
        <Grid item xs={12} sm={6} className={classes.gridItem}>
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
        <Grid item xs={12} sm={6} className={classes.gridItem}>
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
        <Grid item xs={12} sm={6} className={classes.gridItem}>
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
      <Typography variant="subtitle2" gutterBottom align="center">
        Note: If the new email already exists under a different ID, the user
        cannot be updated.
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
