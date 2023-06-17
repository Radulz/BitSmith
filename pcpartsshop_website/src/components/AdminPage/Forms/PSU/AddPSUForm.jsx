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
import { joiResolver } from "@hookform/resolvers/joi";
import Joi from "joi";
import * as constants from "../../../../constants/PSUConstants";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import axios from "axios";
import FileUploadIcon from "@mui/icons-material/FileUpload";

const schema = Joi.object({
  make: Joi.string().required(),
  model: Joi.string().required(),
  price: Joi.number().positive().precision(2).required(),
  image: Joi.required(),
  power: Joi.number().integer().required(),
  modularity: Joi.string().required(),
});

const AddPSUForm = () => {
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
      power: "",
      modularity: "",
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
      .post(process.env.REACT_APP_API_URL + "PSU", {
        make: data.make,
        model: data.model,
        price: data.price,
        image: fileResponse?.data?.blob?.uri ?? constants.DEFAULT_PSU_IMAGE,
        power: data.power,
        modularity: data.modularity,
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
            name={constants.POWER}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.POWER_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.power} />
                {errors.power ? (
                  <FormHelperText error>Field required.</FormHelperText>
                ) : (
                  <FormHelperText>Integer number. (W)</FormHelperText>
                )}
              </FormControl>
            )}
          />
        </Grid>
        <Grid item xs={12} sm={6} className={classes.gridItem}>
          <Controller
            name={constants.MODULARITY}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {constants.MODULARITY_LABEL}
                </InputLabel>
                <Input {...field} error={!!errors.modularity} />
                {errors.modularity ? (
                  <FormHelperText error>Field required.</FormHelperText>
                ) : (
                  <FormHelperText>ex. Semi-Modular </FormHelperText>
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

export default AddPSUForm;
