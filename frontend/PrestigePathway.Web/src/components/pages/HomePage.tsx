import { useState, useEffect, useMemo } from "react";
import PageWrapper from "../shared/PageWrapper";
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Typography,
  TextField,
  Card,
  CardContent,
  CardHeader,
  Chip,
  TablePagination,
  Button,
  Box,
  IconButton,
  Modal,
  Select,
  MenuItem,
} from "@mui/material";
import { Add, Edit, Delete } from "@mui/icons-material";
import apiService from "../../services/apiService";
import { IBooking } from "../../models/IBooking";
import { IService } from "../../models/IService";
import { IClient } from "../../models/IClient";
import Confirmation from "../shared/Confirmation";

const style = {
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 400,
  backgroundColor: "#fff",
  color: "#000",
  borderRadius: "12px",
  padding: "44px",
};

export function HomePage() {
  const [page, setPage] = useState(0);
  const rowsPerPage = 10;
  const [searchQuery, setSearchQuery] = useState("");
  const [bookings, setBookings] = useState<IBooking[]>([]);
  const [services, setServices] = useState<IService[]>([]);
  const [clients, setClients] = useState<IClient[]>([]);
  const [selectedBooking, setSelectedBooking] = useState<IBooking | null>(null);
  const [editedBooking, setEditedBooking] = useState<IBooking | null>(null);
  const [bookingData, setBookingData] = useState({
    clientID: 0,
    serviceID: 0,
    bookingDate: "",
    startTime: "",
    endTime: "",
    status: "Pending",
    notes: "",
  });

  // Edit Modal
  const [open, setOpen] = useState(false);
  const handleClose = () => {
    setOpen(false);
    setEditedBooking(null);
    setBookingData({
      clientID: 0,
      serviceID: 0,
      bookingDate: "",
      startTime: "",
      endTime: "",
      status: "Pending",
      notes: "",
    });
  };

  const [confirmationOpen, setConfirmationOpen] = useState(false);
  const [bookingToDelete, setBookingToDelete] = useState<number | null>(null);

  // Fetch all data in parallel
  useEffect(() => {
    (async () => {
      try {
        const [bookingsRes, servicesRes, clientsRes] = await Promise.all([
          apiService.get<{ data: IBooking[] }>("/booking"),
          apiService.get<{ data: IService[] }>("/service"),
          apiService.get<{ data: IClient[] }>("/client"),
        ]);

        setClients(clientsRes.data);
        setServices(servicesRes.data);
        setBookings(
          bookingsRes.data.map((booking) => ({
            ...booking,
            service: servicesRes.data.find(
              (service) => service.id === booking.serviceID
            ),
            client: clientsRes.data.find(
              (client) => client.id === booking.clientID
            ),
          }))
        );

      } catch (error) {
        console.error("Failed to fetch data:", error);
      }
    })();
  }, []);

  // Filtered bookings based on search query
  const filteredBookings = useMemo(() => {
    return bookings.filter(
      (booking) =>
        booking.client?.firstName
          .toLowerCase()
          .includes(searchQuery.toLowerCase()) ||
        booking.client?.lastName
          .toLowerCase()
          .includes(searchQuery.toLowerCase()) ||
        booking.service?.serviceName
          .toLowerCase()
          .includes(searchQuery.toLowerCase())

    }, [bookings, searchQuery]);

    // Reset page if filtered data is smaller than the current pagination range
    useEffect(() => {
        if (page * rowsPerPage >= filteredBookings.length) {
            setPage(0);
        }
    }, [filteredBookings.length]);

    // Handle page change
    const handlePageChange = (event: any, newPage: number) => {
        setPage(newPage);
    };

    // Status color mapping for Chip component
    const statusColors: Record<string, "success" | "warning" | "primary" | "error" | "info"> = {
        Pending: "success",
        Confirmed: "warning",
        Completed: "primary",
        Cancelled: "error"
    };

    // Handle edit booking
    const handleEditService = (serviceId: number) => {
        console.log("Edit Service:", serviceId);
    };
    // Handle add booking
    const handleAddBooking = () => {
        console.log("Add Booking clicked");
    };

    // Handle edit booking
    const handleEditBooking = (id: number) => {
        console.log("Edit Booking:", id);
    };

    // Handle delete booking
    const handleDeleteBooking = (id: number) => {
        console.log("Delete Booking:", id);
    };

    return (
        <PageWrapper>
            <Card sx={{ width: "90%", margin: "auto", boxShadow: 3, borderRadius: 3 }}>
                <CardHeader 
                    title="Booking Overview" 
                    sx={{ backgroundColor: "#1976d2", color: "white", textAlign: "center" }} 
                />
                <CardContent>
                    {/* Top Action Bar */}
                    <Box display="flex" justifyContent="space-between" alignItems="center" mb={2}>
                        <TextField
                            label="Search Bookings"
                            variant="outlined"
                            fullWidth
                            sx={{ maxWidth: "400px" }}
                            onChange={(e) => setSearchQuery(e.target.value)}
                        />
                        <Box display="flex" alignItems="center">
                            <Typography variant="body1" sx={{ mr: 2 }}>
                                Total Records: <strong>{filteredBookings.length}</strong>
                            </Typography>
                            <Button 
                                variant="contained" 
                                color="primary" 
                                startIcon={<Add />} 
                                onClick={handleAddBooking}
                            >
                                Add Booking
                            </Button>
                        </Box>
                    </Box>

                    {bookings.length > 0 ? (
                        <TableContainer component={Paper}>
                            <Table>
                                <TableHead>
                                    <TableRow>
                                        <TableCell sx={{ fontWeight: "bold" }}>ID</TableCell>
                                        <TableCell sx={{ fontWeight: "bold" }}>Client</TableCell>
                                        <TableCell sx={{ fontWeight: "bold" }}>Service</TableCell>
                                        <TableCell sx={{ fontWeight: "bold" }}>Booking Date</TableCell>
                                        <TableCell sx={{ fontWeight: "bold" }}>Start Time</TableCell>
                                        <TableCell sx={{ fontWeight: "bold" }}>End Time</TableCell>
                                        <TableCell sx={{ fontWeight: "bold" }}>Status</TableCell>
                                        <TableCell sx={{ fontWeight: "bold" }}>Notes</TableCell>
                                        <TableCell sx={{ fontWeight: "bold" }} align="center">Actions</TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {filteredBookings.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage).map(booking => (
                                        <TableRow key={booking.id}>
                                            <TableCell>{booking.id}</TableCell>
                                            <TableCell>{booking.client?.firstName} {booking.client?.lastName}</TableCell>
                                            <TableCell>{booking.service?.serviceName}</TableCell>
                                            <TableCell>{booking.bookingDate}</TableCell>
                                            <TableCell>{booking.startTime}</TableCell>
                                            <TableCell>{booking.endTime}</TableCell>
                                            <TableCell>
                                                <Chip label={booking.status} color={statusColors[booking.status] || "info"} />
                                            </TableCell>
                                            <TableCell>{booking.notes}</TableCell>
                                            <TableCell align="center">
                                               
                                               <Button color="primary" onClick={() => handleEditBooking(booking.serviceID)}>Service Details</Button>
                                                <IconButton color="primary" onClick={() => handleEditBooking(booking.id)}>
                                                    <Edit />
                                                </IconButton>
                                                <IconButton color="error" onClick={() => handleDeleteBooking(booking.id)}>
                                                    <Delete />
                                                </IconButton>

                                            </TableCell>
                                        </TableRow>
                                    ))}
                                </TableBody>
                            </Table>
                        </TableContainer>
                    ) : (
                        <Typography variant="h6" textAlign="center">No bookings available</Typography>
                    )}

                    {/* Pagination */}
                    <TablePagination
                        component="div"
                        count={filteredBookings.length}
                        page={page}
                        onPageChange={handlePageChange}
                        rowsPerPage={rowsPerPage}
                        rowsPerPageOptions={[]}
                    />
                </CardContent>
            </Card>
        </PageWrapper>
    );
  }, [bookings, searchQuery]);

  // Reset page if filtered data is smaller than the current pagination range
  useEffect(() => {
    if (page * rowsPerPage >= filteredBookings.length) {
      setPage(0);
    }
  }, [filteredBookings.length]);

  // Handle page change
  const handlePageChange = (event: any, newPage: number) => {
    setPage(newPage);
  };

  // Status color mapping for Chip component
  const statusColors: Record<
    string,
    "success" | "warning" | "primary" | "error" | "info"
  > = {
    Pending: "success",
    Confirmed: "warning",
    Completed: "primary",
    Cancelled: "error",
  };

  const handleAddBooking = async () => {
    try {
      // Combine bookingDate with startTime and endTime to create ISO 8601 timestamps
      const startDateTime = `${bookingData.bookingDate}T${bookingData.startTime}:00.000Z`;
      const endDateTime = `${bookingData.bookingDate}T${bookingData.endTime}:00.000Z`;

      const newBooking: IBooking = {
        id: 0,
        clientID: bookingData.clientID,
        serviceID: bookingData.serviceID,
        bookingDate: startDateTime,
        startTime: startDateTime,
        endTime: endDateTime,
        status: bookingData.status,
        notes: bookingData.notes,
      };

      console.log("Sending Booking Data:", newBooking);

      const response = await apiService.post<IBooking, IBooking>(
        "/booking",
        newBooking
      );

      setBookings((prev) => [
        ...prev,
        {
          ...response,
          client: clients.find((client) => client.id === response.clientID),
          service: services.find(
            (service) => service.id === response.serviceID
          ),
        },
      ]);
      handleClose();
    } catch (error) {
      console.error("Error adding booking:", error);
      alert("Failed to add booking. Please check the data and try again.");
    }
  };

  // Handle edit booking
  const handleEditBooking = (booking: IBooking) => {
    setSelectedBooking(booking);
    setEditedBooking({ ...booking });
    setBookingData({
      clientID: booking.clientID,
      serviceID: booking.serviceID,
      bookingDate: booking.bookingDate,
      startTime: booking.startTime,
      endTime: booking.endTime,
      status: booking.status,
      notes: booking.notes,
    });
    setOpen(true);
  };

  // Handle delete booking
  const handleDeleteBooking = (id: number) => {
    setBookingToDelete(id); // Set the booking ID to delete
    setConfirmationOpen(true); // Open the confirmation dialog
  };

  const handleConfirmDelete = async () => {
    if (bookingToDelete !== null) {
      try {
        await apiService.delete<void>(`/booking/${bookingToDelete}`);
        setBookings((prevBookings) =>
          prevBookings.filter((b) => b.id !== bookingToDelete)
        );
      } catch (err) {
        console.error("Error deleting booking:", err);
      } finally {
        setConfirmationOpen(false); // Close the dialog
        setBookingToDelete(null); // Reset the booking ID
      }
    }
  };

  // handle update
  const handleUpdate = async () => {
    if (!editedBooking) return;

    try {
      await apiService.put<IBooking, void>(
        `/booking/${editedBooking.id}`,
        editedBooking
      );

      setBookings((prevBookings) =>
        prevBookings.map((booking) =>
          booking.id === editedBooking.id ? editedBooking : booking
        )
      );

      handleClose();
    } catch (err) {
      console.error("Error updating booking:", err);
    }
  };

  return (
    <PageWrapper>
      <Card
        sx={{ width: "90%", margin: "auto", boxShadow: 3, borderRadius: 3 }}
      >
        <CardHeader
          title="Booking Overview"
          sx={{
            backgroundColor: "#1976d2",
            color: "white",
            textAlign: "center",
          }}
        />
        <CardContent>
          {/* Top Action Bar */}
          <Box
            display="flex"
            justifyContent="space-between"
            alignItems="center"
            mb={2}
          >
            <TextField
              label="Search Bookings"
              variant="outlined"
              fullWidth
              sx={{ maxWidth: "400px" }}
              onChange={(e) => setSearchQuery(e.target.value)}
            />
            <Box display="flex" alignItems="center">
              <Typography variant="body1" sx={{ mr: 2 }}>
                Total Records: <strong>{filteredBookings.length}</strong>
              </Typography>
              <Button
                variant="contained"
                color="primary"
                startIcon={<Add />}
                onClick={() => setOpen(true)}
              >
                Add Booking
              </Button>
              <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
                BackdropProps={{
                  style: { backgroundColor: "rgba(0, 0, 0, 0.1)" },
                }}
              >
                <Box sx={style}>
                  <Typography variant="h6" sx={{ fontWeight: "bold", mb: 2 }}>
                    {editedBooking ? "Edit Booking" : "Add Booking"}
                  </Typography>
                  <Select
                    labelId="client-select-label"
                    id="client-select"
                    value={bookingData.clientID}
                    onChange={(e) =>
                      setBookingData({
                        ...bookingData,
                        clientID: Number(e.target.value),
                      })
                    }
                    displayEmpty
                    fullWidth
                    sx={{ mb: 2 }}
                  >
                    <MenuItem value="">
                      <em>None</em>
                    </MenuItem>
                    {clients.map((client) => (
                      <MenuItem key={client.id} value={client.id}>
                        {client.firstName} {client.lastName}
                      </MenuItem>
                    ))}
                  </Select>

                  <Select
                    labelId="service-select-label"
                    id="service-select"
                    value={bookingData.serviceID}
                    onChange={(e) =>
                      setBookingData({
                        ...bookingData,
                        serviceID: Number(e.target.value),
                      })
                    }
                    displayEmpty
                    fullWidth
                    sx={{ mb: 2 }}
                  >
                    <MenuItem value="">
                      <em>None</em>
                    </MenuItem>
                    {services.map((service) => (
                      <MenuItem key={service.id} value={service.id}>
                        {service.serviceName}
                      </MenuItem>
                    ))}
                  </Select>
                  <TextField
                    label="Booking Date"
                    type="date"
                    fullWidth
                    sx={{ mb: 2 }}
                    value={bookingData.bookingDate}
                    onChange={(e) =>
                      setBookingData({
                        ...bookingData,
                        bookingDate: e.target.value,
                      })
                    }
                  />

                  <TextField
                    label="Start Time"
                    type="time"
                    fullWidth
                    sx={{ mb: 2 }}
                    value={bookingData.startTime}
                    onChange={(e) =>
                      setBookingData({
                        ...bookingData,
                        startTime: e.target.value,
                      })
                    }
                  />

                  <TextField
                    label="End Time"
                    type="time"
                    fullWidth
                    sx={{ mb: 2 }}
                    value={bookingData.endTime}
                    onChange={(e) =>
                      setBookingData({
                        ...bookingData,
                        endTime: e.target.value,
                      })
                    }
                  />
                  <TextField
                    label="Notes"
                    type="text"
                    fullWidth
                    sx={{ mb: 2 }}
                    value={bookingData.notes}
                    onChange={(e) =>
                      setBookingData({ ...bookingData, notes: e.target.value })
                    }
                  />

                  <Box display="flex" justifyContent="flex-end">
                    <Button
                      onClick={handleClose}
                      color="secondary"
                      sx={{ mr: 2 }}
                    >
                      Cancel
                    </Button>
                    <Button
                      variant="contained"
                      color="primary"
                      onClick={editedBooking ? handleUpdate : handleAddBooking}
                    >
                      {editedBooking ? "Update" : "Add"}
                    </Button>
                  </Box>
                </Box>
              </Modal>
            </Box>
          </Box>

          {bookings.length > 0 ? (
            <TableContainer component={Paper}>
              <Table>
                <TableHead>
                  <TableRow>
                    <TableCell sx={{ fontWeight: "bold" }}>ID</TableCell>
                    <TableCell sx={{ fontWeight: "bold" }}>Client</TableCell>
                    <TableCell sx={{ fontWeight: "bold" }}>Service</TableCell>
                    <TableCell sx={{ fontWeight: "bold" }}>
                      Booking Date
                    </TableCell>
                    <TableCell sx={{ fontWeight: "bold" }}>
                      Start Time
                    </TableCell>
                    <TableCell sx={{ fontWeight: "bold" }}>End Time</TableCell>
                    <TableCell sx={{ fontWeight: "bold" }}>Status</TableCell>
                    <TableCell sx={{ fontWeight: "bold" }}>Notes</TableCell>
                    <TableCell sx={{ fontWeight: "bold" }} align="center">
                      Actions
                    </TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {filteredBookings
                    .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                    .map((booking) => (
                      <TableRow key={booking.id}>
                        <TableCell>{booking.id}</TableCell>
                        <TableCell>
                          {booking.client?.firstName} {booking.client?.lastName}
                        </TableCell>
                        <TableCell>{booking.service?.serviceName}</TableCell>
                        <TableCell>{booking.bookingDate}</TableCell>
                        <TableCell>{booking.startTime}</TableCell>
                        <TableCell>{booking.endTime}</TableCell>
                        <TableCell>
                          <Chip
                            label={booking.status}
                            color={statusColors[booking.status] || "info"}
                          />
                        </TableCell>
                        <TableCell>{booking.notes}</TableCell>
                        <TableCell align="center">
                          <IconButton
                            color="primary"
                            onClick={() => handleEditBooking(booking)}
                          >
                            <Edit />
                          </IconButton>
                          <IconButton
                            color="error"
                            onClick={() => handleDeleteBooking(booking.id)}
                          >
                            <Delete />
                          </IconButton>
                        </TableCell>
                      </TableRow>
                    ))}
                </TableBody>
              </Table>
            </TableContainer>
          ) : (
            <Typography variant="h6" textAlign="center">
              No bookings available
            </Typography>
          )}

          {/* Pagination */}
          <TablePagination
            component="div"
            count={filteredBookings.length}
            page={page}
            onPageChange={handlePageChange}
            rowsPerPage={rowsPerPage}
            rowsPerPageOptions={[]}
          />
        </CardContent>
      </Card>
      <Confirmation
        title="Delete Confirmation"
        text="Are you sure you want to delete this booking?"
        buttonText="Delete"
        open={confirmationOpen}
        onClose={() => setConfirmationOpen(false)}
        handler={handleConfirmDelete}
      />
    </PageWrapper>
  );
}
