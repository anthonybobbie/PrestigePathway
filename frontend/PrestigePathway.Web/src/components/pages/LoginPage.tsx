import React from "react";
import { Box, Container, Typography, TextField, Button, Card, CardContent } from "@mui/material";

export function LoginPage() {
  return (
    <Box
      sx={{
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        height: "100vh",
        width: "100vw",
        background: "linear-gradient(to right, #6a11cb, #2575fc)", // Gradient background
      }}
    >
      <Container maxWidth="xs">
        <Card sx={{ padding: 3, boxShadow: 5, borderRadius: 2 }}>
          <CardContent>
            <Typography variant="h4" fontWeight="bold" textAlign="center" gutterBottom>
              Login
            </Typography>

            {/* Email Input */}
            <TextField
              fullWidth
              label="Email Address"
              type="email"
              variant="outlined"
              margin="normal"
              sx={{ borderRadius: 2 }}
            />

            {/* Password Input */}
            <TextField
              fullWidth
              label="Password"
              type="password"
              variant="outlined"
              margin="normal"
              sx={{ borderRadius: 2 }}
            />

            {/* Login Button */}
            <Button
              variant="contained"
              color="primary"
              fullWidth
              sx={{
                mt: 2,
                py: 1.5,
                fontWeight: "bold",
                borderRadius: 2,
                textTransform: "none",
              }}
              onClick={() => console.log("Logging in...")}
            >
              Sign In
            </Button>

            {/* Forgot Password & Register */}
            <Typography
              variant="body2"
              textAlign="center"
              sx={{ mt: 2, cursor: "pointer", color: "primary.main" }}
              onClick={() => console.log("Forgot Password clicked")}
            >
              Forgot Password?
            </Typography>
          </CardContent>
        </Card>
      </Container>
    </Box>
  );
}
