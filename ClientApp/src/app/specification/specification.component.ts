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
  category2List = [];
  itemList = [];

  constructor(
    private specificationService: SpecificationService,
    private formBuilder: FormBuilder,
    private category2Service: Category2Service,
    private itemService: ItemService
    )
  {
    this.checkoutForm = this.formBuilder.group({
      Category2: [],
      Item: [],
      Name: '',
      Value: '',
    });
  }

  ngOnInit(): void {
    this.category2Service.getCategory2List(0)
      .subscribe(
        res => this.category2List = res as []
    );

    this.itemService.getItemList(null,null)
      .subscribe(
        res => this.itemList=res as[]
      );
  }

  onSubmit(specificationData) {
    this.specificationService.postSpecification(specificationData.value)
      .subscribe(
        data => console.log('Success!', data),
        error => console.log('Error', error)
      );
    //console.log('Submitted Successfully', specificationData);
    this.checkoutForm.reset();
  }

  recordSubmit(fg: FormGroup) {
    this.specificationService.postSpecification(fg.value);
  }
}
