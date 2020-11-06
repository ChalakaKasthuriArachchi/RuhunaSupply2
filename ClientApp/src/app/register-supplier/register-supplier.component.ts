import { Component, OnInit } from '@angular/core';
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

  constructor(
    private supplierService : SupplierService,
    private formBuilder : FormBuilder
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
    
  }

  onSubmit(supplierData){
    this.supplierService.postSupplier(supplierData.value)
      .subscribe(
        data => console.log('Success!',data),
        error => console.log('Error!',error)
      );
    //this.checkoutForm.reset();
  }
  recordSubmit(fg:FormGroup){
      
      this.supplierService.postSupplier(fg.value);
      
  }
}
