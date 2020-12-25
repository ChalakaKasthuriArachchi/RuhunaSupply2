import { SpecificationCategoryService } from './../shared/specification-category.service';
import { ItemService } from './../shared/item.service';
import { PurchaseRequestService } from '../shared/purchase-request.service';
import { Component, OnInit, NgModule,Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'add-app-purchase-request',
  templateUrl: './add-purchase-request.component.html',
  styleUrls: ['./add-purchase-request.component.css']
})

export class AddPurchaseRequestComponent implements OnInit {
    faculty = 'Science';
    department = 'Computer Science';
    PurchaseRequestList;
    checkoutForm;
    itemList = [];
    selectedItems = [];
    specificationCategories = [];
    allowedForwards = [];

  constructor(
    private PurchaseRequestService: PurchaseRequestService,
    private formBuilder: FormBuilder,private itemService : ItemService,
    private specCatService : SpecificationCategoryService,
    @Inject(DOCUMENT) document
  ) {
    this.checkoutForm = this.formBuilder.group({
      Id : 0,
      Funds: '',
      Project: '',
      Justification: '',
      Vote: '',
      IsInProcumentPlan: '',
      Purpose: 0,
      DateTime: '',
      BudgetAllocation : '',
      IsSaved : false,
    });
   }
   ngOnInit(): void {
      this.itemService.getItemList(0,null,true).subscribe(
        res => this.itemList = res as []
      )
   }

  addNewItem(){
    this.selectedItems.push(
      {
        id : '0',
        name : ''
      }
    )
  }
  onSubmit(event){
    let purchaseRequest = { form : this.checkoutForm.value, items : this.selectedItems, forwardTo : event.target.id};
    console.log(purchaseRequest);
    this.PurchaseRequestService.postPurchaseRequest(purchaseRequest)
      .subscribe(
        data => console.log('Success!', data),
        error => console.log('Error!', error)
      );
  }
  recordSubmit(fg: FormGroup){
      this.PurchaseRequestService.postPurchaseRequest(fg.value);
  }
  addItem(event){
    console.log(event.target);
    this.specCatService.getSpecificationCategories(event.target.id).subscribe(
      res => {
        this.specificationCategories = res as [];
      }
    );
    // var id = this.selectedItems[index].id;
    // this.itemService.getItem(id,false).
    //   subscribe(res => this.selectedItems[index] = res);
  }
  addSpec(event){
    var spec;
    var item;
    this.specCatService.getSpecificationCategoryById(event.target.id).subscribe(
      res =>{ spec = res;
        this.itemService.getItem(spec.item.id,true).subscribe(
          res => {
            item = res;
            item.quantity = (<HTMLInputElement>document.getElementById('qty')).value;
            item.specificationCategoryId = spec.id;
            this.selectedItems.push(item);
          }
        )
      }
    );
  }
  getAllowedForwards(){
    this.PurchaseRequestService.getAllowedForwardsList()
      .subscribe(res => this.allowedForwards = res as []);
  }
}
