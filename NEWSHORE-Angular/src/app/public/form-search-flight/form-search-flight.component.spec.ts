import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormSearchFlightComponent } from './form-search-flight.component';

describe('FormSearchFlightComponent', () => {
  let component: FormSearchFlightComponent;
  let fixture: ComponentFixture<FormSearchFlightComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FormSearchFlightComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FormSearchFlightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
