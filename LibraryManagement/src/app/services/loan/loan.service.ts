import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class LoanService {
  constructor(private http: HttpClient) {}

  getUserLoans() {
    return this.http.get<Loan[]>('https://localhost:44321/api/Loan');
  }

  calculatePayment(
    bookPrice: number,
    endDate: Date
  ): {
    expectedPayment: number;
    discount: number;
    penalty: number;
  } {
    const startDate = new Date();
    startDate.setHours(0, 0, 0, 0);

    endDate.setHours(23, 59, 59, 999); // Set end date to the end of the day

    const currentDate = new Date();
    currentDate.setHours(0, 0, 0, 0); // Ensure current date is also at the start of the day

    const days = Math.floor(
      (endDate.getTime() - startDate.getTime()) / (1000 * 60 * 60 * 24)
    );
    const rate = 1 / 100;
    const amount = days * rate * bookPrice;

    let total = amount;
    let discount = 0;
    let penalty = 0;

    const diff = Math.ceil(
      (endDate.getTime() - currentDate.getTime()) / (1000 * 60 * 60 * 24)
    );

    const discountRate = 0.5 / 100;
    discount = discountRate * bookPrice;

    const penaltyRate = 2 / 100;
    penalty = penaltyRate * bookPrice;

    return {
      expectedPayment: total,
      discount: discount,
      penalty: penalty,
    };
  }
}
export type Loan = {
  id: number;
  startDate: string;
  endDate: string;
  borrowedAtPrice: number;
  isReturn: boolean;
  bookId: number;
  userId: string;
};
