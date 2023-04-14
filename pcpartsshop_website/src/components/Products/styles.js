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
  // container: {
  //   display: "block",
  //   position: "relative",
  // },
}));
