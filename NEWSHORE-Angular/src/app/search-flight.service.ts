import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { JourneyModel } from './models/journey.model';
import { RequestModel } from './models/common/request.model';
import { configUrl } from './config.url';

@Injectable({
  providedIn: 'root'
})
export class SearchFlightService {

  url: string = configUrl.urlApiFlights
  constructor(private http: HttpClient) { }

  FindJourneyFlights(request:RequestModel): Observable<JourneyModel[]> {
    return this.http.get<JourneyModel[]>(`${this.url}?origin=${request.origin}&destination=${request.destination}`,);
  }
}
