import { SpecificationService } from './../shared/specification.service';
import { QuotationService } from './../shared/quotation.service';
import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import { FormBuilder, FormControl } from '@angular/forms';
import { Category2Service } from '../shared/category2.service';


@Component({
  selector: 'app-quotaion',
  templateUrl: './quotation.component.html',
  styleUrls: ['./quotation.component.css']
})
export class QuotationComponent implements OnInit {
  category3;
  quotation: any;
  checkoutForm;
  specification;


  constructor(
    private formBuilder: FormBuilder,
    private cat2Service: Category2Service,
    private QuotationService: QuotationService,
    private SpecificationService: SpecificationService,
    private activeRoute : ActivatedRoute,
  ) {
      //QuotationService.getQuotation().subscribe(
      //   res => this.quotation = res
      // );

   }
  ngOnInit(): void {
    this.activeRoute.queryParams.subscribe(params => {
        console.log(params['id']);
        this.QuotationService.getQuotation(params['id'])
          .subscribe(res =>
            { 
              this.quotation = res;
              console.log(this.quotation);
            });
    });
  }

   onSubmit(quotationData){
   
  }







  getQuotation(){
    this.QuotationService.getQuotation(0)
     .subscribe(res => this.quotation = res as []);
  }
}

