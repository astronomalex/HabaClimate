import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {ShopCartItem} from "../_models/ShopCartItem";
import {BehaviorSubject, Observable} from "rxjs";
import {Good} from "../_models/Good";

@Injectable({
  providedIn: 'root'
})
export class ShopCartService {
  shopCartUrl = environment.apiUrl + 'shopcart/';
  public cartItems: ShopCartItem[] = [];
  public goodList = new BehaviorSubject<any>([]);

  constructor(private http: HttpClient) {}

  setGoods(shopCartItems: ShopCartItem[]) {
    this.cartItems = shopCartItems;
    this.goodList.next(shopCartItems);
  }

  addToCart(good: Good): boolean {
    let index = this.findSameItem(good);
    if (index >= 0) {
      let newCartItems = this.cartItems;
      newCartItems[index].quantity++;
      this.setGoods(newCartItems);
    } else {
      let shopCartItem: ShopCartItem = {
        good: good,
        price: good.price,
        quantity: 1,
        id: 0,
        shopCartId: ""
      }
      this.cartItems.push(shopCartItem);
    }

    this.goodList.next(this.cartItems);
    console.log(this.cartItems);
    return true;
  }

  removeCartItem(cartItem: ShopCartItem) {
    this.cartItems.map((item: ShopCartItem, index: any) => {
      if (cartItem.good.id == item.good.id) {
        if (this.cartItems[index].quantity > 1) {
          this.cartItems[index].quantity --;
        } else {
          this.cartItems.splice(index, 1);
        }
      }
    });
    this.goodList.next(this.cartItems);
  }
  removeAllItems() {
    this.cartItems = [];
    this.goodList.next(this.cartItems);
  }

  findSameItem(good: Good): number {
    return this.cartItems.findIndex((value) => value.good.id === good.id);
  }

  getTotalPrice() : number{
    let grandTotal = 0;
    this.cartItems.map((item: ShopCartItem)=>{
      grandTotal += item.price * item.quantity;
    })
    return grandTotal;
  }

}
