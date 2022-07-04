import { TestBed } from '@angular/core/testing';

import { NewpassSericesService } from './newpass-serices.service';

describe('NewpassSericesService', () => {
  let service: NewpassSericesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NewpassSericesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
