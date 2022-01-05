import React from "react";
import Card from "@mui/material/Card";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import CancelPresentationOutlinedIcon from "@mui/icons-material/CancelPresentationOutlined";
import { IconButton } from "@material-ui/core";

const CPUCard = ({ product, setProduct }) => {
  return (
    <div
      style={{
        display: "flex",
        marginTop: "25px",
        justifyContent: "center",
      }}
    >
      <Card sx={{ maxWidth: 350 }}>
        <CardMedia
          component="img"
          alt="cpu"
          height="140"
          image={product.image}
        />
        <CardContent>
          <Typography gutterBottom variant="h5" component="div">
            {product.make + " " + product.model}
          </Typography>
          <Typography
            dangerouslySetInnerHTML={{
              __html: "ComponentId: " + product.componentId,
            }}
            variant="body2"
            color="textSecondary"
          />
          <Typography
            dangerouslySetInnerHTML={{ __html: "Socket: " + product.socket }}
            variant="body2"
            color="textSecondary"
          />
          <Typography
            dangerouslySetInnerHTML={{
              __html: "Frequency: " + product.frequency + " GHz ",
            }}
            variant="body2"
            color="textSecondary"
          />
          <Typography
            dangerouslySetInnerHTML={{
              __html: "Technology: " + product.technology + " nm",
            }}
            variant="body2"
            color="textSecondary"
          />
          <Typography
            dangerouslySetInnerHTML={{
              __html: "Number of cores: " + product.numberOfCores,
            }}
            variant="body2"
            color="textSecondary"
          />
          <Typography
            dangerouslySetInnerHTML={{
              __html: "Memory frequency: " + product.memoryFrequency + " MHz",
            }}
            variant="body2"
            color="textSecondary"
          />
          <Typography
            dangerouslySetInnerHTML={{
              __html: "TDP: " + product.thermalDesignPower + " W",
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
          <Typography variant="h5">{product.price}$</Typography>
          <IconButton
            aria-label="Cancel product presentation"
            onClick={(e) => setProduct(null)}
          >
            <CancelPresentationOutlinedIcon />
          </IconButton>
        </CardActions>
      </Card>
    </div>
  );
};

export default CPUCard;
