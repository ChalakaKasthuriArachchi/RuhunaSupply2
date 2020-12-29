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

  ) {
      QuotationService.getQuotation().subscribe(
        res => this.quotation = res
      );

   }
   


  ngOnInit(): void {
    this.QuotationService.getQuotation()
    .subscribe(res => this.quotation = res as []);
    this.getQuotation();
  }

   onSubmit(quotationData){
    this.QuotationService.postSupplier(quotationData.value).subscribe(
      data => console.log('Success!', data),
      error => console.log('Error!', error)
    );
  }
  getQuotation(){
    this.QuotationService.getQuotation()
     .subscribe(res => this.quotation = res as []);
  }
}

