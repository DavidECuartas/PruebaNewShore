import { TransportModel } from "./transport.model";

export class FlightModel {    
    origin?: string;
    destination?: string;
    price?: number;
    transport?: TransportModel;
}