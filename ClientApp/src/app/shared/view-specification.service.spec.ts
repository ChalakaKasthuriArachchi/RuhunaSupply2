import { TestBed } from '@angular/core/testing';

import { ViewSpecificationService } from './view-specification.service';

describe('ViewSpecificationService', () => {
  let service: ViewSpecificationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ViewSpecificationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
