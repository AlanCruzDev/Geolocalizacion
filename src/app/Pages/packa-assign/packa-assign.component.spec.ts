import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PackaAssignComponent } from './packa-assign.component';

describe('PackaAssignComponent', () => {
  let component: PackaAssignComponent;
  let fixture: ComponentFixture<PackaAssignComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PackaAssignComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PackaAssignComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
