import React from "react";
import Card from "@mui/material/Card";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import CloseIcon from "@mui/icons-material/Close";
import { IconButton } from "@material-ui/core";
import { displayedProductsDetails } from "../../../../constants/ProductsConstants";

const ComponentCard = ({ product, setProduct }) => {
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
          <Typography variant="h5" gutterBottom>
            {product.make + " " + product.model}
          </Typography>
          {Object.keys(displayedProductsDetails).map((d) => {
            return (
              product[d] && (
                <Typography
                  key={product.componentId + ` ${d}`}
                  dangerouslySetInnerHTML={{
                    __html:
                      displayedProductsDetails[d]?.label +
                      product[d] +
                      displayedProductsDetails[d]?.unit[product.componentType],
                  }}
                  variant="body2"
                  color="textSecondary"
                />
              )
            );
          })}
          {product.componentType === "CASE" && product.radiatorSupport ? (
            <Typography
              dangerouslySetInnerHTML={{ __html: "Has radiator support: Yes" }}
              variant="body2"
              color="textSecondary"
            />
          ) : (
            product.componentType === "CASE" && (
              <Typography
                dangerouslySetInnerHTML={{
                  __html: "Has radiator support: No",
                }}
                variant="body2"
                color="textSecondary"
              />
            )
          )}
          {product.componentType === "CASE" &&
          product.radiatorSupportLength === 0 ? (
            <Typography
              dangerouslySetInnerHTML={{
                __html: "Radiator support length: N/A",
              }}
              variant="body2"
              color="textSecondary"
            />
          ) : (
            product.componentType === "CASE" && (
              <Typography
                dangerouslySetInnerHTML={{
                  __html:
                    "Radiator support length: " +
                    product.radiatorSupportLength +
                    " mm ",
                }}
                variant="body2"
                color="textSecondary"
              />
            )
          )}
          {product.componentType === "COOLER" && product.height === 0 ? (
            <Typography
              dangerouslySetInnerHTML={{ __html: "Height: N/A" }}
              variant="body2"
              color="textSecondary"
            />
          ) : (
            product.componentType === "COOLER" && (
              <Typography
                dangerouslySetInnerHTML={{
                  __html: "Height: " + product.height + " mm ",
                }}
                variant="body2"
                color="textSecondary"
              />
            )
          )}
          {product.componentType === "COOLER" &&
          product.numberOfHeatPipes === 0 ? (
            <Typography
              dangerouslySetInnerHTML={{ __html: "Number of heat pipes: N/A" }}
              variant="body2"
              color="textSecondary"
            />
          ) : (
            product.componentType === "COOLER" && (
              <Typography
                dangerouslySetInnerHTML={{
                  __html: "Number of heat pipes: " + product.numberOfHeatPipes,
                }}
                variant="body2"
                color="textSecondary"
              />
            )
          )}
          {product.componentType === "COOLER" &&
          product.radiatorLength === 0 ? (
            <Typography
              dangerouslySetInnerHTML={{
                __html: "Cooler radiator length: N/A",
              }}
              variant="body2"
              color="textSecondary"
            />
          ) : (
            product.componentType === "COOLER" && (
              <Typography
                dangerouslySetInnerHTML={{
                  __html:
                    "Cooler radiator length: " +
                    product.radiatorLength +
                    " mm ",
                }}
                variant="body2"
                color="textSecondary"
              />
            )
          )}
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
            <CloseIcon />
          </IconButton>
        </CardActions>
      </Card>
    </div>
  );
};

export default ComponentCard;
