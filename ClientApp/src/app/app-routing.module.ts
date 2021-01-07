import { QuotationComponent } from './quotation/quotation.component';
import { PurchaseRequestComponent } from './purchase-request/purchase-request.component';
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
import { SpecificationComponent } from './specification/specification.component';
import { SpecificationCategoryComponent } from './specification-category/specification-category.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { TestingComponent } from './testing/testing.component';
import { AddPurchaseRequestComponent } from './add-purchase-request/add-purchase-request.component';
import { AddUserComponent } from './add-user/add-user.component';
import { UserComponent } from './user/user.component';
import { ViewQuotationComponent } from './view-quotation/view-quotation.component';


const routes: Routes = [
  { path: '', component : DashboardComponent },
  {path: 'createaccount',component : UserAccountComponent},
  { path: 'category1', component: Category1Component },
  { path: 'category1/add', component: AddCategory1Component },
  { path: 'category1/view', component: AddCategory1Component },
  { path: 'category2', component: Category2Component },
  { path: 'category2/add', component: AddCategory2Component },
  { path: 'category2/view', component: AddCategory2Component },
  { path: 'category3', component: Category3Component },
  { path: 'category3/add', component: AddCategory3Component },
  { path: 'category3/view', component: AddCategory3Component },
  { path: 'user/login', component: LoginComponent },
  { path: 'user/signup',component : UserAccountComponent},
  { path: 'supplier', component: SuppliersComponent },
  { path: 'supplier/register', component: RegisterSupplierComponent },
  { path: 'createaccount', component: UserAccountComponent },
  { path: 'item', component: ItemComponent },
  { path: 'item/new', component: AddItemComponent },
  { path: 'item/add', component: AddItemComponent },
  { path: 'purchaserequest', component: PurchaseRequestComponent },
  { path: 'specification',component : SpecificationComponent},
  { path: 'specification-category',component : SpecificationCategoryComponent},
  { path: 'item', component: ItemComponent },
  { path: 'purchaserequest/add', component: AddPurchaseRequestComponent },
  { path: 'testing', component: TestingComponent},
  { path: 'user/register',component : AddUserComponent},
  { path: 'user/view',component : AddUserComponent},
  { path: 'user',component : UserComponent},
  { path: 'quotation/view', component:ViewQuotationComponent},
  { path: 'testing', component: TestingComponent},
  { path: 'quotation', component: QuotationComponent},
  { path: 'purchaserequest/view', component: AddPurchaseRequestComponent }
];

@NgModule({
  imports: [CommonModule, RouterModule.forRoot(routes), BrowserModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
