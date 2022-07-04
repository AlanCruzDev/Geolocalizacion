import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PackaListComponent } from './packa-list.component';

describe('PackaListComponent', () => {
  let component: PackaListComponent;
  let fixture: ComponentFixture<PackaListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PackaListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PackaListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
