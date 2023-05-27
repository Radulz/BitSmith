import { makeStyles } from "@material-ui/core/styles";

export default makeStyles((theme) => ({
  summary: {
    display: "flex",
    justifyContent: "space-between",
    alignItems: "center",
    width: "240px",
    height: "50px",
    marginLeft: "5px",
  },
  summaryPaper: {
    display: "flex",
    width: "250px",
    height: "40px",
    alignItems: "center",
    justifyContent: "center",
    padding: "5px",
  },
  divContainer: {
    display: "flex",
    justifyContent: "space-around",
    alignItems: "center",
    flexDirection: "column",
    width: "100%",
    height: "40vh",
  },
  textSummary: {
    fontSize: "20px",
    color: "black",
    fontFamily: "Courier, monospace",
    fontWeight: "bold",
  },
  severityIconGood: {
    marginLeft: "10px",
    transform: "scale(1.3)",
    color: "green",
  },
  severityIconMaybe: {
    marginLeft: "10px",
    transform: "scale(1.3)",
    color: "orange",
  },
  severityIconBad: {
    marginLeft: "10px",
    transform: "scale(1.3)",
    color: "red",
  },
  severityIconDisabled: {
    marginLeft: "10px",
    transform: "scale(1.3)",
    color: "grey",
  },
  componentsPaper: {
    display: "flex",
    width: "300px",
    height: "100px",
    alignItems: "center",
    justifyContent: "space-between",
    padding: "5px",
  },
  componentTitle: {
    fontSize: "12px",
    color: "black",
    fontFamily: "Courier, monospace",
  },
  expandIcon: {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    width: "40px",
    height: "40px",
  },
}));
