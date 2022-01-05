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
import * as constants from "../../../../constants/PSUConstants";
import { joiResolver } from "@hookform/resolvers/joi";
import Joi from "joi";
import axios from "axios";
import PSUCard from "./PSUCard";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const schema = Joi.object({
  componentId: Joi.string().guid().required(),
});

const GetPSUForm = () => {
  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm({
    defaultValues: {
      componentId: "",
    },
    resolver: joiResolver(schema),
  });
  console.log(errors);
  const [psu, setPsu] = useState(null);
  const notify = () => {
    toast.error("Component not found!", {
      position: toast.POSITION.TOP_CENTER,
      autoClose: false,
    });
  };
  const onSubmit = async (data) => {
    console.log(data);
    const response = await axios
      .get(process.env.REACT_APP_API_URL + `PSU/${data.componentId}`)
      .catch((e) => console.log(e));
    console.log(response);
    if (response.data) {
      setPsu(response.data);
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
            name={constants.COMPONENTID}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {" "}
                  {constants.COMPONENTID_LABEL}{" "}
                </InputLabel>
                <Input
                  {...field}
                  error={!!errors.componentId}
                  fullWidth={true}
                />
                {errors.componentId ? (
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
      <br />
      {psu ? <PSUCard product={psu} setProduct={setPsu} /> : null}
    </form>
  );
};

export default GetPSUForm;
