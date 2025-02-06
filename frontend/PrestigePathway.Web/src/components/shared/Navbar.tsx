import { useContext } from "react";
import { AppBar, Toolbar, Typography, Box, Button } from "@mui/material";
import { AuthContext } from "../../context/AuthContext";
import { Link as RouterLink } from "react-router-dom";

const Navbar = () => {
  const { isAuthenticated, setIsAuthenticated } = useContext(AuthContext);

  const handleLogout = () => {
    document.cookie = "authToken=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
    setIsAuthenticated(false);
    window.location.href = "/login";
  };

  if (!isAuthenticated) return null;

  return (
    <AppBar position="fixed" sx={{ top: 0, left: 0, right: 0, boxShadow: 3 }}>
      <Toolbar sx={{ display: "flex", justifyContent: "space-between" }}>
        <Typography variant="h6" sx={{ flexGrow: 1 }}>
          Prestige Pathway
        </Typography>

        <Box sx={{ display: "flex", gap: 3 }}>
          <Typography
            component={RouterLink}
            to="/home"
            sx={{ color: "white", textDecoration: "none" }}
          >
            Home
          </Typography>
          <Typography
            component={RouterLink}
            to="/dashboard"
            sx={{ color: "white", textDecoration: "none" }}
          >
            Dashboard
          </Typography>
          <Button color="inherit" onClick={handleLogout} sx={{ color: "white" }}>
            Logout
          </Button>
        </Box>
      </Toolbar>
    </AppBar>
  );
};

export default Navbar;



 

