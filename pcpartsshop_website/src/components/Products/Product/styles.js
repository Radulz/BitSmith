import { makeStyles } from "@material-ui/core/styles";

export default makeStyles(() => ({
  root: {
    display: "flex",
    flexDirection: "column",
    maxWidth: "100%",
    minHeight: "430px",
    boxShadow:
      "0px -3px 4px 0px rgba(107, 126, 190, 4%), 0px 8px 16px 0px rgba(107, 126, 190, 16%)",
  },
  media: {
    height: 0,
    PaddingTop: "56.25%", //this means basically 16:9
  },
  cardActions: {
    marginTop: "auto",
    display: "flex",
    justifyContent: "flex-end",
  },
  cardContent: {
    display: "flex",
    justifyContent: "space-between",
  },
}));
