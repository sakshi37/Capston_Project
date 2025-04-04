import { Component, inject } from '@angular/core';
import { Book, BookServiceService } from '../../services/book-service.service';
import { concatWith } from 'rxjs';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-get-all-books',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './get-all-books.component.html',

  styleUrl: './get-all-books.component.css',
})
export class GetAllBooksComponent {
  books: Book[] = [];
  searchTerm: string = '';

  private bookService = inject(BookServiceService);
  authService = inject(AuthService);

  ngOnInit() {
    this.bookService.getBooks().subscribe((data) => {
      console.log(data);

      this.books = data;
    });
  }

  get filteredBooks(): Book[] {
    return this.books.filter((book) =>
      book.title.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }
}
