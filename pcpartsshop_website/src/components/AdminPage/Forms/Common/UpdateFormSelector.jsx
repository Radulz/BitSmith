import React from "react";
import UpdateCPUForm from "../CPU/UpdateCPUForm";
import UpdateGPUForm from "../GPU/UpdateGPUForm";
import UpdateMOBOForm from "../MOBO/UpdateMOBOForm";
import UpdatePSUForm from "../PSU/UpdatePSUForm";
import UpdateRAMForm from "../RAM/UpdateRAMForm";
import UpdateCaseForm from "../Case/UpdateCaseForm";
import UpdateCoolerForm from "../Cooler/UpdateCoolerForm";
import UpdateSSDForm from "../SSD/UpdateSSDForm";

const UpdateFormSelector = ({ component, setComponent }) => {
  switch (component.componentType) {
    case "CPU":
      return (
        <UpdateCPUForm component={component} setComponent={setComponent} />
      );
    case "GPU":
      return (
        <UpdateGPUForm component={component} setComponent={setComponent} />
      );
    case "MOBO":
      return (
        <UpdateMOBOForm component={component} setComponent={setComponent} />
      );
    case "PSU":
      return (
        <UpdatePSUForm component={component} setComponent={setComponent} />
      );
    case "RAM":
      return (
        <UpdateRAMForm component={component} setComponent={setComponent} />
      );
    case "CASE":
      return (
        <UpdateCaseForm component={component} setComponent={setComponent} />
      );
    case "COOLER":
      return (
        <UpdateCoolerForm component={component} setComponent={setComponent} />
      );
    case "SSD":
      return (
        <UpdateSSDForm component={component} setComponent={setComponent} />
      );
    default: {
      return null;
    }
  }
};

export default UpdateFormSelector;
