import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {OrderDto} from "../../_models/OrderDto";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-order-edit',
  templateUrl: './order-edit.component.html',
  styleUrls: ['./order-edit.component.css']
})
export class OrderEditComponent implements OnInit {
  @Output() submitOrder = new EventEmitter<OrderDto>();
  orderFormControl = new FormGroup({
    name: new FormControl('', [Validators.required]),
    surname: new FormControl(''),
    phone: new FormControl('',[Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
  });
  constructor() { }

  ngOnInit(): void {
  }

  onSubmit() {

  }

  get p(){
    return this.orderFormControl.controls;
  }

}
