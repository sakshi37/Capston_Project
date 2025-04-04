import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  firstName: string = '';
  lastName: string = '';
  email: string = '';
  password: string = '';
  // confirmPassword: string = '';
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  onRegister() {
    this.authService
      .register(this.firstName, this.lastName, this.email, this.password)
      .subscribe({
        next: (res) => {
          alert('Registration Successful!');
          this.router.navigate(['/login']);
        },
        error: (err) => {
          if (err.status === 400 && err.error?.errors) {
            this.errorMessage = err.error.errors[0];
            alert(this.errorMessage); // Show user-friendly error
          } else if (err.status === 200) {
            alert('Registration Successful');
            this.router.navigate(['/login']);
          } else {
            this.errorMessage = 'An unexpected error occurred.';
            console.error(err);
          }
        },
      });
  }
}
