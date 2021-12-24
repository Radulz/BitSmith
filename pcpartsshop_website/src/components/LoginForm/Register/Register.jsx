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
import { Link } from "react-router-dom";
import axios from "axios";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

toast.configure();

const Register = (props) => {
  const { register, handleSubmit } = useForm({ criteriaMode: "all" });
  const [validEmail, setValidEmail] = useState(true);
  const [existantEmail, setExistantEmail] = useState(null);
  const [validPassword, setValidPassword] = useState(true);
  const [matchPassword, setMatchPassword] = useState(true);

  const notify = (response) => {
    if (response) {
      toast.success("Registration Successful!", {
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

  const validateEmail = (email) => {
    const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(email);
  };

  const validatePassword = (pass) => {
    if (pass.length < 8) {
      return false;
    }
    return true;
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
        `https://localhost:44326/User/userByEmail/${email}`
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
    if (!validateEmail(data.email)) {
      setValidEmail(false);
      sw = false;
      return;
    }
    const emailExistant = await validateExistantEmail(data.email);
    if (emailExistant) {
      setExistantEmail(true);
      sw = false;
      return;
    }
    if (!validatePassword(data.password)) {
      setValidPassword(false);
      sw = false;
      return;
    }
    if (!validatePasswords(data.password, data.confirmpassword)) {
      setMatchPassword(false);
      sw = false;
      return;
    }
    if (sw) {
      setExistantEmail(false);
      const response = await axios.post("https://localhost:44326/User", {
        email: data.email,
        password: data.password,
        firstName: data.firstName,
        lastName: data.lastName,
        city: data.city,
        county: data.county,
        address1: data.address,
        admin: false,
      });
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
      {/* <div className="header">Register</div> */}
      <div className="content">
        <div className="image">
          <img src={LoginLogo} alt="logo" />
        </div>
        <FormProvider>
          <form className="form-group" onSubmit={handleSubmit(onSubmit)}>
            <Grid container spacing={1}>
              <Grid item xs={12} sm={12}>
                {validEmail ? (
                  !existantEmail ? (
                    <FormControl>
                      <InputLabel htmlFor="component-simple">Email</InputLabel>
                      <Input
                        id="email"
                        fullWidth
                        {...register("email", {
                          required: true,
                          maxLength: 20,
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
                          maxLength: 20,
                        })}
                        onChange={(e) => {
                          setValidEmail(true);
                          setExistantEmail(null);
                        }}
                      />
                      <FormHelperText id="component-error-text">
                        Email already exists
                      </FormHelperText>
                    </FormControl>
                  )
                ) : (
                  <FormControl>
                    <InputLabel htmlFor="component-simple">Email</InputLabel>
                    <Input
                      id="email"
                      fullWidth
                      error
                      {...register("email", {
                        required: true,
                        maxLength: 20,
                      })}
                      onChange={(e) => {
                        setValidEmail(true);
                        setExistantEmail(null);
                      }}
                    />
                    <FormHelperText id="component-error-text">
                      Invalid email
                    </FormHelperText>
                  </FormControl>
                )}
              </Grid>
              <Grid item xs={12} sm={12}>
                <FormControl>
                  <InputLabel htmlFor="component-simple">First Name</InputLabel>
                  <Input
                    id="firstName"
                    fullWidth
                    {...register("firstName", {
                      required: true,
                      maxLength: 20,
                    })}
                  />
                </FormControl>
              </Grid>
              <Grid item xs={12} sm={12}>
                <FormControl>
                  <InputLabel htmlFor="component-simple">Last Name</InputLabel>
                  <Input
                    id="lastName"
                    {...register("lastName", { required: true, maxLength: 32 })}
                  />
                </FormControl>
              </Grid>
              <Grid item xs={12} sm={12}>
                <FormControl>
                  <InputLabel htmlFor="component-simple">County</InputLabel>
                  <Input
                    id="county"
                    {...register("county", { required: true, maxLength: 20 })}
                  />
                </FormControl>
              </Grid>
              <Grid item xs={12} sm={12}>
                <FormControl>
                  <InputLabel htmlFor="component-simple">City</InputLabel>
                  <Input
                    id="city"
                    {...register("city", { required: true, maxLength: 20 })}
                  />
                </FormControl>
              </Grid>
              <Grid item xs={12} sm={12}>
                <FormControl>
                  <InputLabel htmlFor="component-simple">Address</InputLabel>
                  <Input
                    id="address"
                    fullWidth
                    {...register("address", {
                      required: true,
                      maxLength: 100,
                    })}
                  />
                </FormControl>
              </Grid>
              <Grid item xs={12} sm={12}>
                <FormControl>
                  <InputLabel htmlFor="standard-password">Password</InputLabel>
                  {validPassword ? (
                    <Input
                      id="password"
                      type="password"
                      fullWidth
                      {...register("password", {
                        required: true,
                        maxLength: 100,
                        minLength: 8,
                      })}
                    />
                  ) : (
                    <Input
                      id="password"
                      type="password"
                      error
                      fullWidth
                      {...register("password", {
                        required: true,
                        maxLength: 100,
                        minLength: 8,
                      })}
                    />
                  )}
                  <FormHelperText id="passwordHelper">
                    Minimum 8 characters
                  </FormHelperText>
                </FormControl>
              </Grid>
              <Grid item xs={12} sm={12}>
                {matchPassword ? (
                  <FormControl>
                    <InputLabel htmlFor="component-simple">
                      Confirm Password
                    </InputLabel>
                    <Input
                      id="confirmpassword"
                      type="password"
                      fullWidth
                      {...register("confirmpassword", {
                        required: true,
                        maxLength: 100,
                        minLength: 8,
                      })}
                    />
                  </FormControl>
                ) : (
                  <FormControl>
                    <InputLabel htmlFor="component-simple">
                      Confirm Password
                    </InputLabel>
                    <Input
                      id="confirmpassword"
                      type="password"
                      fullWidth
                      error
                      {...register("confirmpassword", {
                        required: true,
                        maxLength: 100,
                        minLength: 8,
                      })}
                      onChange={(e) => setMatchPassword(true)}
                    />
                    <FormHelperText>Passwords must match</FormHelperText>
                  </FormControl>
                )}
              </Grid>
            </Grid>
          </form>
        </FormProvider>
        <ColorButton
          variant="contained"
          style={{ marginTop: "25px" }}
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
