import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Category2Service } from './../shared/category2.service';
import { Input, Component, OnInit, NgModule } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { SupplierService } from '../shared/supplier.service';
import {FormControl } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';



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
    private category2Service : Category2Service,
    public router : Router,

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

  //  @Input()
  // public alerts: Array<IAlert> = [];

  ngOnInit(): void {
    this.category2Service.getCategory2List(0)
        .subscribe(
        //res => this.category2List = res as []
       data => console.log('Success!', data)
      );

  //     this.checkoutForm=this.formBuilder.group({
  //       BusinessName:  ['', Validators.compose([Validators.required, Validators.minLength(3),Validators.maxLength(50)])],
  //       RegistrationNumber:  ['', Validators.compose([Validators.required])],
  //       BusinessAddress:  ['', Validators.compose([Validators.required])],
  //       ContactNumber:  ['', Validators.compose([Validators.required])],
  //       // Password:['',Validators.compose([Validators.required, Validators.minLength(3),Validators.maxLength(50)])],
  //       BusinessMail:['',Validators.compose([Validators.required,Validators.email])],
  //     });
   }

  // onSubmit(supplierData){
  //   this.supplierService.postSupplier(supplierData.value)
  //     .subscribe(
  //       data => console.log('Success!',data),
  //       error => console.log('Error!',error)
  //     ); 
  // }

  onSubmit(fg: FormGroup) {
    console.log(fg.value);
    this.supplierService.postSupplier(fg.value)
      .subscribe(
        data => { 
          console.log('Success!', data);
          const el: HTMLElement = document.getElementById('success_alert');
          el.style.display = 'block';
          const timer: ReturnType<typeof setTimeout> = setTimeout(() =>   el.style.display = 'none', 3000);
         // const resetForm: HTMLFormElement = document.getElementById('checkform');
          fg.reset();
          this.router.navigateByUrl('');
        },

        error => { 
          console.log('error!', error);
          const el: HTMLElement = document.getElementById('error_alert');
          el.style.display = 'block';
          const timer: ReturnType<typeof setTimeout> = setTimeout(() =>   el.style.display = 'none', 3000);
      }
    );
    // (<HTMLInputElement>document.getElementById('Name')).value = '';
    // (<HTMLInputElement>document.getElementById('Value')).value = '';
  }
  // recordSubmit(fg:FormGroup){
      
  //     this.supplierService.postSupplier(fg.value);
      
}
