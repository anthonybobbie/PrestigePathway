import { IBooking } from "./IBooking";

export interface IClient {
    "id": number;
    "firstName": string;
    "lastName": string;
    "email": string;
    "address": string;
    "notes": string;
    "isClientActive": boolean;
    "bookings": IBooking[];
    "phoneNumber": string,
    "clientType": number,
    "registrationDate": Date,

}