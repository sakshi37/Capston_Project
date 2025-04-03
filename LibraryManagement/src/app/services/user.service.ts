import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Register, RegistrationResponse } from '../models/Register.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private apiUrl = 'https://localhost:44321/api/User/Login';

  constructor(private http: HttpClient) {}

  register(user: Register): Observable<RegistrationResponse> {
    return this.http.post<RegistrationResponse>(
      `${this.apiUrl}/Register`,
      user
    );
  }
}
