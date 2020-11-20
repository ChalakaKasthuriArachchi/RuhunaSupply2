import { TestBed } from '@angular/core/testing';

import { SpecificationCategoryService } from './specification-category.service';

describe('SpecificationCategoryService', () => {
  let service: SpecificationCategoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SpecificationCategoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
