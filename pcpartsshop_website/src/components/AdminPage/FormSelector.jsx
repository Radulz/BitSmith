import React from "react";
import AddCPUForm from "./Forms/CPU/AddCPUForm";
import UpdateCPUForm from "./Forms/CPU/UpdateCPUForm";
import AddGPUForm from "./Forms/GPU/AddGPUForm";
import UpdateGPUForm from "./Forms/GPU/UpdateGPUForm";
import AddMOBOForm from "./Forms/MOBO/AddMOBOForm";
import UpdateMOBOForm from "./Forms/MOBO/UpdateMOBOForm";
import AddPSUForm from "./Forms/PSU/AddPSUForm";
import UpdatePSUForm from "./Forms/PSU/UpdatePSUForm";
import AddRAMForm from "./Forms/RAM/AddRAMForm";
import UpdateRAMForm from "./Forms/RAM/UpdateRAMForm";
import AddUserForm from "./Forms/User/AddUserForm";
import UpdateUserForm from "./Forms/User/UpdateUserForm";

const FormSelector = ({ formKeyword }) => {
  switch (formKeyword) {
    case "Add CPU":
      return <AddCPUForm />;
    case "Add GPU":
      return <AddGPUForm />;
    case "Add Motherboard":
      return <AddMOBOForm />;
    case "Add Power Unit":
      return <AddPSUForm />;
    case "Add RAM Stick":
      return <AddRAMForm />;
    case "Add User":
      return <AddUserForm />;
    case "Update CPU":
      return <UpdateCPUForm />;
    case "Update GPU":
      return <UpdateGPUForm />;
    case "Update Motherboard":
      return <UpdateMOBOForm />;
    case "Update Power Unit":
      return <UpdatePSUForm />;
    case "Update RAM Stick":
      return <UpdateRAMForm />;
    case "Update User":
      return <UpdateUserForm />;
    default:
      return null;
  }
};

export default FormSelector;
