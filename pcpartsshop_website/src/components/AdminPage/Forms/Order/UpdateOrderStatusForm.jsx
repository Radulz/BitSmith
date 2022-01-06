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
import * as constants from "../../../../constants/OrderConstants";
import { joiResolver } from "@hookform/resolvers/joi";
import Joi from "joi";
import axios from "axios";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const schema = Joi.object({
  orderId: Joi.number().integer().required(),
});

const UpdateOrderStatusForm = () => {
  const {
    control,
    handleSubmit,
    formState: { errors },
  } = useForm({
    defaultValues: {
      orderId: "",
    },
    resolver: joiResolver(schema),
  });
  console.log(errors);
  const notify = (response) => {
    if (!response) {
      toast.error("Order not found!", {
        position: toast.POSITION.TOP_CENTER,
        autoClose: false,
      });
    } else if (response.status === 200) {
      toast.success("Order status has been set as shipped.", {
        position: toast.POSITION.TOP_CENTER,
        autoClose: false,
      });
    }
  };
  const onSubmit = async (data) => {
    console.log(data);
    const response = await axios
      .patch(process.env.REACT_APP_API_URL + `Order/${data.orderId}`)
      .catch((e) => console.log(e));
    console.log(response);
    notify(response);
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
            name={constants.ORDERID}
            control={control}
            render={({ field }) => (
              <FormControl>
                <InputLabel htmlFor="component-simple">
                  {" "}
                  {constants.ORDERID_LABEL}{" "}
                </InputLabel>
                <Input {...field} error={!!errors.orderId} fullWidth={true} />
                {errors.orderId ? (
                  <FormHelperText error>
                    Integer. Field required.
                  </FormHelperText>
                ) : (
                  <FormHelperText>Identifier (Integer)</FormHelperText>
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
    </form>
  );
};

export default UpdateOrderStatusForm;
