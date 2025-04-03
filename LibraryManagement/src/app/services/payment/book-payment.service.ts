import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class BookPaymentService {
  constructor(private http: HttpClient) {}

  bookPayment() {
    return this.http.get<payment>('https://localhost:44321/api/Payment');
  }
}

export type payment = {
  loanId: number;
};
