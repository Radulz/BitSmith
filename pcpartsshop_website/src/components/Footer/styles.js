import { makeStyles } from "@material-ui/core/styles";

export default makeStyles((theme) => ({
  footer: {
    display: "flex",
    flexDirection: "column",
    backgroundColor: "#046380",
    borderTop: "1px solid white",
    marginTop: "4rem",
    paddingTop: "1rem",
    paddingBottom: "1rem",
    paddingLeft: "0px",
    margin: "-8px",
    overflow: "hidden",
    "& a": {
      color: "#FFF",
      textDecoration: "none",
    },
    "& h4": {
      color: "#FFF",
    },
    "& h5": {
      color: "#FFF",
    },
  },

  footerSection: {
    paddingLeft: "5rem",
    display: "flex",
    flexDirection: "row",
    borderBottom: "2px solid white",
    margin: "0px",
    width: "100%",
  },

  footerLinks: {
    display: "flex",
    justifyContent: "flex-start",
    alignItems: "flex-start",
    flexDirection: "column",
    flexWrap: "wrap",
    width: "100%",
    textAlign: "left",
    marginBottom: "2rem",
  },

  socialLinks: {
    width: "150px",
    display: "flex",
    justifyContent: "flex-start",
    flexDirection: "column",
    color: "black",
  },

  socialMedia: {
    display: "flex",
    flexDirection: "row",
  },

  socialMediaIcon: {
    height: "40px",
    width: "40px",
    marginRight: "5px",
  },

  footerBelow: {
    display: "flex",
    flexDirection: "row",
    justifyContent: "center",
    marginTop: "0.2rem",
  },

  footerBelowLinks: {
    display: "flex",
    flexDirection: "row",
    justifyContent: "space-between",
    paddingBottom: "1rem",
  },

  termsSection: {
    paddingTop: "2rem",
    paddingRight: "4rem",
    paddingLeft: "4rem",
  },
}));
