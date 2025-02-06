import React, { useState } from "react";
import PageWrapper from "../shared/PageWrapper";
import {
    Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Typography,
    TextField, Card, CardContent, CardHeader, Chip, TablePagination
} from "@mui/material";

export function HomePage() {
    // Static booking data
    const initialBookings = [
        { id: 1, client: "Michael Carter", service: "Private Security Consultation", bookingDate: "2025-02-06", startTime: "10:00 AM", endTime: "11:00 AM", status: "Confirmed", notes: "Discussing residential security upgrades." },
        { id: 2, client: "Elena Vasquez", service: "Luxury Car Service", bookingDate: "2025-02-07", startTime: "2:00 PM", endTime: "3:00 PM", status: "Pending", notes: "Chauffeured ride from Kotoka Airport." },
        { id: 3, client: "James Anderson", service: "International School Consultation", bookingDate: "2025-02-08", startTime: "4:00 PM", endTime: "5:00 PM", status: "Completed", notes: "Seeking top private school for children." },
        { id: 4, client: "Nadia Al-Farsi", service: "Private Chef Service", bookingDate: "2025-02-09", startTime: "1:00 PM", endTime: "2:00 PM", status: "Cancelled", notes: "Chef unavailable, rescheduling needed." },
        { id: 5, client: "William Brown", service: "Luxury Real Estate Viewing", bookingDate: "2025-02-10", startTime: "11:00 AM", endTime: "12:00 PM", status: "Confirmed", notes: "Tour of a 5-bedroom mansion in East Legon." },
        { id: 6, client: "Isabelle Fontaine", service: "High-End Spa & Wellness", bookingDate: "2025-02-11", startTime: "3:00 PM", endTime: "4:00 PM", status: "Pending", notes: "Exclusive full-body detox therapy." },
        { id: 7, client: "Daniel Smith", service: "Private Healthcare Check-up", bookingDate: "2025-02-12", startTime: "5:00 PM", endTime: "6:00 PM", status: "Confirmed", notes: "Routine health assessment at a VIP clinic." },
        { id: 8, client: "Victoria Liu", service: "Concierge Medical Services", bookingDate: "2025-02-13", startTime: "9:00 AM", endTime: "10:00 AM", status: "Completed", notes: "Doctor-on-call service for family." },
        { id: 9, client: "Marcus Johnson", service: "Luxury Safari Tour", bookingDate: "2025-02-14", startTime: "1:00 PM", endTime: "2:00 PM", status: "Cancelled", notes: "Client postponed due to work commitments." },
        { id: 10, client: "Sophia Renault", service: "High-Level Networking Event", bookingDate: "2025-02-15", startTime: "12:00 PM", endTime: "1:00 PM", status: "Pending", notes: "VIP entry to diplomatic networking event." },
        { id: 11, client: "Alexander Müller", service: "Private Jet Charter", bookingDate: "2025-02-16", startTime: "4:00 PM", endTime: "5:00 PM", status: "Confirmed", notes: "Flight from Accra to Abuja for business trip." },
        { id: 12, client: "Carla Benedetti", service: "Exclusive Yacht Rental", bookingDate: "2025-02-17", startTime: "2:00 PM", endTime: "4:00 PM", status: "Completed", notes: "Luxury boat tour in Ada." },
        { id: 13, client: "Richard Green", service: "Elite Personal Shopping", bookingDate: "2025-02-18", startTime: "10:00 AM", endTime: "10:30 AM", status: "Confirmed", notes: "Private stylist for luxury fashion brands." },
        { id: 14, client: "Angela Forbes", service: "VIP Cultural Immersion Tour", bookingDate: "2025-02-19", startTime: "3:00 PM", endTime: "4:30 PM", status: "Pending", notes: "Personal guide for heritage sites in Ghana." },
        { id: 15, client: "Hassan Al-Khatib", service: "Exclusive Gourmet Dining Experience", bookingDate: "2025-02-20", startTime: "6:00 PM", endTime: "7:00 PM", status: "Confirmed", notes: "Private dining with a top Ghanaian chef." },
    ];

    const [page, setPage] = useState(0);
    const rowsPerPage = 10;
    const [searchQuery, setSearchQuery] = useState("");

    // Handle page change
    const handlePageChange = (event, newPage) => {
        setPage(newPage);
    };

    // Filtered data based on search query
    const filteredBookings = initialBookings.filter((booking) =>
        booking.client.toLowerCase().includes(searchQuery.toLowerCase()) ||
        booking.service.toLowerCase().includes(searchQuery.toLowerCase()) ||
        booking.status.toLowerCase().includes(searchQuery.toLowerCase())
    );

    return (
        <PageWrapper>
            <Card sx={{ width: "90%", margin: "auto", boxShadow: 3, borderRadius: 3 }}>
                <CardHeader title="Booking Overview" sx={{ backgroundColor: "#1976d2", color: "white", textAlign: "center" }} />
                <CardContent>
                    {/* Search Bar */}
                    <TextField
                        label="Search Bookings"
                        variant="outlined"
                        fullWidth
                        sx={{ marginBottom: "20px" }}
                        onChange={(e) => setSearchQuery(e.target.value)}
                    />

                    {/* Table */}
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
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {filteredBookings.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage).map((booking) => (
                                    <TableRow key={booking.id}>
                                        <TableCell>{booking.id}</TableCell>
                                        <TableCell>{booking.client}</TableCell>
                                        <TableCell>{booking.service}</TableCell>
                                        <TableCell>{booking.bookingDate}</TableCell>
                                        <TableCell>{booking.startTime}</TableCell>
                                        <TableCell>{booking.endTime}</TableCell>
                                        <TableCell>
                                            <Chip label={booking.status} color={booking.status === "Confirmed" ? "success" : booking.status === "Pending" ? "warning" : booking.status === "Completed" ? "primary" : "error"} />
                                        </TableCell>
                                        <TableCell>{booking.notes}</TableCell>
                                    </TableRow>
                                ))}
                            </TableBody>
                        </Table>
                    </TableContainer>

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
