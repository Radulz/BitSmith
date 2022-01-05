import React from "react";
import Card from "@mui/material/Card";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import Typography from "@mui/material/Typography";
import CancelPresentationOutlinedIcon from "@mui/icons-material/CancelPresentationOutlined";
import { IconButton } from "@material-ui/core";

const UserCard = ({ user, setUser }) => {
  const admin = user.admin ? "Yes" : "No";
  return (
    <div
      style={{
        display: "flex",
        marginTop: "25px",
        justifyContent: "center",
      }}
    >
      <Card sx={{ maxWidth: 350 }}>
        <CardContent>
          <Typography variant="h5" component="div">
            {user.firstName + " " + user.lastName}
          </Typography>
          <Typography
            dangerouslySetInnerHTML={{
              __html: "UserId: " + user.userId,
            }}
            variant="body2"
            color="textSecondary"
          />
          <Typography
            dangerouslySetInnerHTML={{
              __html: "Email: " + user.email,
            }}
            variant="body2"
            color="textSecondary"
          />
          <Typography
            dangerouslySetInnerHTML={{
              __html: "County: " + user.county,
            }}
            variant="body2"
            color="textSecondary"
          />
          <Typography
            dangerouslySetInnerHTML={{
              __html: "City: " + user.city,
            }}
            variant="body2"
            color="textSecondary"
          />
          <Typography
            dangerouslySetInnerHTML={{
              __html: "Address: " + user.address,
            }}
            variant="body2"
            color="textSecondary"
          />
          <Typography
            dangerouslySetInnerHTML={{
              __html: "Admin: " + admin,
            }}
            variant="body2"
            color="textSecondary"
          />
        </CardContent>
        <CardActions
          sx={{
            marginTop: "auto",
            display: "flex",
            justifyContent: "flex-end",
          }}
        >
          <IconButton
            aria-label="Cancel user presentation"
            onClick={(e) => setUser(null)}
          >
            <CancelPresentationOutlinedIcon />
          </IconButton>
        </CardActions>
      </Card>
    </div>
  );
};

export default UserCard;
