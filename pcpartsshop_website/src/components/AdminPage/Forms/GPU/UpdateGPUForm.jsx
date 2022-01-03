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
import { joiResolver } from "@hookform/resolvers/joi";
import Joi from "joi";
import * as constants from "../../../../constants/GPUConstants";

const schema = Joi.object({
  componentId: Joi.string().guid().required(),
  make: Joi.string().required(),
  model: Joi.string().required(),
  price: Joi.number().precision(2).required(),
  image: Joi.string().required(),
  frequency: Joi.number().integer().required(),
  memoryCapacity: Joi.number().integer().required(),
  memoryType: Joi.string().required(),
  technology: Joi.number().integer().required(),
  powerConsumption: Joi.number().integer().required(),
  length: Joi.number().integer().required(),
});

const UpdateGPUForm = () => {
  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm({
    defaultValues: {
      componentId: "",
      make: "",
      model: "",
      price: "",
      image: "",
      frequency: "",
      memoryCapacity: "",
      memoryType: "",
      technology: "",
      powerConsumption: "",
      length: "",
    },
    resolver: joiResolver(schema),
  });
  console.log(errors);
  const onSubmit = (data) => {
    console.log(data);
  };
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <Grid container spacing={2}>
        <Grid item xs={12} sm={6}>
          <Controller
            name={constants.COMPONENTID}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {" "}
                  {constants.COMPONENTID_LABEL}{" "}
                </InputLabel>
                <Input {...field} error={!!errors.componentId} />
                {errors.componentId ? (
                  <FormHelperText error>Guid. Field required.</FormHelperText>
                ) : (
                  <FormHelperText>Unique identifier (Guid)</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
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
        <Grid item xs={12} sm={6}>
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
        <Grid item xs={12} sm={6}>
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
        <Grid item xs={12} sm={6}>
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
        <Grid item xs={12} sm={6}>
          <Controller
            name={constants.FREQUENCY}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.FREQUENCY_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.frequency} />
                {errors.frequency ? (
                  <FormHelperText error>Number. Field required.</FormHelperText>
                ) : (
                  <FormHelperText>Integer number (MHz)</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <Controller
            name={constants.MEMORYCAPACITY}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.MEMORYCAPACITY_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.memoryCapacity} />
                {errors.memoryCapacity ? (
                  <FormHelperText error>Number. Field required.</FormHelperText>
                ) : (
                  <FormHelperText>Integer number</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <Controller
            name={constants.MEMORYTYPE}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.MEMORYTYPE_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.memoryType} />
                {errors.memoryType ? (
                  <FormHelperText error>Field required.</FormHelperText>
                ) : (
                  <FormHelperText>ex. GDDR5</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <Controller
            name={constants.TECHNOLOGY}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.TECHNOLOGY_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.technology} />
                {errors.technology ? (
                  <FormHelperText error>Number. Field required.</FormHelperText>
                ) : (
                  <FormHelperText>Integer number (nm)</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <Controller
            name={constants.POWERCONSUMPTION}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.POWERCONSUMPTION_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.powerConsumption} />
                {errors.powerConsumption ? (
                  <FormHelperText error>Number. Field required.</FormHelperText>
                ) : (
                  <FormHelperText>Integer number (W)</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <Controller
            name={constants.LENGTH}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.LENGTH_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.length} />
                {errors.length ? (
                  <FormHelperText error>Number. Field required.</FormHelperText>
                ) : (
                  <FormHelperText>Integer number (mm)</FormHelperText>
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

export default UpdateGPUForm;
