import { IClient } from "./IClient";
import { IService } from "./IService";

export interface IBooking {
    id: number;
    clientID: string;
    bookingDate: string;
    startTime: string;
    endTime: string;
    status: string;
    notes: string;
    service: IService;
    client: IClient;
}
