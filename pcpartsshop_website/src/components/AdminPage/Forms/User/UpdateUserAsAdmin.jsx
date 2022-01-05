import React from "react";
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
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const schema = Joi.object({
  userId: Joi.string().guid().required(),
});

const UpdateUserAsAdmin = () => {
  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm({
    defaultValues: {
      userId: "",
    },
    resolver: joiResolver(schema),
  });
  console.log(errors);
  const notify = (response) => {
    if (!response) {
      toast.error("User not found!", {
        position: toast.POSITION.TOP_CENTER,
        autoClose: false,
      });
    } else if (response.status === 200) {
      toast.success("User is now admin.", {
        position: toast.POSITION.TOP_CENTER,
        autoClose: false,
      });
    }
  };
  const onSubmit = async (data) => {
    console.log(data);
    const response = await axios
      .patch(process.env.REACT_APP_API_URL + `User/${data.userId}`)
      .catch((e) => console.log(e));
    console.log(response);
    notify(response);
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
            name={constants.USERID}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {" "}
                  {constants.USERID_LABEL}{" "}
                </InputLabel>
                <Input {...field} error={!!errors.userId} fullWidth={true} />
                {errors.userId ? (
                  <FormHelperText error>Guid. Field required.</FormHelperText>
                ) : (
                  <FormHelperText>Unique identifier (Guid)</FormHelperText>
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
    </form>
  );
};

export default UpdateUserAsAdmin;
