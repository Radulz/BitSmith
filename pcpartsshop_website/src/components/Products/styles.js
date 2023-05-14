import { makeStyles } from "@material-ui/core/styles";

export default makeStyles((theme) => ({
  toolbar: theme.mixins.toolbar,
  content: {
    flexGrow: 1,
    marginTop: "75px",
    padding: "0px 40px 0px 20px",
  },
  root: {
    flexGrow: 1,
  },
  smallContainer: {
    display: "flex",
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "center",
    marginTop: 48,
  },
  dashboardMenu: {
    display: "flex",
    justifyContent: "start",
    alignSelf: "flex-start",
    marginRight: "10px",
  },
  searchFilter: {
    width: "100%",
    backgroundColor: "#fff",
    [theme.breakpoints.between("xs", "sm")]: {
      maxWidth: "100vw",
    },
    boxShadow:
      "0px -3px 4px 0px rgba(107, 126, 190, 4%), 0px 8px 16px 0px rgba(107, 126, 190, 16%)",
  },
}));
