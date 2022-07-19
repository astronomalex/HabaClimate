import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Good} from "../../_models/Good";
import {environment} from "../../../environments/environment";

@Component({
  selector: 'app-conditioner-card',
  templateUrl: './conditioner-card.component.html',
  styleUrls: ['./conditioner-card.component.css']
})
export class ConditionerCardComponent implements OnInit {
  @Input() good: Good;
  @Output() addToCartEvent = new EventEmitter<Good>();
  img: string;

  constructor() { }

  ngOnInit(): void {
    this.img = environment.hostUrl + this.good.img;
  }

  addToCart(): void {
    this.addToCartEvent.emit(this.good);
  }
}
