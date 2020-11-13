import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormGroup,Validator } from "@angular/forms";
import { Category1Service} from "./../shared/category1.service";
import { Category2Service } from "./../shared/category2.service";
import { Category3Service } from './../shared/category3.service';

@Component({
  selector: 'app-add-category3',
  templateUrl: './add-category3.component.html',
  styleUrls: ['./add-category3.component.css']
})
export class AddCategory3Component implements OnInit {
  Category1List=[];
  Category2List=[];
  Category3List;
  checkoutForm;
  constructor(
    private cat1Service : Category1Service,
    private cat2Service : Category2Service,
    private formBuilder : FormBuilder,
    private cat3Service : Category3Service
  ) {
      this.checkoutForm =this.formBuilder.group({
        Id : '',
        Name : '',
        Description : '',
        Category1 : '',
        Category2 : ''
      })
    }

  ngOnInit(): void {
    this.cat1Service.getCategory1List().subscribe(
      res => this.Category1List = res as []
    );
    
  }
    onSubmit(category3Data)
    {
      this.cat3Service.postCategory3(category3Data.value).subscribe(
        data =>console.log('success',data),
        error =>console.log('error',error)
        
      )
    }
    recordSubmit(fg:FormGroup)
    {
      this.cat3Service.postCategory3(fg.value);
    }
    onCat1Select(fg:FormGroup){
      console.log("OK");
      this.cat2Service.getCategory2List(fg.value.Category1).subscribe(
        res => this.Category2List = res as []
      );
    }
}
