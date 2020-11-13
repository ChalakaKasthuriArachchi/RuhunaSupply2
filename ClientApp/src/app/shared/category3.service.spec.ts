import { TestBed } from '@angular/core/testing';

import { Category3Service } from './category3.service';

describe('Category3Service', () => {
  let service: Category3Service;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Category3Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
