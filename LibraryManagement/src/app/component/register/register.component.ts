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
    // if (this.password == this.confirmPassword) {
    this.authService
      .register(this.firstName, this.lastName, this.email, this.password)
      .subscribe({
        next: () => {
          alert('Registration Successful!');
          this.router.navigate(['/login']);
        },
        error: () => {
          this.errorMessage = 'Registration failed!';
          console.log(this.firstName, this.lastName, this.email, this.password);
        },
      });
    // } else {
    //   this.errorMessage = 'Password should be same in both fields';
    // }
  }
}
