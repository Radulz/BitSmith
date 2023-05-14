import { Typography, Box, Grid } from "@material-ui/core";
import React from "react";
import useStyles from "./styles";
import { ReactComponent as FacebookLogo } from "./assets/square-facebook.svg";
import { ReactComponent as InstagramLogo } from "./assets/square-instagram.svg";
import { ReactComponent as TwitterLogo } from "./assets/square-twitter.svg";
import { ReactComponent as LinkedinLogo } from "./assets/linkedin.svg";
import { useLocation } from "react-router-dom";

const Footer = () => {
  const classes = useStyles();
  const location = useLocation();

  return (
    !(location?.pathname === "/adminPage") && (
      <Box className={classes?.footer}>
        <Grid
          container
          spacing={2}
          columns={{ xs: 12, sm: 12, md: 12, lg: 12, xl: 12 }}
          className={classes?.footerSection}
        >
          <Grid item xs={12} sm={4} md={3} lg={3} xl={3}>
            <div className={classes?.footerLinks}>
              <Typography variant="h4">For Business</Typography>
              <a href="/employer">
                <Typography>Employer</Typography>
              </a>
              <a href="/healthplan">
                <Typography>Health Plan</Typography>
              </a>
              <a href="/individual">
                <Typography>Individual</Typography>
              </a>
            </div>
          </Grid>
          <Grid item xs={12} sm={4} md={3} lg={2} xl={2}>
            <div className={classes?.footerLinks}>
              <Typography variant="h4">Resources</Typography>
              <a href="/resource">
                <Typography>Resources center</Typography>
              </a>
              <a href="/resource">
                <Typography>Testimonials</Typography>
              </a>
              <a href="/resource">
                <Typography>STV</Typography>
              </a>
            </div>
          </Grid>
          <Grid item xs={12} sm={4} md={3} lg={2} xl={2}>
            <div className={classes?.footerLinks}>
              <Typography variant="h4">Partners</Typography>
              <a href="/pcpartsshop">
                <Typography>PC Parts Shop</Typography>
              </a>
            </div>
          </Grid>
          <Grid item xs={12} sm={4} md={3} lg={2} xl={2}>
            <div className={classes?.footerLinks}>
              <Typography variant="h4">Company</Typography>
              <a href="/about">
                <Typography>About</Typography>
              </a>
              <a href="/press">
                <Typography>Press</Typography>
              </a>
              <a href="/career">
                <Typography>Career</Typography>
              </a>
              <a href="/contact">
                <Typography>Contact</Typography>
              </a>
            </div>
          </Grid>
          <Grid item xs={12} sm={4} md={3} lg={3} xl={3}>
            <div className={classes?.footerLinks}>
              <Typography variant="h4">Follow us on</Typography>
              <div className={classes?.socialMedia}>
                <div className={classes?.socialMediaIcon}>
                  <FacebookLogo fill="#FFF" />
                </div>
                <div className={classes?.socialMediaIcon}>
                  <InstagramLogo fill="#FFF" />
                </div>
                <div className={classes?.socialMediaIcon}>
                  <TwitterLogo fill="#FFF" />
                </div>
                <div className={classes?.socialMediaIcon}>
                  <LinkedinLogo fill="#FFF" />
                </div>
              </div>
            </div>
          </Grid>
        </Grid>
        <Grid
          container
          spacing={2}
          columns={{ xs: 12, sm: 12, md: 12, lg: 12, xl: 12 }}
          className={classes?.termsSection}
        >
          <Grid item xs={12} sm={12} md={6} lg={6} xl={6}>
            <Typography variant="h5">
              @{new Date().getFullYear()} BitSmith. All rights reserved.
            </Typography>
          </Grid>
          <Grid item xs={12} sm={6} md={2} lg={2} xl={2}>
            <a href="/terms">
              <div>
                <Typography>Terms & Conditions</Typography>
              </div>
            </a>
          </Grid>
          <Grid item xs={12} sm={6} md={1} lg={1} xl={1}>
            <a href="/privacy">
              <div>
                <Typography>Privacy</Typography>
              </div>
            </a>
          </Grid>
          <Grid item xs={12} sm={6} md={1} lg={1} xl={1}>
            <a href="/security">
              <div>
                <Typography>Security</Typography>
              </div>
            </a>
          </Grid>
          <Grid item xs={12} sm={6} md={2} lg={2} xl={2}>
            <a href="/cookies">
              <div>
                <Typography>Cookie Declaration</Typography>
              </div>
            </a>
          </Grid>
        </Grid>
      </Box>
    )
  );
};

export default Footer;
