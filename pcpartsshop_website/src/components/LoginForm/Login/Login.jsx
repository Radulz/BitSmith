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
import { useForm, FormProvider } from "react-hook-form";
import axios from "axios";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { logIn } from "../../../redux/User/user-actions";
import { connect } from "react-redux";
import { useNavigate } from "react-router-dom";

const Login = ({ logIn }) => {
  const [existantEmail, setExistantEmail] = useState(true);
  const [checkedPassword, setCheckedPassword] = useState(true);
  const { register, handleSubmit } = useForm({ criteriaMode: "all" });
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
        autoClose: 3000,
      });
    } else {
      toast.error("Something went wrong.", {
        position: toast.POSITION.TOP_CENTER,
        autoClose: 3000,
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
      response.data.address1,
      response.data.admin
    );
    notify(data);
    setTimeout(() => {
      if (response.data.admin) {
        navigate("/adminPage");
      } else {
        navigate("/");
      }
    }, 3000);
    console.log(data);
  };

  return (
    <div className="base-container" style={{ marginTop: "100px" }}>
      {/* <div className="header">Login</div> */}
      <div className="content">
        <div className="image">
          <img src={LoginLogo} alt="" />
        </div>

        <FormProvider>
          <form className="form-group" onSubmit={handleSubmit(onSubmit)}>
            <Grid container spacing={2}>
              <Grid item xs={12} sm={12}>
                {existantEmail ? (
                  <FormControl>
                    <InputLabel htmlFor="component-simple">Email</InputLabel>
                    <Input
                      id="email"
                      fullWidth
                      {...register("email", {
                        required: true,
                        maxLength: 50,
                      })}
                    />
                  </FormControl>
                ) : (
                  <FormControl>
                    <InputLabel htmlFor="component-simple">Email</InputLabel>
                    <Input
                      id="email"
                      fullWidth
                      error
                      {...register("email", {
                        required: true,
                        maxLength: 50,
                      })}
                      onChange={(e) => {
                        setExistantEmail(true);
                      }}
                    />
                    <FormHelperText id="component-error-text">
                      This account doesn't exist.
                    </FormHelperText>
                  </FormControl>
                )}
              </Grid>
              <Grid item xs={12} sm={12}>
                {checkedPassword ? (
                  <FormControl>
                    <InputLabel htmlFor="component-simple">Password</InputLabel>
                    <Input
                      id="password"
                      type="password"
                      fullWidth
                      {...register("password", {
                        required: true,
                        maxLength: 20,
                      })}
                    />
                  </FormControl>
                ) : (
                  <FormControl>
                    <InputLabel htmlFor="component-simple">Password</InputLabel>
                    <Input
                      id="password"
                      type="password"
                      error
                      fullWidth
                      {...register("password", {
                        required: true,
                        maxLength: 20,
                      })}
                      onChange={(e) => setCheckedPassword(true)}
                    />
                    <FormHelperText id="component-error-text">
                      Wrong password.
                    </FormHelperText>
                  </FormControl>
                )}
              </Grid>
            </Grid>
          </form>
        </FormProvider>
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
