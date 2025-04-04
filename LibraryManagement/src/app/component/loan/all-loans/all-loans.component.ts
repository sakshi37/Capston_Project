import { Component, inject } from '@angular/core';
import { Loan, LoanService } from '../../../services/loan/loan.service';
import { OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookPaymentService } from '../../../services/payment/book-payment.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-all-loans',
  standalone: true,
  imports: [CommonModule],

  templateUrl: './all-loans.component.html',
  styleUrl: './all-loans.component.css',
})
export class AllLoansComponent implements OnInit {
  loans: Loan[] = [];
  loanService = inject(LoanService);
  bookpaymentService = inject(BookPaymentService);
  router = inject(Router);
  route = inject(ActivatedRoute);

  ngOnInit(): void {
    this.loanService.getUserLoans().subscribe((data) => {
      console.log(data);
      this.loans = data;
    });
  }

  makePayment(loanId: number) {
    this.bookpaymentService.bookPayment(loanId).subscribe((data) => {
      console.log(data);
      this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
        this.router.navigate([this.route.snapshot.url.join('/')]);
      });
    });
  }
}
