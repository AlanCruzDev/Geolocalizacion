import { TestBed } from '@angular/core/testing';

import { ServiceEmployeService } from './service-employe.service';

describe('ServiceEmployeService', () => {
  let service: ServiceEmployeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServiceEmployeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
