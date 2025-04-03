import { Component, inject } from '@angular/core';
import { Loan, LoanService } from '../../../services/loan/loan.service';
import { OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

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

  ngOnInit(): void {
    this.loanService.getUserLoans().subscribe((data) => {
      console.log(data);
      this.loans = data;
    });
  }
}
