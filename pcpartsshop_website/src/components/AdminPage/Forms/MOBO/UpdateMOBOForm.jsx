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
import * as constants from "../../../../constants/MOBOConstants";

const schema = Joi.object({
  componentId: Joi.string().guid().required(),
  make: Joi.string().required(),
  model: Joi.string().required(),
  price: Joi.number().precision(2).required(),
  image: Joi.string().required(),
  socket: Joi.string().required(),
  format: Joi.string().required(),
  chipset: Joi.string().required(),
  lowestFrequencySupported: Joi.number().integer().required(),
  highestFrequencySupported: Joi.number().integer().required(),
  memoryType: Joi.string().required(),
});

const UpdateMOBOForm = () => {
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
      socket: "",
      format: "",
      chipset: "",
      lowestFrequencySupported: "",
      highestFrequencySupported: "",
      memoryType: "",
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
                  <FormHelperText>In dollars</FormHelperText>
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
            name={constants.SOCKET}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.SOCKET_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.socket} />
                {errors.socket ? (
                  <FormHelperText error>Field required.</FormHelperText>
                ) : (
                  <FormHelperText>ex. LGA1200</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <Controller
            name={constants.FORMAT}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.FORMAT_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.format} />
                {errors.format ? (
                  <FormHelperText error>Field required.</FormHelperText>
                ) : (
                  <FormHelperText>ex. ATX </FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <Controller
            name={constants.CHIPSET}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.CHIPSET_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.chipset} />
                {errors.chipset ? (
                  <FormHelperText error>Field required.</FormHelperText>
                ) : (
                  <FormHelperText>ex. B550</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6}>
          <Controller
            name={constants.LOWESTFREQUENCYSUPPORTED}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.LOWESTFREQUENCYSUPPORTED_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.lowestFrequencySupported} />
                {errors.lowestFrequencySupported ? (
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
            name={constants.HIGHESTFREQUENCYSUPPORTED}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.HIGHESTFREQUENCYSUPPORTED_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.highestFrequencySupported} />
                {errors.highestFrequencySupported ? (
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
                  <FormHelperText>ex. DDR4</FormHelperText>
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

export default UpdateMOBOForm;
