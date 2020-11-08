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

@NgModule({
  declarations: [
    AppComponent,
    SuppliersComponent,
    RegisterSupplierComponent,
    AddCategory1Component,
    Category1Component
    UserAccountComponent
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
  constructor(private supplierService : SupplierService){

  }
  
}
