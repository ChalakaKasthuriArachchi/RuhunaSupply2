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
import { AddUserComponent } from './add-user/add-user.component';
import { UserComponent } from './user/user.component';
import { SpecificationCategoryComponent } from './specification-category/specification-category.component';
import { SpecificationComponent } from './specification/specification.component';
import { PurchaseRequestComponent } from './purchase-request/purchase-request.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ViewSpecificationCategoryComponent } from './view-specification-category/view-specification-category.component';
import { ViewSpecificationComponent } from './view-specification/view-specification.component';
//import { PurchaseRequestComponent } from './purchase-request/purchase-request.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AddPurchaseRequestComponent } from './add-purchase-request/add-purchase-request.component';


// import { MatCardModule } from '@angular/material/card';
// import { MatButtonModule} from '@angular/material/button';
// import { MatMenuModule } from '@angular/material/menu';
// import { MatToolbarModule } from '@angular/material/toolbar';
// import { MatIconModule } from '@angular/material/icon';
import { TestingComponent } from './testing/testing.component';




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
    ViewSpecificationCategoryComponent,
    ViewSpecificationComponent,
    DashboardComponent,
    ItemComponent,
    AddPurchaseRequestComponent,
    TestingComponent
    ItemComponent,
    AddUserComponent,
    UserComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    // MatButtonModule,
    // MatMenuModule,
    // MatToolbarModule,
    // MatIconModule,
    // MatCardModule
  ],
  exports: [
    // MatButtonModule,
    // MatMenuModule,
    // MatToolbarModule,
    // MatIconModule,
    // MatCardModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(private supplierService: SupplierService){

  }

}
