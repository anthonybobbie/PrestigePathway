import PageWrapper from "../shared/PageWrapper";
import * as React from "react";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";

interface TabPanelProps {
  children?: React.ReactNode;
  index: number;
  value: number;
}

function TabPanel(props: TabPanelProps) {
  const { children, value, index, ...other } = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`vertical-tabpanel-${index}`}
      aria-labelledby={`vertical-tab-${index}`}
      {...other}
    >
      {value === index && (
        <Box sx={{ p: 3 }}>
          {/* Update the component prop here to render a block-level element */}
          <Typography sx={{ color: "black" }} component="div">
            {children}
          </Typography>
        </Box>
      )}
    </div>
  );
}

function a11yProps(index: number) {
  return {
    id: `vertical-tab-${index}`,
    "aria-controls": `vertical-tabpanel-${index}`,
  };
}

export function ServicesPage() {
  const [value, setValue] = React.useState(0);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  return (
    <PageWrapper>
      <Box
        sx={{
          flexGrow: 1,
          bgcolor: "white",
          display: "flex",
          height: 500, // Adjusted height for forms
        }}
      >
        <Tabs
          orientation="vertical"
          variant="scrollable"
          value={value}
          onChange={handleChange}
          aria-label="Vertical tabs example"
          sx={{
            borderRight: 1,
            borderColor: "divider",
            "& .MuiTab-root": {
              color: "black", // Apply black text color to all Tab labels
            },
          }}
        >
          <Tab label="Service Type" {...a11yProps(0)} />
          <Tab label="Service Partner" {...a11yProps(1)} />
          <Tab label="Service Option" {...a11yProps(2)} />
        </Tabs>

        <TabPanel value={value} index={0}>
          <form>
            <TextField
              label="Type Name"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
            />
            <Button variant="contained" color="primary" fullWidth>
              Submit
            </Button>
          </form>
        </TabPanel>

        <TabPanel value={value} index={1}>
          <form>
            <TextField
              label="Partner Name"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
            />
            <TextField
              label="Service ID"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
            />
            <TextField
              label="Service Option ID"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
            />
            <TextField
              label="Contact Email"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
            />
            <TextField
              label="Contact Phone"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
            />
            <TextField
              label="Address"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
            />
            <Button variant="contained" color="primary" fullWidth>
              Submit
            </Button>
          </form>
        </TabPanel>

        {/* Form for Item Three */}
        <TabPanel value={value} index={2}>
          <form>
            <TextField
              label="Service ID"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
            />
            <TextField
              label="Option Name"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
            />
            <TextField
              label="Description"
              variant="outlined"
              fullWidth
              sx={{ mb: 2 }}
            />
            <Button variant="contained" color="primary" fullWidth>
              Submit
            </Button>
          </form>
        </TabPanel>
      </Box>
    </PageWrapper>
  );
}
