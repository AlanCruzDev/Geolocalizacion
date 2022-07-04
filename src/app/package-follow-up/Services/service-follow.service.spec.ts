import { TestBed } from '@angular/core/testing';

import { ServiceFollowService } from './service-follow.service';

describe('ServiceFollowService', () => {
  let service: ServiceFollowService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServiceFollowService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
