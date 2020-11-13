import { AuthGuard } from './auth/auth.guard';
import { LoginComponent } from './user-account/login/login.component';
import { ItemComponent } from './item/item.component';
import { AddItemComponent } from './add-item/add-item.component';
import { RegisterSupplierComponent } from './register-supplier/register-supplier.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SuppliersComponent } from './suppliers/suppliers.component';
import { AddCategory1Component } from './add-category1/add-category1.component';
import { Category1Component } from './category1/category1.component';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { UserAccountComponent } from './user-account/user-account.component';
import { AddCategory2Component } from './add-category2/add-category2.component';
import { AddCategory3Component } from './add-category3/add-category3.component';
import { Category3Component } from './category3/category3.component';
import { Category2Component } from './category2/category2.component';

const routes: Routes = [
  {path: 'createaccount',component : UserAccountComponent},
  { path: 'category2/add', component: AddCategory2Component },
  { path: 'category2', component: Category2Component },
  { path: 'category3/add', component: AddCategory3Component },
  { path: 'category3', component: Category3Component },
  { path: 'createaccount', component: UserAccountComponent },
  { path: 'user/login', component: LoginComponent },
  { path: 'supplier/register', component: RegisterSupplierComponent },
  { path: 'supplier', component: SuppliersComponent },
  { path: 'category1/add', component: AddCategory1Component },
  { path: 'category1', component: Category1Component },
  { path: 'createaccount', component: UserAccountComponent },
  { path: 'item/add', component: AddItemComponent },
  { path: 'item', component: ItemComponent }
];

@NgModule({
  imports: [CommonModule, RouterModule.forRoot(routes), BrowserModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
