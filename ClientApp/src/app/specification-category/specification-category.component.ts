import { ItemService } from './../shared/item.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { SpecificationCategoryService } from '../shared/specification-category.service';


@Component({
  selector: 'app-specification-category',
  templateUrl: './specification-category.component.html',
  styleUrls: ['./specification-category.component.css']
})
export class SpecificationCategoryComponent implements OnInit {
  checkoutForm;
  form: FormGroup;
  itemList = [];
  constructor(
    private specificationCategoryService: SpecificationCategoryService,
    private formBuilder: FormBuilder,
    private itemService: ItemService
  )
  {
    this.checkoutForm = this.formBuilder.group({
      Item: [],
      Title: '',
      Description: '',
    });
  }

  ngOnInit(): void {
    this.itemService.getItemList(0,null,false)
      .subscribe(
        res => this.itemList = res as []
      );
  }

  onSubmit(specificationCategoryData) {
    this.specificationCategoryService.postSpecificationCategory(specificationCategoryData.value)
      .subscribe(
        data => console.log('Success!', data),
        error => console.log('Error', error)
      );
    this.checkoutForm.reset();
  }

  recordSubmit(fg: FormGroup) {
    this.specificationCategoryService.postSpecificationCategory(fg.value);
  }
}
