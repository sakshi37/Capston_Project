import { RouterModule, Routes } from '@angular/router';
import { LoanComComponent } from './component/loan/loan-com/loan-com.component';
import { RegisterComponent } from './component/register/register.component';
import { GetAllBooksComponent } from './component/get-all-books/get-all-books.component';
import { NgModule } from '@angular/core';
import { LoginComponent } from './component/login/login.component';

import { AllLoansComponent } from './component/loan/all-loans/all-loans.component';
import { ReturnBookComponent } from './component/payment/return-book/return-book.component';

export const routes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: 'books', component: GetAllBooksComponent },
  { path: 'login', component: LoginComponent },
  { path: 'loan/:bookId', component: LoanComComponent },
  { path: '', redirectTo: 'books', pathMatch: 'full' },
  { path: 'loans', component: AllLoansComponent },
  { path: 'payment', component: ReturnBookComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  declarations: [],
})
export class AppRoutingModule {}
