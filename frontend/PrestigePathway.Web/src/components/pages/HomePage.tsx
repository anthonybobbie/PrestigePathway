import React, { useState } from "react";
import PageWrapper from "../shared/PageWrapper";
import {
    Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Typography,
    TextField, Card, CardContent, CardHeader, Chip, TablePagination
} from "@mui/material";
import apiService from "../../services/apiService";
import { IBooking } from "../../models/IBooking";

export function HomePage() {
    const [page, setPage] = useState(0);
    const rowsPerPage = 10;
    const [searchQuery, setSearchQuery] = useState("");
    const [initialBookings, setBookings] = useState([]);


    // load data when component is loaded
    React.useEffect(() => {

        const fetchBookings = (async () => {
            const response: any = await apiService.get('/booking');
            setBookings(response);

        })
        fetchBookings();

    }, []);

    // Handle page change
    const handlePageChange = (event: any, newPage: React.SetStateAction<number>) => {
        setPage(newPage);
    };



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

                    {initialBookings&&
                    (<TableContainer component={Paper}>
                        <Table>
                            <TableHead>
                                <TableRow>
                                    <TableCell sx={{ fontWeight: "bold" }}>ID</TableCell>
                                    <TableCell sx={{ fontWeight: "bold" }}>Client</TableCell>
                                    {/* <TableCell sx={{ fontWeight: "bold" }}>Service</TableCell> */}
                                    <TableCell sx={{ fontWeight: "bold" }}>Booking Date</TableCell>
                                    <TableCell sx={{ fontWeight: "bold" }}>Start Time</TableCell>
                                    <TableCell sx={{ fontWeight: "bold" }}>End Time</TableCell>
                                    <TableCell sx={{ fontWeight: "bold" }}>Status</TableCell>
                                    <TableCell sx={{ fontWeight: "bold" }}>Notes</TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {initialBookings?.map((booking: IBooking, index) => (
                                    <TableRow key={index}>
                                        <TableCell>{booking.id}</TableCell>

                                        <TableCell>{booking.client.firstName} {booking.client.lastName}</TableCell>
                                         <TableCell>{booking.service.serviceName}</TableCell> 
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
                    </TableContainer>)
                    }
                    

                    {/* Pagination */}
                    {/* <TablePagination
                        component="div"
                        count={filteredBookings.length}
                        page={page}
                        onPageChange={handlePageChange}
                        rowsPerPage={rowsPerPage}
                        rowsPerPageOptions={[]}
                    /> */}
                </CardContent>
            </Card>
        </PageWrapper>
    );
}

