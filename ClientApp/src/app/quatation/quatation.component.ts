import { QuataionService } from './../shared/quatation.service';
import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import { FormBuilder, FormControl } from '@angular/forms';
import { Category2Service } from '../shared/category2.service';


@Component({
  selector: 'app-quataion',
  templateUrl: './quatation.component.html',
  styleUrls: ['./quatation.component.css']
})
export class QuatationComponent implements OnInit {
  category2List = [];
  quataionList = [];
  QuataionService: any;
  checkoutForm;

  constructor(
    private formBuilder :FormBuilder,
    private cat2Service : Category2Service,
    //private specification : Specification

  ) {
      this.checkoutForm = this.formBuilder.group({
        // Id :'',
        // Category1 :'',
        // Name :'',
        // Description :'',
      })
   }


  ngOnInit(): void {
    this.QuataionService.getQuataion()
    .subscribe(res => this.quataionList = res as []);
    this.getQuataion();
  }

   onSubmit(quataionData){
    this.QuataionService.postSupplier(quataionData.value).subscribe(
      data => console.log('Success!',data),
      error => console.log('Error!',error)
    );
    
  }
  getQuataion(){
    this.QuataionService.getQuataionList()
     .subscribe(res => this.quataionList = res as []);
  }
}

