import { TestBed } from '@angular/core/testing';

import { QuationService } from './quation.service';

describe('QuationService', () => {
  let service: QuationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(QuationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
