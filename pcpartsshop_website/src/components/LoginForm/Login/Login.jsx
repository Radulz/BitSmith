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
import { logIn } from "../../../redux/User/user-actions";
import { connect } from "react-redux";
import { useNavigate } from "react-router-dom";

const schema = Joi.object({
  email: Joi.string()
    .email({ tlds: { allow: false } })
    .required(),
  password: Joi.string().min(8).max(64).required(),
});

const Login = ({ logIn }) => {
  const [existantEmail, setExistantEmail] = useState(true);
  const [checkedPassword, setCheckedPassword] = useState(true);
  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm({
    defaultValues: {
      email: "",
      password: "",
    },
    resolver: joiResolver(schema),
  });
  const navigate = useNavigate();

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
      setExistantEmail(existantEmail);
      return existantEmail;
    }
  };

  const checkPassword = async (email, pass) => {
    let response;
    try {
      response = await axios.get(
        process.env.REACT_APP_API_URL + `User/users/${email}`
      );
      if (response.data) {
        if (pass === response.data.password) {
          return true;
        }
      }
    } catch (e) {
      return false;
    }
    return false;
  };

  const notify = (response) => {
    if (response) {
      toast.success("Login successful!", {
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

  const onSubmit = async (data) => {
    const emailValidation = await validateExistantEmail(data.email);
    const passwordChecked = await checkPassword(data.email, data.password);
    if (!emailValidation) {
      setExistantEmail(false);
      return;
    }
    if (!passwordChecked) {
      setCheckedPassword(false);
      return;
    }
    console.log("Existant email " + existantEmail);
    console.log("Checked pass " + checkedPassword);
    const response = await axios
      .get(process.env.REACT_APP_API_URL + `User/users/${data.email}`)
      .catch((e) => {
        console.log("Error");
      });
    console.log(response);
    logIn(
      response.data.email,
      response.data.firstName,
      response.data.lastName,
      response.data.county,
      response.data.city,
      response.data.address,
      response.data.admin
    );
    notify(data);
    setTimeout(() => {
      if (response.data.admin) {
        navigate("/adminPage");
      } else {
        navigate("/");
      }
    }, 2000);
    console.log(data);
  };

  return (
    <div className="base-container" style={{ marginTop: "100px" }}>
      <div className="content">
        <div className="image">
          <img src={LoginLogo} alt="" />
        </div>
        <form className="form-group" onSubmit={handleSubmit(onSubmit)}>
          <Grid container spacing={2}>
            <Grid item xs={12} sm={12}>
              <Controller
                name={constants.EMAIL}
                control={control}
                render={({ field }) => (
                  <FormControl>
                    <InputLabel htmlFor="component-simple">
                      {" "}
                      {constants.EMAIL_LABEL}{" "}
                    </InputLabel>
                    <Input
                      {...field}
                      error={!!errors.email || !existantEmail}
                    />
                    {errors.email ? (
                      <FormHelperText error>Ex. name@domain.com</FormHelperText>
                    ) : existantEmail ? (
                      <FormHelperText>Ex. name@domain.com</FormHelperText>
                    ) : (
                      <FormHelperText error>
                        This account does not exist.
                      </FormHelperText>
                    )}
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
                    <InputLabel htmlFor="component-simple">
                      {" "}
                      {constants.PASSWORD_LABEL}{" "}
                    </InputLabel>
                    <Input
                      {...field}
                      error={!!errors.password || !checkedPassword}
                      type="password"
                    />
                    {errors.password ? (
                      <FormHelperText error>
                        Length between 8 and 64 symbols
                      </FormHelperText>
                    ) : checkedPassword ? (
                      <FormHelperText>
                        Length between 8 and 64 symbols
                      </FormHelperText>
                    ) : (
                      <FormHelperText error>Wrong password.</FormHelperText>
                    )}
                  </FormControl>
                )}
              />
            </Grid>
          </Grid>
        </form>
        <ColorButton
          variant="contained"
          type="submit"
          onClick={handleSubmit(onSubmit)}
          style={{ marginTop: "50px" }}
        >
          Login
        </ColorButton>
      </div>
    </div>
  );
};

const mapDispatchToProps = (dispatch) => {
  return {
    logIn: (email, firstName, lastName, county, city, address, admin) =>
      dispatch(logIn(email, firstName, lastName, county, city, address, admin)),
  };
};

export default connect(null, mapDispatchToProps)(Login);
