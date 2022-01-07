import { makeStyles } from "@material-ui/core/styles";

export default makeStyles((theme) => ({
  toolbar: theme.mixins.toolbar,
  content: {
    flexGrow: 1,
    backgroundColor: theme.palette.background.default,
    padding: theme.spacing(3),
  },
  root: {
    flexGrow: 1,
  },
  smallContainer: {
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    justifyContent: "center",
    marginTop: 48,
  },
  dashboardMenu: {
    display: "flex",
    justifyContent: "center",
    flexDirection: "column",
  },
  // container: {
  //   display: "block",
  //   position: "relative",
  // },
}));
