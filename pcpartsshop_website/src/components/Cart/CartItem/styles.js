import { makeStyles } from "@material-ui/core/styles";

export default makeStyles(() => ({
  media: {
    height: 200,
  },
  cardContent: {
    display: "flex",
    justifyContent: "space-between",
  },
  cartActions: {
    marginTop: "auto",
    display: "flex",
    justifyContent: "space-between",
  },
  cartActionsDivLeft: {
    marginTop: "auto",
    marginBottom: "auto",
    display: "flex",
    justifyContent: "flex-start",
    marginRight: "auto",
  },
  cartActionsDivRight: {
    marginTop: "auto",
    marginBottom: "auto",
    display: "flex",
    alignSelf: "end",
    marginLeft: "auto",
  },
  buttons: {
    display: "flex",
    alignItems: "center",
    flexDirection: "row",
    alignSelf: "flex-end",
  },
}));
