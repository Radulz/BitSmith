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
import * as constants from "../../../../constants/CoolerConstants";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { Select, MenuItem } from "@material-ui/core";
import axios from "axios";

const schema = Joi.object({
  make: Joi.string().required(),
  model: Joi.string().required(),
  price: Joi.number().positive().precision(2).required(),
  image: Joi.string().required(),
  height: Joi.optional(),
  coolingType: Joi.string().required(),
  radiatorLength: Joi.optional(),
  numberOfHeatPipes: Joi.optional(),
});

const AddCoolerForm = () => {
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
      height: "",
      coolingType: "",
      radiatorLength: "",
      numberOfHeatPipes: "",
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
      .post(process.env.REACT_APP_API_URL + "Cooler", {
        make: data.make,
        model: data.model,
        price: data.price,
        image: data.image,
        height: data.height === "" ? 0 : data.height,
        coolingType: data.coolingType,
        radiatorLength: data.radiatorLength === "" ? 0 : data.radiatorLength,
        numberOfHeatPipes:
          data.numberOfHeatPipes === "" ? 0 : data.numberOfHeatPipes,
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
            name={constants.HEIGHT}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.HEIGHT_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.height} />
                {errors.height ? (
                  <FormHelperText error>Number</FormHelperText>
                ) : (
                  <FormHelperText>
                    Number in mm. Leave empty if N/A.
                  </FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
          <Controller
            name={constants.COOLINGTYPE}
            control={control}
            render={({ field }) => (
              <FormControl variant="standard">
                <InputLabel htmlFor="component-simple">
                  {constants.COOLINGTYPE_LABEL}
                </InputLabel>
                <Select
                  {...field}
                  error={!!errors.coolingType}
                  style={{ minWidth: 195 }}
                >
                  <MenuItem value={"Air"}>Air</MenuItem>
                  <MenuItem value={"Liquid"}>Liquid</MenuItem>
                </Select>
                {errors.coolingType ? (
                  <FormHelperText error>
                    Cooling type must be selected.
                  </FormHelperText>
                ) : (
                  <FormHelperText>Select one option from above.</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
          <Controller
            name={constants.RADIATORLENGTH}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.RADIATORLENGTH_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.radiatorLength} />
                {errors.radiatorLength ? (
                  <FormHelperText error>Number.</FormHelperText>
                ) : (
                  <FormHelperText>
                    Number (mm). Leave empty if N/A.
                  </FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
          <Controller
            name={constants.NUMBEROFHEATPIPES}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.NUMBEROFHEATPIPES_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.numberOfHeatPipes} />
                {errors.numberOfHeatPipes ? (
                  <FormHelperText error>Number.</FormHelperText>
                ) : (
                  <FormHelperText>Number. Leave empty if N/A.</FormHelperText>
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

export default AddCoolerForm;
