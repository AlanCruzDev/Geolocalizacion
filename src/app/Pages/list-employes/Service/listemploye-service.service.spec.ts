import { TestBed } from '@angular/core/testing';

import { ListemployeServiceService } from './listemploye-service.service';

describe('ListemployeServiceService', () => {
  let service: ListemployeServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ListemployeServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
