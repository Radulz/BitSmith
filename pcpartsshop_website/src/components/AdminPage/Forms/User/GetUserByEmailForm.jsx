import React, { useState } from "react";
import {
  Button,
  Grid,
  FormControl,
  Input,
  InputLabel,
  FormHelperText,
} from "@material-ui/core";
import { useForm, Controller } from "react-hook-form";
import * as constants from "../../../../constants/UserConstants";
import { joiResolver } from "@hookform/resolvers/joi";
import Joi from "joi";
import axios from "axios";
import UserCard from "./UserCard";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const schema = Joi.object({
  email: Joi.string()
    .email({ tlds: { allow: false } })
    .required(),
});

const GetUserByEmailForm = () => {
  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm({
    defaultValues: {
      email: "",
    },
    resolver: joiResolver(schema),
  });
  console.log(errors);
  const [user, setUser] = useState(null);
  const notify = () => {
    toast.error("User not found!", {
      position: toast.POSITION.TOP_CENTER,
      autoClose: false,
    });
  };
  const onSubmit = async (data) => {
    console.log(data);
    const response = await axios
      .get(process.env.REACT_APP_API_URL + `User/users/${data.email}`)
      .catch((e) => console.log(e));
    console.log(response);
    if (response.data) {
      setUser(response.data);
    } else {
      notify();
    }
  };
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <div
        style={{
          display: "flex",
          justifyContent: "center",
        }}
      >
        <Grid item>
          <Controller
            name={constants.EMAIL}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {" "}
                  {constants.EMAIL_LABEL}{" "}
                </InputLabel>
                <Input {...field} error={!!errors.email} fullWidth={true} />
                {errors.email ? (
                  <FormHelperText error>Email. Field required.</FormHelperText>
                ) : (
                  <FormHelperText>ex. name@domain.com</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
      </div>
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
      <br />
      {user ? <UserCard user={user} setUser={setUser} /> : null}
    </form>
  );
};

export default GetUserByEmailForm;
