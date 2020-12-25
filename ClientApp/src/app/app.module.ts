import { SupplierService } from './shared/supplier.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SuppliersComponent } from './suppliers/suppliers.component';
import { RegisterSupplierComponent } from './register-supplier/register-supplier.component';
import { AddCategory1Component } from './add-category1/add-category1.component';
import { Category1Component } from './category1/category1.component';
import { UserAccountComponent } from './user-account/user-account.component';
import { AddCategory2Component } from './add-category2/add-category2.component';
import { Category2Component } from './category2/category2.component';
import { AddCategory3Component } from './add-category3/add-category3.component';
import { Category3Component } from './category3/category3.component';
import { LoginComponent } from './user-account/login/login.component';
import { UserAccountService } from './shared/user-account.service';
import { AddItemComponent } from './add-item/add-item.component';
import { ItemComponent } from './item/item.component';
import { SpecificationCategoryComponent } from './specification-category/specification-category.component';
import { SpecificationComponent } from './specification/specification.component';
import { PurchaseRequestComponent } from './purchase-request/purchase-request.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ViewSpecificationCategoryComponent } from './view-specification-category/view-specification-category.component';
import { ViewSpecificationComponent } from './view-specification/view-specification.component';

@NgModule({
  declarations: [
     AppComponent,
    SuppliersComponent,
    RegisterSupplierComponent,
    UserAccountComponent,
    LoginComponent,
    AddCategory1Component,
    Category1Component,
    UserAccountComponent,
    AddCategory2Component,
    Category2Component,
    AddCategory3Component,
    Category3Component,
    Category1Component,
    AddItemComponent,
    ItemComponent,
    UserAccountComponent,
    SpecificationCategoryComponent,
    SpecificationComponent,
    PurchaseRequestComponent,
    DashboardComponent,
    ViewSpecificationCategoryComponent,
    ViewSpecificationComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(private supplierService: SupplierService){

  }

}
