import { FlightModel } from "./flight.model";

export class JourneyModel {    
    origin?: string;
    destination?: string;
    price?: number;
    flights?: FlightModel[];
}