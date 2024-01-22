import { Component, Input } from '@angular/core';
import { JourneyModel } from '../../models/journey.model';

@Component({
  selector: 'app-journeys-cards',
  templateUrl: './journeys-cards.component.html',
  styleUrl: './journeys-cards.component.css'
})
export class JourneysCardsComponent {
  @Input()
  journey: JourneyModel = new JourneyModel;
  @Input() amount: number= 1 ;
  @Input() symbolCoin: string= 'USD' ;

  isClicked: boolean = false;

  toggleClick() {
    this.isClicked = !this.isClicked;
  }
  
}
