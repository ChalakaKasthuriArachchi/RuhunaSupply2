import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { QuotationService } from './../shared/quotation.service';
@Component({
  selector: 'app-quotation',
  templateUrl: './view-quotation.component.html',
  styleUrls: ['./view-quotation.component.css']
})
export class QuotationComponent implements OnInit {
  Quotation =[];
  constructor(private QuotationService : QuotationService, private router : Router) { }
  ngOnInit(): void {
    if(localStorage.getQuotation('token') == null)
    this.router.navigateByUrl('user/login');
    this.getQuotationList();
  }
  getQuotationList(){
    this.QuotationService.getQuotation(0)
      .subscribe(res => this.Quotation = res as []);
  }

}
