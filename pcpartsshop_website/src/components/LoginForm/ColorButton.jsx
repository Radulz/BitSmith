import { styled } from "@material-ui/styles";
import { Button } from "@material-ui/core";

export const ColorButton = styled(Button)(() => ({
  color: "#fff",
  backgroundColor: "#da680f",
  "&:hover": {
    backgroundColor: "#ff5722",
  },
  fontFamily: "sans-serif",
}));
