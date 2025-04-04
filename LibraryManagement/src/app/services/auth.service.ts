import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = 'https://localhost:44321/api/User';
  private tokenKey = 'token';

  private authState = new BehaviorSubject<boolean>(this.hasToken());
  authState$ = this.authState.asObservable();

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

  logout(): void {
    this.setToken(null);
    this.authState.next(false);
  }

  setToken(token: string | null): void {
    localStorage.setItem(this.tokenKey, token || '');
    this.authState.next(!!token);
  }

  hasToken() {
    return !!localStorage.getItem(this.tokenKey);
  }

  isAuthenticated() {
    return this.authState.getValue();
  }
}
