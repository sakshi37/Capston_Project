import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
  Book,
  BookServiceService,
} from '../../../services/book-service.service';

@Component({
  selector: 'app-loan-com',
  standalone: true,
  imports: [],
  templateUrl: './loan-com.component.html',
  styleUrl: './loan-com.component.css',
})
export class LoanComComponent {
  bookId: string | undefined;
  book: Book | undefined;
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
      this.book = data;
    });
    console.log(this.bookId);
  }
}
