import React, { useState } from "react";
import {
  Button,
  Grid,
  FormControl,
  Input,
  InputLabel,
  FormHelperText,
  Typography,
} from "@material-ui/core";
import useStyles from "../../styles";
import { useForm, Controller } from "react-hook-form";
import * as constants from "../../../../constants/CPUConstants";
import { joiResolver } from "@hookform/resolvers/joi";
import Joi from "joi";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import axios from "axios";
import FileUploadIcon from "@mui/icons-material/FileUpload";

const schema = Joi.object({
  make: Joi.string().required(),
  model: Joi.string().required(),
  price: Joi.number().positive().precision(2).required(),
  image: Joi.required(),
  frequency: Joi.number().precision(2).required(),
  socket: Joi.string().required(),
  technology: Joi.number().integer().required(),
  memoryFrequency: Joi.number().integer().required(),
  thermalDesignPower: Joi.number().integer().required(),
  numberOfCores: Joi.number().integer().required(),
});

const AddCPUForm = () => {
  const {
    control,
    handleSubmit,
    register,
    formState: { errors },
  } = useForm({
    defaultValues: {
      make: "",
      model: "",
      price: "",
      image: "",
      frequency: "",
      socket: "",
      technology: "",
      memoryFrequency: "",
      thermalDesignPower: "",
      numberOfCores: "",
    },
    resolver: joiResolver(schema),
  });
  const classes = useStyles();
  console.log(errors);
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
  const [image, setImage] = useState({ url: "", isRemoved: true });
  const onSubmit = async (data) => {
    console.log(data.image);
    if (image.isRemoved) {
      toast.error("Image upload is required.", {
        position: toast.POSITION.TOP_CENTER,
        autoClose: 5000,
      });
      return;
    }

    const formData = new FormData();
    formData.append("file", data.image[0]);

    const fileResponse = await axios
      .post(process.env.REACT_APP_API_URL + "File", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      })
      .catch((e) => console.log(e));

    const response = await axios
      .post(process.env.REACT_APP_API_URL + "CPU", {
        make: data.make,
        model: data.model,
        price: data.price,
        image: fileResponse?.data?.blob?.uri ?? constants.DEFAULT_CPU_IMAGE,
        frequency: data.frequency,
        socket: data.socket,
        technology: data.technology,
        memoryFrequency: data.memoryFrequency,
        thermalDesignPower: data.thermalDesignPower,
        numberOfCores: data.numberOfCores,
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
                  <FormHelperText>In dollars</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
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
                  <FormHelperText>Decimal number (GHz)</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
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
                  <FormHelperText>ex. LGA1200 </FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
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
        <Grid item xs={12} sm={6} className={classes.gridItem}>
          <Controller
            name={constants.MEMORYFREQUENCY}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.MEMORYFREQUENCY_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.memoryFrequency} />
                {errors.memoryFrequency ? (
                  <FormHelperText error>Number. Field required.</FormHelperText>
                ) : (
                  <FormHelperText>Integer number (MHz)</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
          <Controller
            name={constants.THERMALDESGINPOWER}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.THERMALDESGINPOWER_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.thermalDesignPower} />
                {errors.thermalDesignPower ? (
                  <FormHelperText error>Number. Field required.</FormHelperText>
                ) : (
                  <FormHelperText>Integer number (W)</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
          <Controller
            name={constants.NUMBEROFCORES}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.NUMBEROFCORES_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.numberOfCores} />
                {errors.numberOfCores ? (
                  <FormHelperText error>Number. Field required.</FormHelperText>
                ) : (
                  <FormHelperText>Integer number</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.gridItemUpload}>
          <div>
            <Input
              {...register("image")}
              onChange={(event) => {
                if (event.target.value !== "") {
                  setImage({
                    url: event.target.value.replace(/.*[\/\\]/, ""),
                    isRemoved: false,
                  });
                } else {
                  setImage({
                    url: event.target.value,
                    isRemoved: true,
                  });
                }
              }}
              className={classes.uploadInput}
              type="file"
              id="image"
              inputProps={{ accept: "image/*" }}
            />
            <Button
              className={classes.uploadButton}
              variant="outlined"
              color="primary"
              disableFocusRipple
              disableRipple
            >
              Upload Image
              <FileUploadIcon />
            </Button>
          </div>
          <Typography>{image.url}</Typography>
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

export default AddCPUForm;
