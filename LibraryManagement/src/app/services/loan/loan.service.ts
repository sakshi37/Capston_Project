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
