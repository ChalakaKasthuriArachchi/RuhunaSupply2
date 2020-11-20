import { AddPurchaseRequestService } from '../shared/add-purchase-request.service';
import { Component, OnInit, NgModule } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'add-app-purchase-request',
  templateUrl: './add-purchase-request.component.html',
  styleUrls: ['./add-purchase-request.component.css']
})

export class AddPurchaseRequestComponent implements OnInit {

    PurchaseRequestList;
    checkoutForm;


  constructor(
    private AddPurchaseRequestService: AddPurchaseRequestService,
    private formBuilder: FormBuilder,

  ) {
    this.checkoutForm = this.formBuilder.group({
      InputFaculty: '',
      Funds: '',
      Project: '',
      Vote: '',
      Procument: '',
      Purpose: '',
      date: ''
    });
   }
   ngOnInit(): void {}

  // ngOnInit(): void {
  //   this.category2Service.getCategory2List(0)
  //       .subscribe(
  //       res => this.category2List = res as []
  //     );
  // }

  onSubmit(AddPurchaseRequestData){
    this.AddPurchaseRequestService.postAddPurchaseRequest(AddPurchaseRequestData.value)
      .subscribe(
        data => console.log('Success!', data),
        error => console.log('Error!', error)
      );
  }
  recordSubmit(fg: FormGroup){
      this.AddPurchaseRequestService.postAddPurchaseRequest(fg.value);
  }
}
