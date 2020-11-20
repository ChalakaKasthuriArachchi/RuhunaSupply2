import { PurchaseRequestService } from './../shared/purchase-request.service';
import { Component, OnInit, NgModule } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-purchase-request',
  templateUrl: './purchase-request.component.html',
  styleUrls: ['./purchase-request.component.css']
})

export class PurchaseRequestComponent implements OnInit {

    PurchaseRequestList;
    checkoutForm;


  constructor(
    private PurchaseRequestService : PurchaseRequestService,
    private formBuilder : FormBuilder,
    
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

  onSubmit(PurchaseRequestData){
    this.PurchaseRequestService.postPurchaseRequest(PurchaseRequestData.value)
      .subscribe(
        data => console.log('Success!',data),
        error => console.log('Error!',error)
      );
  }
  recordSubmit(fg:FormGroup){
      this.PurchaseRequestService.postPurchaseRequest(fg.value);
  }
}
