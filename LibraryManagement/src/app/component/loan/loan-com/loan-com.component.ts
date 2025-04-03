import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
  Book,
  BookServiceService,
} from '../../../services/book-service.service';
import { DatePipe, CurrencyPipe } from '@angular/common';
import { CommonModule, NgIf } from '@angular/common';
import { LoanService } from '../../../services/loan/loan.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-loan-com',
  standalone: true,
  imports: [DatePipe, CurrencyPipe, NgIf, CommonModule, FormsModule],
  templateUrl: './loan-com.component.html',
  styleUrl: './loan-com.component.css',
})
export class LoanComComponent {
  bookId: string | undefined;
  book: Book | undefined;
  formattedPublishedDate: Date | null = null;
  errorMessage: string | null = null;
  isLoading: boolean = true;
  returnDate: string = '';
  expectedPayment: number | null = null;
  discount: number | null = null;
  penalty: number | null = null;

  constructor(
    private route: ActivatedRoute,
    private bookService: BookServiceService,
    private loanService: LoanService
  ) {}

  ngOnInit() {
    this.bookId = this.route.snapshot.params['bookId'];
    if (this.bookId === undefined) {
      return;
    }
    this.bookService.getBookById(this.bookId).subscribe((data) => {
      console.log(data);
      if (data.publishedDate) {
        this.formattedPublishedDate = new Date(data.publishedDate);
      }
      this.book = data;
      this.isLoading = false;
    });
    console.log(this.bookId);

    const price = 100;
    const date = new Date('2025-04-13');
    const cal = this.loanService.calculatePayment(price, date);
    console.log(cal);
  }

  calculateLoan() {
    if (!this.book || !this.returnDate) return;
    const endDate = new Date(this.returnDate);
    const result = this.loanService.calculatePayment(this.book.price, endDate);
    this.expectedPayment = result.expectedPayment;
    this.discount = result.discount;
    this.penalty = result.penalty;
  }
}
