import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BookPaymentService {
  constructor(private http: HttpClient) {}

  bookPayment(loanId: number) {
    return this.http.post('https://localhost:44321/api/Payment', {
      loanId: loanId,
    });
  }
}

export type payment = {
  loanId: number;
};
