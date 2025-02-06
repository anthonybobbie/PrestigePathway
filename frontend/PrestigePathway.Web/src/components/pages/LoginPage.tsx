import React, { useContext, useState } from 'react';
import { Box, Container, Typography, TextField, Button, Card, CardContent } from '@mui/material';
import apiService from '../../services/apiService';

import { useNavigate } from 'react-router-dom'; // Import for navigation
import { AuthContext } from '../../context/AuthContext';
export function LoginPage() {
  const { isAuthenticated, setIsAuthenticated } = useContext(AuthContext);
  const [userName, setUserName] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate(); // Hook for navigation
  // use context

  const handleSubmit = async (event: { preventDefault: () => void; }) => {
    event.preventDefault();
    setError(''); // Clear previous error message

    try {
      const response: any = await apiService.post('/auth/login', { userName, password });
      // Assuming the response contains the token in a field named 'token'
      const { token } = response;

      // Store the token in an HTTP-only cookie
      document.cookie = `authToken=${token}; HttpOnly; Secure; SameSite=Strict`;
      // Set user authentication state
      setIsAuthenticated(true);
      // Clear form fields
      setUserName('');
      setPassword('');

      // Redirect to the home page
      navigate('/home');
    } catch (err) {
      // Handle authentication errors
      setError('Invalid userName or password. Please try again.');
      console.error('Login error:', err);
    }
  };


  return (
    <Box
      sx={{
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        height: '100vh',
        width: '100vw',
        background: 'linear-gradient(to right, #6a11cb, #2575fc)',
      }}
    >
      <Container maxWidth="xs">
        <Card sx={{ padding: 3, boxShadow: 5, borderRadius: 2 }}>
          <CardContent>
            <Typography variant="h4" fontWeight="bold" textAlign="center" gutterBottom>
              Login
            </Typography>

            {error && (
              <Typography variant="body2" color="error" textAlign="center" gutterBottom>
                {error}
              </Typography>
            )}

            <form onSubmit={handleSubmit}>
              <TextField
                fullWidth
                label="Username"
                type="text"
                variant="outlined"
                margin="normal"
                value={userName}
                onChange={(e) => setUserName(e.target.value)}
                sx={{ borderRadius: 2 }}
                required
              />

              <TextField
                fullWidth
                label="Password"
                type="password"
                variant="outlined"
                margin="normal"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                sx={{ borderRadius: 2 }}
                required
              />

              <Button
                type="submit"
                variant="contained"
                color="primary"
                fullWidth
                sx={{
                  mt: 2,
                  py: 1.5,
                  fontWeight: 'bold',
                  borderRadius: 2,
                  textTransform: 'none',
                }}
              >
                Sign In
              </Button>
            </form>

            <Typography
              variant="body2"
              textAlign="center"
              sx={{ mt: 2, cursor: 'pointer', color: 'primary.main' }}
              onClick={() => console.log('Forgot Password clicked')}
            >
              Forgot Password?
            </Typography>
          </CardContent>
        </Card>
      </Container>
    </Box>
  );
}
