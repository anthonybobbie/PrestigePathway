import { Box, Container, Typography, Button } from '@mui/material';
import { useNavigate } from 'react-router-dom'; // Import for navigation
import imagine from '../../assets/imagine.jpg'; // Adjust the path if necessary
import { useContext } from 'react';
import { AuthContext } from '../../context/AuthContext';

export default function LandingPage() {
  const { isAuthenticated } = useContext(AuthContext);
  const navigate = useNavigate(); // Hook for navigation

  // Function to handle login navigation
  const handleLogin = () => {

    if (isAuthenticated) {
      navigate("/dashboard"); // Redirect authenticated users to the dashboard
    } else {
      navigate("/login"); // Redirect unauthenticated users to login page
    }
  };

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
        maxWidth="md"
        sx={{
          textAlign: 'center',
          backgroundColor: 'rgba(255,255,255,1)', // Background for readability
          p: 4,
          borderRadius: 2,
          boxShadow: 3, // Subtle shadow for elevation
        }}
      >
        <Typography 
          variant="h3" 
          component="h1" 
          fontWeight="bold" 
          color="primary" 
          gutterBottom
        >
          Welcome to Prestige Pathway
        </Typography>

        <Typography 
          variant="h5" 
          color="text.secondary" 
          fontWeight={500} 
          gutterBottom
        >
          Premium services for expatriates in Ghana
        </Typography>

        <Typography 
          variant="body1" 
          fontSize="1.2rem" 
          fontWeight={400} 
          lineHeight={1.6} 
          color="text.primary" 
          sx={{ mt: 2, mb: 4 }}
        >
          Our Mission: To provide unparalleled social services that empower expatriates and foster a seamless, supportive community in Ghana.
        </Typography>

        {/* Login Button Positioned Below */}
        <Button
          variant="contained"
          color="primary"
          sx={{
            fontWeight: 'bold',
            px: 4, // Horizontal padding
            py: 1.5, // Vertical padding
            fontSize: '1rem',
          }}
          onClick={handleLogin}
        >
          Login
        </Button>
      </Container>
    </Box>
  );
}
