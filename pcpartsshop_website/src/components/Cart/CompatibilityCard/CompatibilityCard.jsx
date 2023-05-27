import React from "react";
import Accordion from "@mui/material/Accordion";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import Typography from "@mui/material/Typography";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import { Box, Paper } from "@mui/material";
import GppBadIcon from "@mui/icons-material/GppBad";
import GppGoodIcon from "@mui/icons-material/GppGood";
import GppMaybeIcon from "@mui/icons-material/GppMaybe";
import RemoveModeratorIcon from "@mui/icons-material/RemoveModerator";
import useStyles from "./styles";

const CompatibilityCard = ({ item }) => {
  const classes = useStyles();

  return (
    <Accordion style={{ width: "90%" }}>
      <AccordionSummary
        expandIcon={
          <Paper
            variant="outlined"
            className={classes.expandIcon}
            style={{ borderRadius: "50%" }}
          >
            <ExpandMoreIcon />
          </Paper>
        }
        aria-controls="panel1a-content"
        id="panel1a-header"
        style={{
          backgroundColor: "white",
          display: "flex",
          flexDirection: "row",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        <Paper elevation={0} className={classes.summary}>
          <span className={classes.textSummary}>{item.summary}</span>
          {item.severity === "Green" ? (
            <GppGoodIcon className={classes.severityIconGood} />
          ) : item.severity === "Amber" ? (
            <GppMaybeIcon className={classes.severityIconMaybe} />
          ) : item.severity === "Red" ? (
            <GppBadIcon className={classes.severityIconBad} />
          ) : (
            <RemoveModeratorIcon className={classes.severityIconDisabled} />
          )}
        </Paper>
      </AccordionSummary>
      <AccordionDetails>
        <Typography>{item.message}</Typography>
      </AccordionDetails>
    </Accordion>
  );
};

export default CompatibilityCard;
