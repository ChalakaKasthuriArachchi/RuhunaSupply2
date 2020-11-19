import { Category1Service } from './../shared/category1.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validator, FormGroup } from '@angular/forms';
import { Category2Service } from "./../shared/category2.service";
import { Category3Service } from './../shared/category3.service';
import { ItemService } from "./../shared/item.service";

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent implements OnInit {

  Category1List : [];
  Category2List : [];
  Category3List : [];
  checkoutForm;
  ItemList;

  constructor(
              private Category1Service : Category1Service,
              private formBuilder: FormBuilder,
              private Category2Service : Category2Service,
              private Category3Service : Category3Service,
              private addItemService : ItemService)

              {
                this.checkoutForm = this.formBuilder.group({
                  Id: '',
                  Name: '',
                  Description: '',
                  Category1: '',
                  Category2:'',
                  Category3:''
                });
              }

  ngOnInit(): void {
    this.Category1Service.getCategory1List().subscribe(
      res => this.Category1List = res as []
    );
  }
  onSubmit(itemData){
    this.addItemService.postItem(itemData.value).subscribe(
      data => console.log('success!', data),
      error => console.log('error', error)
    );
  }
  recordSubmit(fg: FormGroup){
    this.addItemService.postItem(fg.value);
  }
  onCategory1Select(fg:FormGroup){
    this.Category2Service.getCategory2List(fg.value.Category1).subscribe(
      res  => this.Category2List = res as []
    );
  }
  onCategory2Select(fg:FormGroup){
    this.Category3Service.getCategory3List(fg.value.Category2,false).subscribe(
      res => this.Category3List = res as []
    );
  }

}
