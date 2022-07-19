import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Good} from "../../_models/Good";

@Component({
  selector: 'app-conditioner-list',
  templateUrl: './conditioner-list.component.html',
  styleUrls: ['./conditioner-list.component.css']
})
export class ConditionerListComponent implements OnInit {
  @Input() goods: Good[];
  @Output() addGoodToCartEvent = new EventEmitter<Good>();

  constructor() { }

  ngOnInit(): void {
  }

  addGoodToCart(good: Good) {
    this.addGoodToCartEvent.emit(good);
  }

}
