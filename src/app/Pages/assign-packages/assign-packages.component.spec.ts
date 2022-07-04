import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignPackagesComponent } from './assign-packages.component';

describe('AssignPackagesComponent', () => {
  let component: AssignPackagesComponent;
  let fixture: ComponentFixture<AssignPackagesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssignPackagesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AssignPackagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
