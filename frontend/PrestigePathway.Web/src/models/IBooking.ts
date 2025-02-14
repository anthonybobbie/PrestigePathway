import { IClient } from "./IClient";
import { IService } from "./IService";

export interface IBooking {
    id: number;
    clientID: number;
    serviceID: number;
    bookingDate: string;
    startTime: string;
    endTime: string;
    status: string;
    notes: string;
    service?: IService;
    client?: IClient;
}
