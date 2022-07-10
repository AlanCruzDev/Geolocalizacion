import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateemployesComponent } from './createemployes.component';

describe('CreateemployesComponent', () => {
  let component: CreateemployesComponent;
  let fixture: ComponentFixture<CreateemployesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateemployesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateemployesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
