import { Component, inject } from '@angular/core';
import {
  BookPaymentService,
  payment,
} from '../../../services/payment/book-payment.service';

@Component({
  selector: 'app-return-book',
  standalone: true,
  imports: [],
  templateUrl: './return-book.component.html',
  styleUrl: './return-book.component.css',
})
export class ReturnBookComponent {
  pay: payment | undefined;
  paymentService = inject(BookPaymentService);
}
// ngOnInit(){
//   this.paymentService.bookPayment.subscribe((data)=>{
//     console.log(data)
//   })
// }
