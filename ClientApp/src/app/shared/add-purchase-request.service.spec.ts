import { TestBed } from '@angular/core/testing';

import { AddPurchaseRequestService } from './add-purchase-request.service';

describe('AddPurchaseRequestService', () => {
  let service: AddPurchaseRequestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddPurchaseRequestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
