import { Category2Service } from './../shared/category2.service';
import { Component, OnInit, NgModule } from '@angular/core';
import { FormBuilder,Validators,FormGroup } from '@angular/forms';
import { SupplierService } from '../shared/supplier.service';



@Component({
  selector: 'app-register-supplier',
  templateUrl: './register-supplier.component.html',
  styleUrls: ['./register-supplier.component.css']
})
export class RegisterSupplierComponent implements OnInit {
  supplierList;
  checkoutForm;
  category2List = [];

  constructor(
    private supplierService : SupplierService,
    private formBuilder : FormBuilder,
    private category2Service : Category2Service
  ) {
    this.checkoutForm = this.formBuilder.group({
      BusinessCategory: '',
      RegistrationNumber: '',
      BusinessName: '',
      RegisteredDate: '',
      BusinessMail: '',
      BusinessAddress: '',
      Category2: [],
      BusinessRegisteredDate: '',
      ContactNumber :''
    });
   }

  ngOnInit(): void {
    this.category2Service.getCategory2List(0)
        .subscribe(
        res => this.category2List = res as []
      );
  }

  onSubmit(supplierData){
    this.supplierService.postSupplier(supplierData.value)
      .subscribe(
        data => console.log('Success!',data),
        error => console.log('Error!',error)
      );
  }
  recordSubmit(fg:FormGroup){
      
      this.supplierService.postSupplier(fg.value);
      
  }
}
