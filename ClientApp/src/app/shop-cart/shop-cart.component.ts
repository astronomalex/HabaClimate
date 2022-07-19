import {Component, OnDestroy, OnInit} from '@angular/core';
import {ShopCartService} from "../_services/shop-cart.service";
import {first, Subject, take, takeUntil} from "rxjs";
import {ToastrService} from "ngx-toastr";
import {ShopCartItem} from "../_models/ShopCartItem";
import {Good} from "../_models/Good";
import {environment} from "../../environments/environment";
import {MatDialog} from "@angular/material/dialog";
import {OrderEditComponent} from "../order/order-edit/order-edit.component";
import {OrderDto} from "../_models/OrderDto";

@Component({
  selector: 'app-shop-cart',
  templateUrl: './shop-cart.component.html',
  styleUrls: ['./shop-cart.component.css']
})
export class ShopCartComponent implements OnInit, OnDestroy {
  items: ShopCartItem[] = [];
  ngUnsubscribe$ = new Subject();
  public grandTotal !: number;
  hostUrl = environment.hostUrl

  constructor(private shopCartService: ShopCartService,
              private toastr: ToastrService,
              private dialog: MatDialog) {

  }

  ngOnInit(): void {
    this.getItems();
  }

  ngOnDestroy() {
    this.ngUnsubscribe$.complete();
  }

  public getItems() {
    this.shopCartService.goodList.pipe(first()).subscribe(goods => {
      this.items = goods;
      this.grandTotal = this.shopCartService.getTotalPrice();
      console.log(this.items);
    })
  }

  removeItem(item: any) {
    this.shopCartService.removeCartItem(item);
    this.getItems();
  }

  emptycart() {
    this.shopCartService.removeAllItems();
    this.getItems();
  }

  openDialog() {
    let dialogRef = this.dialog.open(OrderEditComponent, {});

    dialogRef.afterClosed().subscribe(result => {
      this.submitOrder(result);
    });
  }

  submitOrder(orderDto: OrderDto) {

  }

}
