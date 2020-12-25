import { TestBed } from '@angular/core/testing';

import { ViewSpecificationCategoryService } from './view-specification-category.service';

describe('ViewSpecificationCategoryService', () => {
  let service: ViewSpecificationCategoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ViewSpecificationCategoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
