import { styled } from "@material-ui/styles";
import { Button } from "@material-ui/core";

export const ColorButton = styled(Button)(() => ({
  color: "#fff",
  backgroundColor: "#046380",
  "&:hover": {
    backgroundColor: "#1b2271",
  },
  fontFamily: "sans-serif",
}));
