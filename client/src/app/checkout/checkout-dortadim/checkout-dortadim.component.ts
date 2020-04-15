import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BasketService } from 'src/app/basket/basket.service';
import { Observable, BehaviorSubject } from 'rxjs';
import { IBasketTotals } from 'src/app/shared/models/basket';

@Component({
  selector: 'app-checkout-dortadim',
  templateUrl: './checkout-dortadim.component.html',
  styleUrls: ['./checkout-dortadim.component.scss']
})
export class CheckoutDortadimComponent implements OnInit {
  @Input() checkoutForm: FormGroup;
  dortadim = 0.0;
  basketTotal$: Observable<IBasketTotals>;

  constructor(private basketService: BasketService) {}

  ngOnInit(): void {
    this.basketTotal$ = this.basketService.basketTotal$;
  }

  getCheckout() {}

  setDortadimPrice(dortadim: number) {
    this.basketService.setDortadimPrice(dortadim);
  }

  private roundUp(a: number, b: number) {
    return Math.ceil(a / b) * b;
  }
  private subTotal(a: number) {
    const bes = this.roundUp(a, 5);
    if (bes - a <= 1.8) {
      const cs = this.roundUp(a, 10);
      return cs;
    }
    return bes;
  }
}
