import React, { useState, useEffect } from "react";
import {
  Button,
  Grid,
  FormControl,
  Input,
  InputLabel,
  FormHelperText,
} from "@material-ui/core";
import { useForm, Controller } from "react-hook-form";
import * as constants from "../../../../constants/ComponentConstants";
import { joiResolver } from "@hookform/resolvers/joi";
import Joi from "joi";
import axios from "axios";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import ComponentCard from "./ComponentCard";

const schema = Joi.object({
  componentId: Joi.string().guid().required(),
});

const GetComponentForm = ({ componentType }) => {
  const [component, setComponent] = useState(null);
  const {
    control,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm({
    defaultValues: {
      componentId: "",
    },
    resolver: joiResolver(schema),
  });

  useEffect(() => {
    setComponent(null);
    reset();
  }, [componentType, reset]);

  const notify = () => {
    toast.error("Component not found!", {
      position: toast.POSITION.TOP_CENTER,
      autoClose: 5000,
    });
  };
  const onSubmit = async (data) => {
    try {
      const response = await axios.get(
        process.env.REACT_APP_API_URL + `${componentType}/${data.componentId}`
      );
      if (response.status === 200) {
        setComponent(response.data);
      } else {
        notify();
      }
    } catch (e) {
      console.log(e.status);
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
                  style={{ width: 400 }}
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
      {component ? (
        <ComponentCard product={component} setProduct={setComponent} />
      ) : null}
    </form>
  );
};

export default GetComponentForm;
