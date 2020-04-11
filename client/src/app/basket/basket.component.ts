import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BasketService } from './basket.service';
import { IBasket, IBasketItem } from '../shared/models/basket';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {
  basket$: Observable<IBasket>;

  constructor(private basketService: BasketService) {}

  ngOnInit() {
    this.basket$ = this.basketService.basket$;
  }
  removeBasketItem(item: IBasketItem) {
    this.basketService.removeItemFromBasket(item);
  }
  incrementItemQuantity(item: IBasketItem) {
    this.basketService.incerementItemQuantity(item);
  }
  decrementItemQuantity(item: IBasketItem) {
    this.basketService.decrementItemQuantity(item);
  }
}
