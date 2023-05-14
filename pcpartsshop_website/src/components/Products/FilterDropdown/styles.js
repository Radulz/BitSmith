import { makeStyles } from "@material-ui/core/styles";

export default makeStyles((theme) => ({
  filterDropdown: {
    width: "100%",
    backgroundColor: "#fff",
    [theme.breakpoints.between("xs", "sm")]: {
      maxWidth: "100vw",
    },
    boxShadow:
      "0px -3px 4px 0px rgba(107, 126, 190, 4%), 0px 8px 16px 0px rgba(107, 126, 190, 16%)",
  },
  subListItem: {
    background: "#fff",
  },
}));
