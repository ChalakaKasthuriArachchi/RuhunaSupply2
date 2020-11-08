import { TestBed } from '@angular/core/testing';

import { AddCategory1Service } from './add-category1.service';

describe('AddCategory1Service', () => {
  let service: AddCategory1Service;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddCategory1Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
