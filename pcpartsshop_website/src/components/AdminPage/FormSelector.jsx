import React from "react";
import AddCPUForm from "./Forms/CPU/AddCPUForm";
import RemoveCPUForm from "./Forms/CPU/RemoveCPUForm";
import GetCPUForm from "./Forms/CPU/GetCPUForm";
import UpdateCPUForm from "./Forms/CPU/UpdateCPUForm";
import AddGPUForm from "./Forms/GPU/AddGPUForm";
import RemoveGPUForm from "./Forms/GPU/RemoveGPUForm";
import GetGPUForm from "./Forms/GPU/GetGPUForm";
import UpdateGPUForm from "./Forms/GPU/UpdateGPUForm";
import AddMOBOForm from "./Forms/MOBO/AddMOBOForm";
import RemoveMOBOForm from "./Forms/MOBO/RemoveMOBOForm";
import GetMOBOForm from "./Forms/MOBO/GetMOBOForm";
import UpdateMOBOForm from "./Forms/MOBO/UpdateMOBOForm";
import AddPSUForm from "./Forms/PSU/AddPSUForm";
import RemovePSUForm from "./Forms/PSU/RemovePSUForm";
import GetPSUForm from "./Forms/PSU/GetPSUForm";
import UpdatePSUForm from "./Forms/PSU/UpdatePSUForm";
import AddRAMForm from "./Forms/RAM/AddRAMForm";
import RemoveRAMForm from "./Forms/RAM/RemoveRAMForm";
import GetRAMForm from "./Forms/RAM/GetRAMForm";
import UpdateRAMForm from "./Forms/RAM/UpdateRAMForm";
import AddUserForm from "./Forms/User/AddUserForm";
import RemoveUserForm from "./Forms/User/RemoveUserForm";
import GetUserForm from "./Forms/User/GetUserForm";
import UpdateUserForm from "./Forms/User/UpdateUserForm";
import GetUserByEmailForm from "./Forms/User/GetUserByEmailForm";
import UpdateUserAsAdmin from "./Forms/User/UpdateUserAsAdmin";
import SeeOrderDetailsForm from "./Forms/Order/SeeOrderDetailsForm";
import UpdateOrderStatusForm from "./Forms/Order/UpdateOrderStatusForm";
import GetAllCPUsTable from "./Forms/CPU/GetAllCPUsTable";
import GetAllGPUsTable from "./Forms/GPU/GetAllGPUsTable";
import GetAllMOBOsTable from "./Forms/MOBO/GetAllMOBOsTable";
import GetAllPSUsTable from "./Forms/PSU/GetAllPSUsTable";
import GetAllRAMsTable from "./Forms/RAM/GetAllRAMsTable";
import GetAllUsersTable from "./Forms/User/GetAllUsersTable";
import GetAllOrdersForm from "./Forms/Order/GetAllOrdersForm";

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
    case "Remove CPU":
      return <RemoveCPUForm />;
    case "Remove GPU":
      return <RemoveGPUForm />;
    case "Remove Motherboard":
      return <RemoveMOBOForm />;
    case "Remove Power Unit":
      return <RemovePSUForm />;
    case "Remove RAM Stick":
      return <RemoveRAMForm />;
    case "Remove User":
      return <RemoveUserForm />;
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
    case "Get CPU":
      return <GetCPUForm />;
    case "Get GPU":
      return <GetGPUForm />;
    case "Get Motherboard":
      return <GetMOBOForm />;
    case "Get Power Unit":
      return <GetPSUForm />;
    case "Get RAM Stick":
      return <GetRAMForm />;
    case "Get User":
      return <GetUserForm />;
    case "Get User by email":
      return <GetUserByEmailForm />;
    case "Update User as admin":
      return <UpdateUserAsAdmin />;
    case "Get Order details":
      return <SeeOrderDetailsForm />;
    case "Update Order status":
      return <UpdateOrderStatusForm />;
    case "Get all CPUs":
      return <GetAllCPUsTable />;
    case "Get all GPUs":
      return <GetAllGPUsTable />;
    case "Get all Motherboards":
      return <GetAllMOBOsTable />;
    case "Get all Power Units":
      return <GetAllPSUsTable />;
    case "Get all RAM Sticks":
      return <GetAllRAMsTable />;
    case "Get all Users":
      return <GetAllUsersTable />;
    case "Get all Orders details":
      return <GetAllOrdersForm />;
    default:
      return null;
  }
};

export default FormSelector;
