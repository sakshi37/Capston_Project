import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BookServiceService {
  constructor(private http: HttpClient) {}

  getBooks() {
    return this.http.get<Book[]>('https://localhost:44321/api/Books');
  }

  getBookById(id: string) {
    return this.http.get<Book>('https://localhost:44321/api/Books/' + id);
  }
}

export type Book = {
  id: number;
  title: string;
  description: string;
  publishedDate: string;
  price: number;
  authorId: number;
};
