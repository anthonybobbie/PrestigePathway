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
import { IService } from "../../models/IService";
import { IClient } from "../../models/IClient";
import Confirmation from "../shared/Confirmation";
import { IBooking } from "../../models/IBooking";

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
  //const [selectedBooking, setSelectedBooking] = useState<IBooking | null>(null);
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
  const [open, setOpen] = useState(false);
  const [confirmationOpen, setConfirmationOpen] = useState(false);
  const [bookingToDelete, setBookingToDelete] = useState<number | null>(null);

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
    );
  }, [bookings, searchQuery]);

  useEffect(() => {
    if (page * rowsPerPage >= filteredBookings.length) {
      setPage(0);
    }
  }, [filteredBookings.length]);

  const handlePageChange = (newPage: number) => {
    setPage(newPage);
  };

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

  const handleAddBooking = async () => {
    try {
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

  const handleEditBooking = (booking: IBooking) => {
    setEditedBooking(booking);
    setBookingData({
      clientID: booking.clientID,
      serviceID: booking.serviceID,
      bookingDate: booking.bookingDate.split("T")[0],
      startTime: booking.startTime.split("T")[1].substring(0, 5),
      endTime: booking.endTime.split("T")[1].substring(0, 5),
      status: booking.status,
      notes: booking.notes,
    });
    setOpen(true);
  };

  const handleDeleteBooking = (id: number) => {
    setBookingToDelete(id);
    setConfirmationOpen(true);
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
        setConfirmationOpen(false);
        setBookingToDelete(null);
      }
    }
  };

  const handleUpdate = async () => {
    if (!editedBooking?.id) {
      console.error("Error: Booking ID is missing!");
      return;
    }

    try {
      console.log("Before Update:", bookingData);

      const updatedBooking = {
        id: editedBooking.id,
        clientID: bookingData.clientID,
        serviceID: bookingData.serviceID,
        bookingDate: bookingData.bookingDate,
        startTime: `${bookingData.bookingDate}T${bookingData.startTime}:00`,
        endTime:   `${bookingData.bookingDate}T${bookingData.endTime}:00`,
        status: bookingData.status,
        notes: bookingData.notes,
      };

      console.log("Updated Booking Payload:", updatedBooking);

      await apiService.put<IBooking, void>(
        `/booking/${editedBooking.id}`,
        updatedBooking
      );

      setBookings((prevBookings) =>
        prevBookings.map((booking) =>
          booking.id === editedBooking.id
            ? {
                ...updatedBooking,
                client: clients.find((c) => c.id === bookingData.clientID),
                service: services.find((s) => s.id === bookingData.serviceID),
              }
            : booking
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
                    .map((booking:IBooking) => (
                      <TableRow key={booking.id}>
                        <TableCell>{booking.id}</TableCell>
                        <TableCell>
                          {booking.client?.firstName} {booking.client?.lastName}
                        </TableCell>
                        <TableCell>{booking.service?.serviceName}</TableCell>
                        <TableCell>
                          {new Date(booking.bookingDate).toLocaleDateString()}
                        </TableCell>
                        <TableCell>
                          {new Date(booking.startTime).toLocaleTimeString()}
                        </TableCell>
                        <TableCell>
                          {new Date(booking.endTime).toLocaleTimeString()}
                        </TableCell>
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

          <TablePagination
            component="div"
            count={filteredBookings.length}
            page={page}
            onPageChange={(_, page: number)=>handlePageChange(page)}
            rowsPerPage={rowsPerPage}
            rowsPerPageOptions={[]}
          />
        </CardContent>
      </Card>

      <Modal
        open={open}
        onClose={handleClose}
        BackdropProps={{ style: { backgroundColor: "rgba(0, 0, 0, 0.1)" } }}
      >
        <Box sx={style}>
          <Typography variant="h6" sx={{ fontWeight: "bold", mb: 2 }}>
            {editedBooking ? "Edit Booking" : "Add Booking"}
          </Typography>
          <Select
            labelId="client-select-label"
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
              <em>Select Client</em>
            </MenuItem>
            {clients.map((client) => (
              <MenuItem key={client.id} value={client.id}>
                {client.firstName} {client.lastName}
              </MenuItem>
            ))}
          </Select>

          <Select
            labelId="service-select-label"
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
              <em>Select Service</em>
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
            InputLabelProps={{ shrink: true }}
            value={bookingData.bookingDate}
            onChange={(e) =>
              setBookingData({ ...bookingData, bookingDate: e.target.value })
            }
          />

          <TextField
            label="Start Time"
            type="time"
            fullWidth
            sx={{ mb: 2 }}
            InputLabelProps={{ shrink: true }}
            value={bookingData.startTime}
            onChange={(e) =>
              setBookingData({ ...bookingData, startTime: e.target.value })
            }
          />

          <TextField
            label="End Time"
            type="time"
            fullWidth
            sx={{ mb: 2 }}
            InputLabelProps={{ shrink: true }}
            value={bookingData.endTime}
            onChange={(e) =>
              setBookingData({ ...bookingData, endTime: e.target.value })
            }
          />

          <Select
            labelId="status-select-label"
            value={bookingData.status}
            onChange={(e) =>
              setBookingData({ ...bookingData, status: e.target.value })
            }
            fullWidth
            sx={{ mb: 2 }}
          >
            {Object.keys(statusColors).map((status) => (
              <MenuItem key={status} value={status}>
                {status}
              </MenuItem>
            ))}
          </Select>

          <TextField
            label="Notes"
            multiline
            rows={3}
            fullWidth
            sx={{ mb: 2 }}
            value={bookingData.notes}
            onChange={(e) =>
              setBookingData({ ...bookingData, notes: e.target.value })
            }
          />

          <Box display="flex" justifyContent="flex-end">
            <Button onClick={handleClose} color="secondary" sx={{ mr: 2 }}>
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
