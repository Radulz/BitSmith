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
import * as constants from "../../../../constants/SSDConstants";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import axios from "axios";
import FileUploadIcon from "@mui/icons-material/FileUpload";

const schema = Joi.object({
  make: Joi.string().required(),
  model: Joi.string().required(),
  price: Joi.number().positive().precision(2).required(),
  image: Joi.required(),
  capacity: Joi.number().integer().positive().required(),
  connector: Joi.string().required(),
});

const UpdateSSDForm = ({ component, setComponent }) => {
  const {
    control,
    handleSubmit,
    register,
    formState: { errors },
  } = useForm({
    defaultValues: {
      make: component.make,
      model: component.model,
      price: component.price,
      image: "",
      capacity: component.capacity,
      connector: component.connector,
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
    } else if (response.status === 200) {
      toast.success(
        `Component with ID: ${response.data.componentId} was updated successfully.`,
        {
          position: toast.POSITION.TOP_CENTER,
          autoClose: 5000,
        }
      );
    }
    setComponent(null);
  };
  const [image, setImage] = useState({ url: "", isRemoved: true });
  const onSubmit = async (data) => {
    console.log(data.image);
    let fileResponse;
    if (!image.isRemoved) {
      const formData = new FormData();
      formData.append("file", data.image[0]);

      fileResponse = await axios
        .post(process.env.REACT_APP_API_URL + "File", formData, {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        })
        .catch((e) => console.log(e));
    }
    const response = await axios
      .put(process.env.REACT_APP_API_URL + `SSD/${component.componentId}`, {
        make: data.make,
        model: data.model,
        price: data.price,
        image: fileResponse?.data?.blob?.uri ?? component.image,
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
        {component.image !== null && (
          <Grid item xs={12} sm={12} className={classes.gridItem}>
            <img
              src={component.image}
              alt="component"
              style={{ maxWidth: "300px", maxHeight: "300px" }}
            />
          </Grid>
        )}
      </Grid>
      <br />
      <div
        style={{
          display: "flex",
          marginTop: "25px",
          justifyContent: "center",
        }}
      >
        <Button variant="contained" type="submit" color="secondary">
          Update
        </Button>
      </div>
    </form>
  );
};

export default UpdateSSDForm;
