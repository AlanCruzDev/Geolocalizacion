import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PackageFollowUpComponent } from './package-follow-up.component';

describe('PackageFollowUpComponent', () => {
  let component: PackageFollowUpComponent;
  let fixture: ComponentFixture<PackageFollowUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PackageFollowUpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PackageFollowUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
