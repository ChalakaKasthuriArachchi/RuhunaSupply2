import { SpecificationCategoryService } from './../shared/specification-category.service';
import { ItemService } from './../shared/item.service';
import { PurchaseRequestService } from '../shared/purchase-request.service';
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
    itemList = [];
    selectedItems = [];
    specificationCategories = [];

  constructor(
    private AddPurchaseRequestService: PurchaseRequestService,
    private formBuilder: FormBuilder,private itemService : ItemService,
    private specCatService : SpecificationCategoryService

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
  onSubmit(AddPurchaseRequestData){
    this.AddPurchaseRequestService.postPurchaseRequest(AddPurchaseRequestData.value)
      .subscribe(
        data => console.log('Success!', data),
        error => console.log('Error!', error)
      );
  }
  recordSubmit(fg: FormGroup){
      this.AddPurchaseRequestService.postPurchaseRequest(fg.value);
  }
  setItemDetails(event){
    this.specCatService.getSpecificationCategories(event.target.id).subscribe(
      res => this.specificationCategories = res as []
    );
    // var id = this.selectedItems[index].id;
    // this.itemService.getItem(id,false).
    //   subscribe(res => this.selectedItems[index] = res);
  }
}
