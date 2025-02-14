import React, { useState, useEffect, useMemo } from "react";
import PageWrapper from "../shared/PageWrapper";
import {
    Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Typography,
    TextField, Card, CardContent, CardHeader, Chip, TablePagination, Button, Box, IconButton
} from "@mui/material";
import { Add, Edit, Delete } from "@mui/icons-material";
import apiService from "../../services/apiService";
import { IBooking } from "../../models/IBooking";
import { IService } from "../../models/IService";
import { IClient } from "../../models/IClient";

export function HomePage() {
    const [page, setPage] = useState(0);
    const rowsPerPage = 10;
    const [searchQuery, setSearchQuery] = useState("");
    const [bookings, setBookings] = useState<IBooking[]>([]);
    const [services, setServices] = useState<IService[]>([]);
    const [clients, setClients] = useState<IClient[]>([]);

    // Fetch all data in parallel
    useEffect(() => {
        (async () => {
            try {
                const [bookingsRes, servicesRes, clientsRes] = await Promise.all([
                    apiService.get<{ data: IBooking[] }>('/booking'),
                    apiService.get<{ data: IService[] }>('/service'),
                    apiService.get<{ data: IClient[] }>('/client')
                ]);

                setClients(clientsRes.data);
                setServices(servicesRes.data);
                setBookings(
                    bookingsRes.data.map(booking => ({
                        ...booking,
                        service: servicesRes.data.find(service => service.id === booking.serviceID),
                        client: clientsRes.data.find(client => client.id === booking.clientID)
                    }))
                );
            } catch (error) {
                console.error("Failed to fetch data:", error);
            }
        })();
    }, []);

    // Filtered bookings based on search query
    const filteredBookings = useMemo(() => {
        return bookings.filter(booking =>
            booking.client?.firstName.toLowerCase().includes(searchQuery.toLowerCase()) ||
            booking.client?.lastName.toLowerCase().includes(searchQuery.toLowerCase()) ||
            booking.service?.serviceName.toLowerCase().includes(searchQuery.toLowerCase())
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
    const statusColors: Record<string, "success" | "warning" | "primary" | "error" | "info"> = {
        Pending: "success",
        Confirmed: "warning",
        Completed: "primary",
        Cancelled: "error"
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
}
