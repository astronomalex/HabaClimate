import {Component, Input, OnInit} from '@angular/core';
import {ShopCartItem} from "../../_models/ShopCartItem";
import {Good} from "../../_models/Good";

@Component({
  selector: 'app-shop-cart-item',
  templateUrl: './shop-cart-item.component.html',
  styleUrls: ['./shop-cart-item.component.css']
})
export class ShopCartItemComponent implements OnInit {
  @Input() item: ShopCartItem;

  constructor() { }

  ngOnInit(): void {
  }

}
