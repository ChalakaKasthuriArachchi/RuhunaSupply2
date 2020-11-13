import { Category1Service } from './../shared/category1.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validator, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent implements OnInit {

  CategoryList;
  checkoutForm;

  constructor(
              private addCategory1Service: Category1Service,
              private formBuilder: FormBuilder)

              {
                this.checkoutForm = this.formBuilder.group({
                  Id: '',
                  Name: '',
                  Discription: ''
                });
              }

  ngOnInit(): void {
  }
  onSubmit(category1Data){
    this.addCategory1Service.postCategory1(category1Data.value).subscribe(
      data => console.log('success!', data),
      error => console.log('error', error)
    );
  }
  recordSubmit(fg: FormGroup){
    this.addCategory1Service.postCategory1(fg.value);
}

}
