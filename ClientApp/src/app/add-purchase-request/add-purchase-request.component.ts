import { ActivatedRoute, Router } from '@angular/router';
import { SpecificationCategoryService } from './../shared/specification-category.service';
import { ItemService } from './../shared/item.service';
import { PurchaseRequestService } from '../shared/purchase-request.service';
import { Component, OnInit, NgModule,Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { DatePipe, DOCUMENT } from '@angular/common';
import { isDefined } from '@angular/compiler/src/util';
import { UserService } from '../shared/user.service';
import { SupplierService } from '../shared/supplier.service';

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
    purchaseRequsetId = 0;
    myDate = new Date();
    userInvolvements = [];
    user : any;
    suppliers : [];

  constructor(
    private PurchaseRequestService: PurchaseRequestService,
    private formBuilder: FormBuilder,
    private itemService : ItemService,
    private specCatService : SpecificationCategoryService,
    private activeRoute : ActivatedRoute,
    private route : Router,
    private userService : UserService,
    private supplierService : SupplierService,
    @Inject(DOCUMENT) document
  ) {
    this.user = this.userService.getUser().subscribe(
      res => { 
        this.user = res;
        console.log(this.user);
      }
    );
    this.checkoutForm = this.formBuilder.group({
      Id : 0,
      Funds: '',
      Project: '',
      Justification: '',
      Vote: '',
      IsInProcumentPlan: '',
      Purpose: 0,
      DateTime: this.myDate,
      BudgetAllocation : 0,
      UsedAmount : 0,
      AvailableAmount : 0,
      IsSaved : false,
    });
    this.activeRoute.queryParams.subscribe(params => {
      if(isDefined(params['id'])){
        this.purchaseRequsetId = params['id'];
        this.PurchaseRequestService.getPurchaseRequest(this.purchaseRequsetId).subscribe(res => {
          this.checkoutForm = this.formBuilder.group({
            Id : res['purchaseRequest']['id'],
            Funds: '',
            Project: res['purchaseRequest']['project'],
            Justification: res['purchaseRequest']['justification'],
            Vote: res['purchaseRequest']['vote'],
            IsInProcumentPlan: '',
            Purpose: res['purchaseRequest']['purpose'],
            DateTime: res['purchaseRequest']['date'],
            BudgetAllocation : res['purchaseRequest']['budgetAllocation'],
            UsedAmount : res['purchaseRequest']['usedAmount'],
            IsSaved : false,
          });
          this.selectedItems = res['items'] as [];
          this.userInvolvements = res['route'] as [];
        });
      }
    });
    
   }
   ngOnInit(): void {
      this.itemService.getItemList(0,null).subscribe(
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
        data => {
          this.route.navigateByUrl('/purchaserequest')
        },
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
  }
  addSpec(event){
    var spec;
    var item;
    this.specCatService.getSpecificationCategoryById(event.target.id).subscribe(
      res =>{ 
        spec = res;
        this.itemService.getItem(spec.item.id,true).subscribe(
          res => {
            item = res;
            item.quantity = (<HTMLInputElement>document.getElementById('qty')).value;
            item.specificationCategoryId = spec.id;
            item.specificationCategoryName = spec.title;
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
  callQuotations(){

  }
  getSuppliers(){
    this.supplierService.getActiveSupplierList(0).subscribe(
      res => this.suppliers = res as []
    )
  }
  selectSupplier(event){
    
  }
}
