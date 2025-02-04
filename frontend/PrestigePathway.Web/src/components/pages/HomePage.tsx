import React from 'react';
import { Box, Container, Typography } from '@mui/material';
import imagine from '../../assets/imagine.jpg'; // Adjust the path if necessary

export default function HomePage() {
  return (
    <Box
      sx={{
        display: 'flex',
        width: '100vw',        // Full viewport width
        height: '100vh',       // Full viewport height
        alignItems: 'center',  // Vertical center
        justifyContent: 'center', // Horizontal center
        backgroundImage: `url(${imagine})`,
        backgroundSize: 'cover',
        backgroundPosition: 'center',
        backgroundRepeat: 'no-repeat',
      }}
    >
      <Container
        maxWidth="lg"
        sx={{
          textAlign: 'center',
          backgroundColor: 'rgba(255,255,255,1)', // Optional background for readability
          p: 3,
          borderRadius: 2,
        }}
      >
        <Typography variant="h2" component="h1" gutterBottom>
          Welcome to Prestige Pathway
        </Typography>
        <Typography variant="body1" gutterBottom>
          Premium services for expatriates in Ghana
        </Typography>
        <Typography variant="h6" sx={{ mt: 4 }}>
          Our Mission: To provide unparalleled social services that empower expatriates and foster a seamless, supportive community in Ghana.
        </Typography>
      </Container>
    </Box>
  );
}
