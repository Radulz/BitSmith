import React from "react";
import {
  Button,
  Grid,
  FormControl,
  Input,
  InputLabel,
  FormHelperText,
} from "@material-ui/core";
import useStyles from "../../styles";
import { useForm, Controller } from "react-hook-form";
import { joiResolver } from "@hookform/resolvers/joi";
import Joi from "joi";
import * as constants from "../../../../constants/SSDConstants";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import axios from "axios";

const schema = Joi.object({
  make: Joi.string().required(),
  model: Joi.string().required(),
  price: Joi.number().positive().precision(2).required(),
  image: Joi.string().required(),
  capacity: Joi.string().required(),
  connector: Joi.string().required(),
});

const AddSSDForm = () => {
  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm({
    defaultValues: {
      make: "",
      model: "",
      price: "",
      image: "",
      capacity: "",
      connector: "",
    },
    resolver: joiResolver(schema),
  });

  console.log(errors);
  const classes = useStyles();
  const notify = (response) => {
    if (!response) {
      toast.error("Something went wrong.", {
        position: toast.POSITION.TOP_CENTER,
        autoClose: 5000,
      });
    } else if (response.status === 201) {
      toast.success(
        `Component ${response.data.make} ${response.data.model} was created with ID: ${response.data.componentId}`,
        {
          position: toast.POSITION.TOP_CENTER,
          autoClose: 5000,
        }
      );
    }
  };

  const onSubmit = async (data) => {
    console.log(data);
    const response = await axios
      .post(process.env.REACT_APP_API_URL + "SSD", {
        make: data.make,
        model: data.model,
        price: data.price,
        image: data.image,
        capacity: data.capacity,
        connector: data.connector,
      })
      .catch((e) => console.log(e));
    notify(response);
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <Grid container spacing={2}>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
          <Controller
            name={constants.MAKE}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {" "}
                  {constants.MAKE_LABEL}{" "}
                </InputLabel>
                <Input {...field} error={!!errors.make} />
                {errors.make ? (
                  <FormHelperText error>Field required.</FormHelperText>
                ) : (
                  <FormHelperText disabled> </FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
          <Controller
            name={constants.MODEL}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {" "}
                  {constants.MODEL_LABEL}{" "}
                </InputLabel>
                <Input {...field} error={!!errors.model} />
                {errors.model ? (
                  <FormHelperText error>Field required.</FormHelperText>
                ) : (
                  <FormHelperText disabled> </FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
          <Controller
            name={constants.PRICE}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.PRICE_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.price} />
                {errors.price ? (
                  <FormHelperText error>Number. Field required.</FormHelperText>
                ) : (
                  <FormHelperText>Dollars ($)</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
          <Controller
            name={constants.IMAGE}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.IMAGE_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.image} />
                {errors.image ? (
                  <FormHelperText error>URL. Field required.</FormHelperText>
                ) : (
                  <FormHelperText>URL to image</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
          <Controller
            name={constants.CAPCITY}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.CAPCITY_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.capacity} />
                {errors.capacity ? (
                  <FormHelperText error>Integer number</FormHelperText>
                ) : (
                  <FormHelperText>Integer number (GB).</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
          <Controller
            name={constants.CONNECTOR}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.CONNECTOR_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.connector} />
                {errors.connector ? (
                  <FormHelperText error>Field required.</FormHelperText>
                ) : (
                  <FormHelperText>E.g. SATA-III</FormHelperText>
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

export default AddSSDForm;
