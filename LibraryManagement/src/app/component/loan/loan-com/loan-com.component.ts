import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
  Book,
  BookServiceService,
} from '../../../services/book-service.service';
import { DatePipe, CurrencyPipe } from '@angular/common';
import { CommonModule, NgIf } from '@angular/common';

@Component({
  selector: 'app-loan-com',
  standalone: true,
  imports: [DatePipe, CurrencyPipe, NgIf, CommonModule],
  templateUrl: './loan-com.component.html',
  styleUrl: './loan-com.component.css',
})
export class LoanComComponent {
  bookId: string | undefined;
  book: Book | undefined;
  formattedPublishedDate: Date | null = null;
  errorMessage: string | null = null;
  isLoading: boolean = true;
  constructor(
    private route: ActivatedRoute,
    private bookService: BookServiceService
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
  }
}
