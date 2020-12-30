import { TestBed } from '@angular/core/testing';

import { QuationService } from './quotation.service';

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
