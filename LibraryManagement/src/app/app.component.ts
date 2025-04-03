import { Component } from '@angular/core';

import { RouterModule, RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RegisterComponent } from './component/register/register.component';
import { GetAllBooksComponent } from './component/get-all-books/get-all-books.component';
import { LoginComponent } from '../app/component/login/login.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    RouterModule,
    RegisterComponent,
    GetAllBooksComponent,
    LoginComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'LibraryManagement';
}
