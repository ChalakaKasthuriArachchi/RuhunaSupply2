import { TestBed } from '@angular/core/testing';

import { Category1Service } from './category1.service';

describe('Category1Service', () => {
  let service: Category1Service;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Category1Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
