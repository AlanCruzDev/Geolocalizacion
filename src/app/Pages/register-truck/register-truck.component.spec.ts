import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterTruckComponent } from './register-truck.component';

describe('RegisterTruckComponent', () => {
  let component: RegisterTruckComponent;
  let fixture: ComponentFixture<RegisterTruckComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterTruckComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterTruckComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
