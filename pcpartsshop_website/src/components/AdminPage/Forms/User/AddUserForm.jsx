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
} from "@material-ui/core";
import { useForm, Controller } from "react-hook-form";
import { joiResolver } from "@hookform/resolvers/joi";
import Joi from "joi";
import * as constants from "../../../../constants/UserConstants";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import axios from "axios";

const schema = Joi.object({
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

const AddUserForm = () => {
  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm({
    defaultValues: {
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
  const notify = (response) => {
    if (!response) {
      toast.error("Something went wrong.", {
        position: toast.POSITION.TOP_CENTER,
        autoClose: false,
      });
    } else if (response.status === 201) {
      toast.success(
        `User ${response.data.email} was registered with ID: ${response.data.userId}`,
        {
          position: toast.POSITION.TOP_CENTER,
          autoClose: false,
        }
      );
    }
  };
  const onSubmit = async (data) => {
    console.log(data);
    const user = await axios
      .get(process.env.REACT_APP_API_URL + `User/users/${data.email}`)
      .catch((e) => console.log(e));
    if (user) {
      toast.error("This user is already registered.", {
        position: toast.POSITION.TOP_CENTER,
        autoClose: false,
      });
      return;
    } else {
      const response = await axios.post(
        process.env.REACT_APP_API_URL + "User",
        {
          email: data.email,
          password: data.password,
          firstName: data.firstName,
          lastName: data.lastName,
          county: data.county,
          city: data.city,
          address: data.address,
          admin: data.admin,
        }
      );
      notify(response);
    }
  };
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <Grid container spacing={2}>
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

export default AddUserForm;
