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
import * as constants from "../../../../constants/CaseConstants";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { Select, MenuItem } from "@material-ui/core";
import axios from "axios";

const schema = Joi.object({
  make: Joi.string().required(),
  model: Joi.string().required(),
  price: Joi.number().positive().precision(2).required(),
  image: Joi.string().required(),
  gpuMaximumLength: Joi.number().integer().required(),
  coolerMaximumHeight: Joi.number().integer().required(),
  radiatorSupport: Joi.boolean().required(),
  radiatorSupportLength: Joi.optional(),
  caseType: Joi.string().required(),
  psuPosition: Joi.string().required(),
});

const AddCaseForm = () => {
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
      gpuMaximumLength: "",
      coolerMaximumHeight: "",
      radiatorSupport: "",
      radiatorSupportLength: "",
      caseType: "",
      psuPosition: "",
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
      .post(process.env.REACT_APP_API_URL + "Case", {
        make: data.make,
        model: data.model,
        price: data.price,
        image: data.image,
        gpuMaximumLength: data.gpuMaximumLength,
        coolerMaximumHeight: data.coolerMaximumHeight,
        radiatorSupport: data.radiatorSupport,
        radiatorSupportLength:
          data.radiatorSupportLength === "" ? 0 : data.radiatorSupportLength,
        caseType: data.caseType,
        psuPosition: data.psuPosition,
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
            name={constants.GPUMAXIMUMLENGTH}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.GPUMAXIMUMLENGTH_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.gpuMaximumLength} />
                {errors.gpuMaximumLength ? (
                  <FormHelperText error>Number. Field required.</FormHelperText>
                ) : (
                  <FormHelperText>Integer number (mm)</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
          <Controller
            name={constants.COOLERMAXIMUMHEIGHT}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.COOLERMAXIMUMHEIGHT_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.coolerMaximumHeight} />
                {errors.coolerMaximumHeight ? (
                  <FormHelperText error>Number. Field required.</FormHelperText>
                ) : (
                  <FormHelperText>Integer number (mm)</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
          <Controller
            name={constants.RADIATORSUPPORT}
            control={control}
            render={({ field }) => (
              <FormControl variant="standard">
                <InputLabel htmlFor="component-simple">
                  {constants.RADIATORSUPPORT_LABEL}
                </InputLabel>
                <Select
                  {...field}
                  error={!!errors.radiatorSupport}
                  style={{ minWidth: 195 }}
                >
                  <MenuItem value={true}>Yes</MenuItem>
                  <MenuItem value={false}>No</MenuItem>
                </Select>
                {errors.radiatorSupport ? (
                  <FormHelperText error>
                    Radiator support must be selected.
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
            name={constants.RADIATORSUPPORTLENGTH}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.RADIATORSUPPORTLENGTH_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.radiatorSupportLength} />
                {errors.radiatorSupportLength ? (
                  <FormHelperText error>Number.</FormHelperText>
                ) : (
                  <FormHelperText>In mm. Leave empty if N/A.</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
          <Controller
            name={constants.CASETYPE}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.CASETYPE_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.caseType} />
                {errors.caseType ? (
                  <FormHelperText error>Field required.</FormHelperText>
                ) : (
                  <FormHelperText>E.g. Middle Tower</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
          <Controller
            name={constants.PSUPOSITION}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.PSUPOSITION_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.psuPosition} />
                {errors.psuPosition ? (
                  <FormHelperText error>Field required.</FormHelperText>
                ) : (
                  <FormHelperText>E.g. Bottom</FormHelperText>
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

export default AddCaseForm;
