import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearcresultsComponent } from './searcresults.component';

describe('SearcresultsComponent', () => {
  let component: SearcresultsComponent;
  let fixture: ComponentFixture<SearcresultsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearcresultsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearcresultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
