import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {BsDropdownModule} from 'ngx-bootstrap/dropdown';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { ConditionerListComponent } from './conditioners/conditioner-list/conditioner-list.component';
import { ConditionerDetailComponent } from './conditioners/conditioner-detail/conditioner-detail.component';
import { ListsComponent } from './lists/lists.component';
import { ContactsComponent } from './help/contacts/contacts.component';

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
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
