import { makeStyles } from "@material-ui/core/styles";

export default makeStyles((theme) => ({
  filledCartContainer: {
    display: "flex",
    flexDirection: "row",
    marginRight: "1%",
    [theme.breakpoints.up("xs")]: {
      marginRight: "10px",
    },
  },
  cartContainer: {
    display: "flex",
    flexDirection: "row",
    marginLeft: "1%",
    marginRight: "1.5%",
  },
  compatibilitySection: {
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    justifyContent: "center",
    padding: "10px",
    boxShadow:
      "0px -3px 4px 0px rgba(107, 126, 190, 4%), 0px 8px 16px 0px rgba(107, 126, 190, 16%)",
  },
  compatibilityLabelContainer: {
    display: "flex",
    alignItems: "center",
    justifyContent: "center",
  },
  compatibilityHeader: {
    display: "flex",
    width: "100%",
    alignItems: "center",
    justifyContent: "center",
  },
  compatibilityTitle: {
    display: "flex",
    justifyContent: "center",
    width: "100%",
  },
  compatibilityBody: {
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    justifyContent: "center",
    height: "86%",
  },
  toolbar: theme.mixins.toolbar,
  title: {
    marginTop: "2%",
    marginLeft: "1%",
  },
  emptyButton: {
    minWidth: "150px",
    height: "45px",
    [theme.breakpoints.down("sm")]: {
      marginBottom: "5px",
    },
    [theme.breakpoints.up("xs")]: {
      marginRight: "10px",
    },
  },
  checkoutButton: {
    height: "45px",
    [theme.breakpoints.down("sm")]: {
      marginBottom: "5px",
    },
    [theme.breakpoints.up("xs")]: {
      marginRight: "10px",
    },
    minWidth: "150px",
    backgroundColor: "#046380",
    color: "#fff",
    "&:hover": {
      backgroundColor: "#1b2271",
    },
  },
  link: {
    textDecoration: "none",
  },
  cardDetails: {
    display: "flex",
    marginTop: "10%",
    width: "100%",
    justifyContent: "space-between",
    marginBottom: "50px",
  },
  cardContainer: {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    flexDirection: "column",
  },
  cartHeader: {
    display: "flex",
    width: "100%",
    justifyContent: "space-between",
    alignItems: "center",
    flexDirection: "row",
  },
  buttonsHeader: {
    display: "flex",
  },
}));
