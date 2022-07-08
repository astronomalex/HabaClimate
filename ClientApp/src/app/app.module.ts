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
    ContactsComponent
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
    })
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
