import React, { useState } from "react";
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
import OrderItemsTable from "./OrderItemsTable";
import UserCardOrder from "./UserCardOrder";

const schema = Joi.object({
  orderId: Joi.number().integer().required(),
});

const SeeOrderDetailsForm = () => {
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
  const [items, setItems] = useState([]);
  const [show, setShow] = useState(false);
  const [user, setUser] = useState(null);
  console.log(errors);
  const notify = (response) => {
    if (!response) {
      toast.error("Order not found!", {
        position: toast.POSITION.TOP_CENTER,
        autoClose: false,
      });
    }
  };
  const onSubmit = async (data) => {
    console.log(data);
    const response = await axios
      .get(process.env.REACT_APP_API_URL + `Order/${data.orderId}`)
      .catch((e) => console.log(e));
    console.log(response);
    let items = [];
    let num = 1;
    if (response) {
      setShow(true);
      setUser(response.data);
      for (const iterator of response.data.items) {
        const item = {
          id: num,
          componentId: iterator.componentId,
          make: iterator.componentMake,
          model: iterator.componentModel,
          price: iterator.componentPrice,
          quantity: iterator.orderItemQuantity,
        };
        items.push(item);
        num++;
      }
      console.log(items);
      setItems(items);
    }
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
      <br />
      {show && user && (
        <div
          style={{
            display: "flex",
            flexDirection: "column",
            marginTop: "25px",
            justifyContent: "center",
          }}
        >
          <UserCardOrder data={user} />
          <OrderItemsTable rows={items} />
        </div>
      )}
    </form>
  );
};

export default SeeOrderDetailsForm;
