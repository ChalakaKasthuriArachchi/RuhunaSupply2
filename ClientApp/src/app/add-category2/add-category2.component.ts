import { importExpr, importType } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { FormBuilder,Validator,FormGroup } from '@angular/forms';
import { Category1Service } from '../shared/category1.service';
import { Category2Service } from '../shared/category2.service';


@Component({
  selector: 'app-add-category2',
  templateUrl: './add-category2.component.html',
  styleUrls: ['./add-category2.component.css']
})
export class AddCategory2Component implements OnInit {
  category2List;
  checkoutForm;
  category1List = [];
  constructor(
    private cat2Service : Category2Service,
    private formBuilder :FormBuilder,
    private cat1Service : Category1Service
     
  ) {
      this.checkoutForm = this.formBuilder.group({
        Id :'',
        Category1 :'',
        Name :'',
        Description :'',
      })
   }

  ngOnInit(): void {
    this.cat1Service.getCategory1List()
    .subscribe(res => this.category1List = res as []
      );
  }
  onSubmit(category2Data){
    this.cat2Service.postCategory2(category2Data.value).subscribe(
      data =>console.log('success',data),
      error =>console.log('error',error)
      );
      
  }
  recordSubmit(fg:FormGroup){
      
    this.cat2Service.postCategory2(fg.value);
    
}

}
