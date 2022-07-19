import {Component, OnDestroy, OnInit} from '@angular/core';
import {Good} from "../../_models/Good";
import {Subject, take, takeUntil} from "rxjs";
import {ConditionersService} from "../../_services/conditioners.service";
import {ShopCartService} from "../../_services/shop-cart.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-conditioners-page',
  templateUrl: './conditioners-page.component.html',
  styleUrls: ['./conditioners-page.component.css']
})
export class ConditionersPageComponent implements OnInit, OnDestroy {
  goods: Good[];

  ngUnsubscribe$ = new Subject();

  constructor(private conditionersService: ConditionersService,
               private shopCartService: ShopCartService,
              private toastr: ToastrService) { }

  ngOnInit(): void {
    this.updateInfo();
  }

  ngOnDestroy() {
    this.ngUnsubscribe$.complete();
  }

  updateInfo(): void {
    this.conditionersService.getGoods().pipe(takeUntil(this.ngUnsubscribe$)).subscribe( goods => {
      this.goods = goods;
    })
  }

  addGoogToCart(good: Good) {
    if (this.shopCartService.addToCart(good)) {
      this.toastr.info('Успешно добавлено в корзину', 'Ok');
    }
  }

}
