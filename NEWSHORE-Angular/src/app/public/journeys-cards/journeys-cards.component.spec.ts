import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JourneysCardsComponent } from './journeys-cards.component';

describe('JourneysCardsComponent', () => {
  let component: JourneysCardsComponent;
  let fixture: ComponentFixture<JourneysCardsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [JourneysCardsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(JourneysCardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
