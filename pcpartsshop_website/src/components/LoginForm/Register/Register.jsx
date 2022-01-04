import React from "react";
import LoginLogo from "../../../images/LoginLogo.png";
import { useState } from "react";
import {
  FormControl,
  Input,
  InputLabel,
  Grid,
  FormHelperText,
} from "@material-ui/core";
import "./styles.scss";
import { ColorButton } from "../ColorButton";
import { useForm, Controller } from "react-hook-form";
import { joiResolver } from "@hookform/resolvers/joi";
import * as constants from "../../../constants/UserConstants";
import Joi from "joi";
import axios from "axios";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

toast.configure();

const schema = Joi.object({
  email: Joi.string()
    .email({ tlds: { allow: false } })
    .required(),
  password: Joi.string().min(8).max(64).required(),
  confirmPassword: Joi.string().min(8).max(64).required(),
  firstName: Joi.string().required(),
  lastName: Joi.string().required(),
  county: Joi.string().required(),
  city: Joi.string().required(),
  address: Joi.string().required(),
});

const Register = (props) => {
  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm({
    defaultValues: {
      email: "",
      password: "",
      confirmPassword: "",
      firstName: "",
      lastName: "",
      county: "",
      city: "",
      address: "",
    },
    resolver: joiResolver(schema),
  });
  console.log(errors);
  const [existantEmail, setExistantEmail] = useState(null);
  const [matchPassword, setMatchPassword] = useState(true);

  const notify = (response) => {
    if (response) {
      toast.success("Registration Successful!", {
        position: toast.POSITION.TOP_CENTER,
        autoClose: 2000,
      });
    } else {
      toast.error("Something went wrong.", {
        position: toast.POSITION.TOP_CENTER,
        autoClose: 2000,
      });
    }
  };

  const validatePasswords = (pass, cpass) => {
    if (pass !== cpass) {
      return false;
    }
    return true;
  };

  const validateExistantEmail = async (email) => {
    let response;
    let existantEmail;
    try {
      response = await axios.get(
        process.env.REACT_APP_API_URL + `User/users/${email}`
      );
      if (response.data) {
        existantEmail = true;
      }
    } catch (e) {
      existantEmail = false;
    } finally {
      return existantEmail;
    }
  };

  const onSubmit = async (data) => {
    let sw = true;
    const emailExistant = await validateExistantEmail(data.email);
    if (emailExistant) {
      setExistantEmail(true);
      sw = false;
      return;
    }
    if (!validatePasswords(data.password, data.confirmPassword)) {
      setMatchPassword(false);
      sw = false;
      return;
    }
    if (sw) {
      setExistantEmail(false);
      const response = await axios.post(
        process.env.REACT_APP_API_URL + "User",
        {
          email: data.email,
          password: data.password,
          firstName: data.firstName,
          lastName: data.lastName,
          city: data.city,
          county: data.county,
          address: data.address,
          admin: false,
        }
      );
      if (response) {
        notify(true);
      } else {
        notify(false);
      }
    }
    //then, encrypt pass and send data to the api
  };
  return (
    <div className="base-container" style={{ marginTop: "50px" }}>
      <div className="content">
        <div className="image">
          <img src={LoginLogo} alt="logo" />
        </div>
        <form className="form-group" onSubmit={handleSubmit(onSubmit)}>
          <Grid container spacing={1}>
            <Grid item xs={12} sm={12}>
              <Controller
                name={constants.EMAIL}
                control={control}
                render={({ field }) => (
                  <FormControl>
                    <InputLabel htmlFor="component-simple" required>
                      {" "}
                      {constants.EMAIL_LABEL}{" "}
                    </InputLabel>
                    <Input {...field} error={!!errors.email || existantEmail} />
                    {errors.email ? (
                      <FormHelperText error>Ex. name@domain.com</FormHelperText>
                    ) : existantEmail ? (
                      <FormHelperText error>
                        Email already exists.
                      </FormHelperText>
                    ) : (
                      <FormHelperText>Ex. name@domain.com</FormHelperText>
                    )}
                  </FormControl>
                )}
              />
            </Grid>
            <Grid item xs={12} sm={12}>
              <Controller
                name={constants.FIRST_NAME}
                control={control}
                render={({ field }) => (
                  <FormControl>
                    <InputLabel htmlFor="component-simple" required>
                      {constants.FIRST_NAME_LABEL}
                    </InputLabel>
                    <Input {...field} error={!!errors.firstName} />
                  </FormControl>
                )}
              />
            </Grid>
            <Grid item xs={12} sm={12}>
              <Controller
                name={constants.LAST_NAME}
                control={control}
                render={({ field }) => (
                  <FormControl>
                    <InputLabel htmlFor="component-simple" required>
                      {constants.LAST_NAME_LABEL}
                    </InputLabel>
                    <Input {...field} error={!!errors.lastName} />
                  </FormControl>
                )}
              />
            </Grid>
            <Grid item xs={12} sm={12}>
              <Controller
                name={constants.COUNTY}
                control={control}
                render={({ field }) => (
                  <FormControl>
                    <InputLabel htmlFor="component-simple" required>
                      {constants.COUNTY_LABEL}
                    </InputLabel>
                    <Input {...field} error={!!errors.county} />
                  </FormControl>
                )}
              />
            </Grid>
            <Grid item xs={12} sm={12}>
              <Controller
                name={constants.CITY}
                control={control}
                render={({ field }) => (
                  <FormControl>
                    <InputLabel htmlFor="component-simple" required>
                      {constants.CITY_LABEL}
                    </InputLabel>
                    <Input {...field} error={!!errors.city} />
                  </FormControl>
                )}
              />
            </Grid>
            <Grid item xs={12} sm={12}>
              <Controller
                name={constants.ADDRESS}
                control={control}
                render={({ field }) => (
                  <FormControl>
                    <InputLabel htmlFor="component-simple" required>
                      {constants.ADDRESS_LABEL}
                    </InputLabel>
                    <Input {...field} error={!!errors.address} />
                  </FormControl>
                )}
              />
            </Grid>
            <Grid item xs={12} sm={12}>
              <Controller
                name={constants.PASSWORD}
                control={control}
                render={({ field }) => (
                  <FormControl>
                    <InputLabel htmlFor="component-simple" required>
                      {" "}
                      {constants.PASSWORD_LABEL}{" "}
                    </InputLabel>
                    <Input
                      {...field}
                      error={!!errors.password}
                      type="password"
                    />
                    <FormHelperText>
                      Length between 8 and 64 symbols
                    </FormHelperText>
                  </FormControl>
                )}
              />
            </Grid>
            <Grid item xs={12} sm={12}>
              <Controller
                name={constants.CONFIRMPASSWORD}
                control={control}
                render={({ field }) => (
                  <FormControl>
                    <InputLabel htmlFor="component-simple" required>
                      {" "}
                      {constants.CONFIRMPASSWORD_LABEL}{" "}
                    </InputLabel>
                    <Input
                      {...field}
                      error={!!errors.confirmPassword || !matchPassword}
                      type="password"
                    />
                    {matchPassword ? null : (
                      <FormHelperText error>
                        Passwords must match.
                      </FormHelperText>
                    )}
                  </FormControl>
                )}
              />
            </Grid>
          </Grid>
        </form>
        <ColorButton
          variant="contained"
          style={{ marginTop: "15px" }}
          type="submit"
          onClick={handleSubmit(onSubmit)}
        >
          Register
        </ColorButton>
      </div>
    </div>
  );
};
export default Register;
