import { Component } from '@angular/core';

import { Router, RouterModule, RouterOutlet } from '@angular/router';

import { RegisterComponent } from './component/register/register.component';
import { GetAllBooksComponent } from './component/get-all-books/get-all-books.component';
import { LoginComponent } from '../app/component/login/login.component';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    RouterModule,
    RegisterComponent,
    GetAllBooksComponent,
    LoginComponent,
    NgIf,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'LibraryManagement';
  isAuthenticated = false;
}
