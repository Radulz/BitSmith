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
import * as constants from "../../../../constants/RAMConstants";
import { joiResolver } from "@hookform/resolvers/joi";
import Joi from "joi";
import axios from "axios";
import RAMCard from "./RAMCard";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const schema = Joi.object({
  componentId: Joi.string().guid().required(),
});

const GetRAMForm = () => {
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
  const [ram, setRam] = useState(null);
  const notify = () => {
    toast.error("Component not found!", {
      position: toast.POSITION.TOP_CENTER,
      autoClose: false,
    });
  };
  const onSubmit = async (data) => {
    console.log(data);
    const response = await axios
      .get(process.env.REACT_APP_API_URL + `RAM/${data.componentId}`)
      .catch((e) => console.log(e));
    console.log(response);
    if (response.data) {
      setRam(response.data);
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
      {ram ? <RAMCard product={ram} setProduct={setRam} /> : null}
    </form>
  );
};

export default GetRAMForm;
