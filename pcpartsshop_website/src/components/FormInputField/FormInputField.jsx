import React from "react";
import { FormControl, Input, InputLabel, Grid } from "@material-ui/core";

const FormInputField = ({
  name,
  labelText,
  register,
  defaultValue,
  isLoggedIn,
}) => {
  return (
    <Grid item xs={12} sm={6}>
      <FormControl>
        <InputLabel htmlFor="component-simple">{labelText}</InputLabel>
        {!isLoggedIn ? (
          <Input
            id="component-simple"
            fullWidth
            {...register(name, { required: true, maxLength: 50 })}
          />
        ) : (
          <Input
            id="component-simple"
            defaultValue={defaultValue}
            fullWidth
            {...register(name, { required: true, maxLength: 50 })}
          />
        )}
      </FormControl>
    </Grid>
  );
};

export default FormInputField;
