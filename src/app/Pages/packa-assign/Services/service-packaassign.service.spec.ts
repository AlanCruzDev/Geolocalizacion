import { TestBed } from '@angular/core/testing';

import { ServicePackaassignService } from './service-packaassign.service';

describe('ServicePackaassignService', () => {
  let service: ServicePackaassignService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServicePackaassignService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
