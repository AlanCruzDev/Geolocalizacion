import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterInchargeComponent } from './register-incharge.component';

describe('RegisterInchargeComponent', () => {
  let component: RegisterInchargeComponent;
  let fixture: ComponentFixture<RegisterInchargeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterInchargeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterInchargeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
