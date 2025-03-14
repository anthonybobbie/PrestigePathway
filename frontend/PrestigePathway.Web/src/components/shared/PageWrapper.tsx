import { Box } from "@mui/material";
import { ReactNode } from "react";

interface PageWrapperProps {
  children: ReactNode;
}

const PageWrapper = ({ children }: PageWrapperProps) => {
  return (
    <Box
      sx={{
        position: "relative",
        top: "50px",
        left: 0,
        width: "90vw",
        minWidth: "calc(100vw - 84px)",
        minHeight: "calc(100vh - 64px)",
        padding: "20px",
        display: "block",
        background: "linear-gradient(to right, #6a11cb, #2575fc)",
      }}
    >
      {children}
    </Box>
  );
};

export default PageWrapper;
