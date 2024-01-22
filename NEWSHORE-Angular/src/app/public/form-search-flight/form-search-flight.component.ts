import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SearchFlightService } from '../../search-flight.service';
import { JourneyModel } from '../../models/journey.model';
import coins from '../../../assets/coins.json';
import { CoinModel } from '../../models/common/coin.model';
import { RequestModel } from '../../models/common/request.model';
import { throwError } from 'rxjs';

@Component({
  selector: 'app-form-search-flight',
  templateUrl: './form-search-flight.component.html',
  styleUrl: './form-search-flight.component.css'
})
export class FormSearchFlightComponent {
  fGroup: FormGroup = new FormGroup({});
  listJourneys: JourneyModel[] = [];
  amount: number = 1;
  viewNoFlights: boolean = false
  symbolCoin: string = 'USD'
  coinList: CoinModel[] = coins;

  constructor(
    private fb: FormBuilder,
    private flightService: SearchFlightService,
  ) {

  }

  ngOnInit() {
    this.buildForm();
  }




  searchFlights() {

    if (this.fGroup.invalid) {
      alert("Datos imcompletos")
    } else {
      let origin = this.getFormGroup['origin'].value
      let destination = this.getFormGroup['destination'].value

      if (origin == destination) {
        alert("Los datos ingresados tienen que ser diferentes")
      } else {
        const request: RequestModel = {
          origin: origin,
          destination: destination,
        };
        this.findJourneyFlights(request)
      }


    }
  }

  findJourneyFlights(request: RequestModel) {
    this.flightService.FindJourneyFlights(request).subscribe({
      next: (data) => {
        this.listJourneys = data
        this.viewNoFlights = this.listJourneys.length === 0;
      },
      error: (error) => {
        console.error('Error en la solicitud HTTP:', error)        
        alert("Error leyendo la información de vuelos.")
      }
    });
  }

  buildForm() {
    this.fGroup = this.fb.group({
      origin: ['', [Validators.required]],
      destination: ['', [Validators.required]],
      selectCoin: 'USD'

    })
  }

  toUpperCase(controlName: string) {
    const formControl = this.getFormGroup[controlName];
    if (formControl) {
      formControl.setValue(formControl.value.toUpperCase());
    }
  }

  onCurrencyChange() {
    this.symbolCoin = this.getFormGroup['selectCoin'].value
    const selectedCoin = this.coinList.find(coin => coin.symbol === this.symbolCoin)?.value;

    if (selectedCoin) {
      this.amount = selectedCoin;
    } else {
      console.error(`No se encontró ninguna moneda con el símbolo ${this.symbolCoin}:`);
    };



  }

  get getFormGroup() {
    return this.fGroup.controls;
  }
}
