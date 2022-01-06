import React from "react";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import Typography from "@mui/material/Typography";

const UserCardOrder = ({ data }) => {
  return (
    <div>
      <Card sx={{ maxWidth: 350 }}>
        <CardContent>
          <Typography variant="h5" component="div">
            {data.userFirstName + " " + data.userLastName}
          </Typography>
          <Typography
            dangerouslySetInnerHTML={{
              __html: "Email: " + data.userEmail,
            }}
            variant="body2"
            color="textSecondary"
          />
          <Typography
            dangerouslySetInnerHTML={{
              __html: "County: " + data.userCounty,
            }}
            variant="body2"
            color="textSecondary"
          />
          <Typography
            dangerouslySetInnerHTML={{
              __html: "City: " + data.userCity,
            }}
            variant="body2"
            color="textSecondary"
          />
          <Typography
            dangerouslySetInnerHTML={{
              __html: "Address: " + data.userAddress,
            }}
            variant="body2"
            color="textSecondary"
          />
          {data.shippingStatus ? (
            <Typography
              dangerouslySetInnerHTML={{
                __html: "Order shipping status: Shipped",
              }}
              variant="body2"
              color="textSecondary"
            />
          ) : (
            <Typography
              dangerouslySetInnerHTML={{
                __html: "Order shipping status: Not shipped",
              }}
              variant="body2"
              color="textSecondary"
            />
          )}
          <Typography
            dangerouslySetInnerHTML={{
              __html: "Order total: " + data.totalPrice + " $",
            }}
            variant="body2"
            color="textSecondary"
          />
        </CardContent>
      </Card>
    </div>
  );
};

export default UserCardOrder;
