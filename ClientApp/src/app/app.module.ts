import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {BsDropdownModule} from 'ngx-bootstrap/dropdown';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { ConditionerListComponent } from './conditioners/conditioner-list/conditioner-list.component';
import { ConditionerDetailComponent } from './conditioners/conditioner-detail/conditioner-detail.component';
import { ListsComponent } from './lists/lists.component';
import { ContactsComponent } from './help/contacts/contacts.component';
import {ToastrModule} from 'ngx-toastr';
import {NavComponent} from "./nav/nav.component";
import {AppRoutingModule} from "./app-routing.module";
import {AuthInterceptor} from "./_helpers/auth.interceptor";
import { ConditionerCardComponent } from './conditioners/conditioner-card/conditioner-card.component';
import { ConditionersPageComponent } from './conditioners/conditioners-page/conditioners-page.component';
import { ShopCartComponent } from './shop-cart/shop-cart.component';
import { ShopCartItemComponent } from './shop-cart/shop-cart-item/shop-cart-item.component';
import { OrderComponent } from './order/order/order.component';
import { OrderEditComponent } from './order/order-edit/order-edit.component';
import {MatCardModule} from "@angular/material/card";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button";
import {MatDialogModule} from "@angular/material/dialog";

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    AdminPanelComponent,
    RegisterComponent,
    HomeComponent,
    ConditionerListComponent,
    ConditionerDetailComponent,
    ListsComponent,
    ContactsComponent,
    ConditionerCardComponent,
    ConditionersPageComponent,
    ShopCartComponent,
    ShopCartItemComponent,
    OrderComponent,
    OrderEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDialogModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
