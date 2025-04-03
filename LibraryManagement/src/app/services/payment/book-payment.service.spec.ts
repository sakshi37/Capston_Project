import { TestBed } from '@angular/core/testing';

import { BookPaymentService } from './book-payment.service';

describe('BookPaymentService', () => {
  let service: BookPaymentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookPaymentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
