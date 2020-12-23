import { SpecificationCategoryService } from './../shared/specification-category.service';
import { Category2Service } from './../shared/category2.service';
import { ItemService } from './../shared/item.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { SpecificationService } from '../shared/specification.service';

@Component({
  selector: 'app-specification',
  templateUrl: './specification.component.html',
  styleUrls: ['./specification.component.css']
})
export class SpecificationComponent implements OnInit {
  checkoutForm;
  form: FormGroup;
  specCategories = [];
  itemList = [];

  constructor(
    private specificationService: SpecificationService,
    private formBuilder: FormBuilder,
    private specCatService: SpecificationCategoryService,
    private itemService: ItemService
    )
  {
    this.checkoutForm = this.formBuilder.group({
      SpecCategory: '',
      Item: '',
      Name: '',
      Value: '',
    });
  }

  ngOnInit(): void {
    
    this.itemService.getItemList(0,null,false)
      .subscribe(
        res => this.itemList=res as[]
      );
  }

  onSubmit(fg: FormGroup) {
    console.log(fg.value);
    this.specificationService.postSpecification(fg.value)
      .subscribe(
        data => console.log('Success!', data),
        error => console.log('Error', error)
      );
    (<HTMLInputElement>document.getElementById('Name')).value = '';
    (<HTMLInputElement>document.getElementById('Value')).value = '';
  }

  recordSubmit(fg: FormGroup) {
    this.specificationService.postSpecification(fg.value);
  }
  onItemSelect(fg: FormGroup){
    this.specCatService.getSpecificationCategories(fg.value.Item)
    .subscribe(
      res => this.specCategories = res as []
  );
  }
}
