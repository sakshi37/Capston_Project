import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = 'https://localhost:44321/api/User';

  constructor(private http: HttpClient) {}

  register(
    firstName: string,
    lastName: string,
    email: string,
    password: string
  ): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/Register`, {
      firstName,
      lastName,
      email,
      password,
    });
  }

  login(email: string, password: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/login`, { email, password });
  }
}
