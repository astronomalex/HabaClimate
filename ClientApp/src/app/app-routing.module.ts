import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {HomeComponent} from './home/home.component';
import {RegisterComponent} from './register/register.component';
import {AdminPanelComponent} from './admin-panel/admin-panel.component';
import {ConditionerListComponent} from './conditioners/conditioner-list/conditioner-list.component';
import {ListsComponent} from './lists/lists.component';
import {ContactsComponent} from './help/contacts/contacts.component';
import {AuthGuard} from './_guards/auth.guard';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'admin-panel', component: AdminPanelComponent, canActivate: [AuthGuard]},
  {path: 'conditioners', component: ConditionerListComponent},
  {path: 'lists', component: ListsComponent},
  {path: 'contacts', component: ContactsComponent},
  {path: '**', component: HomeComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
