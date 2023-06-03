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
import RemoveUserForm from "./Forms/User/RemoveUserForm";
import GetUserForm from "./Forms/User/GetUserForm";
import UpdateUserForm from "./Forms/User/UpdateUserForm";
import GetUserByEmailForm from "./Forms/User/GetUserByEmailForm";
import UpdateUserAsAdmin from "./Forms/User/UpdateUserAsAdmin";
import SeeOrderDetailsForm from "./Forms/Order/SeeOrderDetailsForm";
import UpdateOrderStatusForm from "./Forms/Order/UpdateOrderStatusForm";
import GetAllUsersTable from "./Forms/User/GetAllUsersTable";
import GetAllOrdersForm from "./Forms/Order/GetAllOrdersForm";
import AddCaseForm from "./Forms/Case/AddCaseForm";
import AddCoolerForm from "./Forms/Cooler/AddCoolerForm";
import AddSSDForm from "./Forms/SSD/AddSSDForm";
import UpdateCaseForm from "./Forms/Case/UpdateCaseForm";
import UpdateCoolerForm from "./Forms/Cooler/UpdateCoolerForm";
import UpdateSSDForm from "./Forms/SSD/UpdateSSDForm";
import ComponentsTable from "./Forms/Common/ComponentsTable";
import RemoveComponentForm from "./Forms/Common/RemoveComponentForm";
import GetComponentForm from "./Forms/Common/GetComponentForm";

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
    case "Add Case":
      return <AddCaseForm />;
    case "Add Cooler":
      return <AddCoolerForm />;
    case "Add SSD":
      return <AddSSDForm />;
    case "Add User":
      return <AddUserForm />;
    case "Remove CPU":
      return <RemoveComponentForm componentType={"CPU"} />;
    case "Remove GPU":
      return <RemoveComponentForm componentType={"GPU"} />;
    case "Remove Motherboard":
      return <RemoveComponentForm componentType={"MOBO"} />;
    case "Remove Power Unit":
      return <RemoveComponentForm componentType={"PSU"} />;
    case "Remove RAM Stick":
      return <RemoveComponentForm componentType={"RAM"} />;
    case "Remove Case":
      return <RemoveComponentForm componentType={"Case"} />;
    case "Remove Cooler":
      return <RemoveComponentForm componentType={"Cooler"} />;
    case "Remove SSD":
      return <RemoveComponentForm componentType={"SSD"} />;
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
    case "Update Case":
      return <UpdateCaseForm />;
    case "Update Cooler":
      return <UpdateCoolerForm />;
    case "Update SSD":
      return <UpdateSSDForm />;
    case "Update User":
      return <UpdateUserForm />;
    case "Get CPU":
      return <GetComponentForm componentType={"CPU"} />;
    case "Get GPU":
      return <GetComponentForm componentType={"GPU"} />;
    case "Get Motherboard":
      return <GetComponentForm componentType={"MOBO"} />;
    case "Get Power Unit":
      return <GetComponentForm componentType={"PSU"} />;
    case "Get RAM Stick":
      return <GetComponentForm componentType={"RAM"} />;
    case "Get Case":
      return <GetComponentForm componentType={"Case"} />;
    case "Get Cooler":
      return <GetComponentForm componentType={"Cooler"} />;
    case "Get SSD":
      return <GetComponentForm componentType={"SSD"} />;
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
      return <ComponentsTable componentType={"CPU"} />;
    case "Get all GPUs":
      return <ComponentsTable componentType={"GPU"} />;
    case "Get all Motherboards":
      return <ComponentsTable componentType={"MOBO"} />;
    case "Get all Power Units":
      return <ComponentsTable componentType={"PSU"} />;
    case "Get all RAM Sticks":
      return <ComponentsTable componentType={"RAM"} />;
    case "Get all Cases":
      return <ComponentsTable componentType={"Case"} />;
    case "Get all Coolers":
      return <ComponentsTable componentType={"Cooler"} />;
    case "Get all SSDs":
      return <ComponentsTable componentType={"SSD"} />;
    case "Get all Users":
      return <GetAllUsersTable />;
    case "Get all Orders details":
      return <GetAllOrdersForm />;
    default:
      return null;
  }
};

export default FormSelector;
