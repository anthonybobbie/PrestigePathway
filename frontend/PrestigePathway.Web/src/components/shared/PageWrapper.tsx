import { Box } from "@mui/material";

const PageWrapper = ({ children }) => {
  return (
    <Box
      sx={{
        position: "relative", // Ensures it's positioned correctly in normal flow
        top: "50px", // Adjust for navbar height
        left: 0,
        width: "90vw",
        minWidth: "calc(100vw - 84px)", // Full height minus navbar
        minHeight: "calc(100vh - 64px)", // Full height minus navbar
        padding: "20px",
        display: "block", // Prevents centering if parent is flex
        background: "linear-gradient(to right, #6a11cb, #2575fc)", // Gradient background

      }}
    >
      {children}
    </Box>
  );
};

export default PageWrapper;
