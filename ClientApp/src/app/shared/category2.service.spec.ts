import { TestBed } from '@angular/core/testing';

import { Category2Service } from './category2.service';

describe('Category2Service', () => {
  let service: Category2Service;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Category2Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
