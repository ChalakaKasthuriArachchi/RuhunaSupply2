import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { QuotationService } from './../shared/quotation.service';
@Component({
  selector: 'app-quotation',
  templateUrl: './view-quotation.component.html',
  styleUrls: ['./view-quotation.component.css']
})
export class ViewQuotationComponent implements OnInit {
  Quotation =[];
  constructor(private QuotationService : QuotationService, private router : Router) { }
  ngOnInit(): void {
    if(localStorage.getItem('token') == null)
    this.router.navigateByUrl('user/login');
    this.getQuotationList();
  }
  getQuotationList(){
    this.QuotationService.getQuotationList()
      .subscribe(res => this.Quotation = res as []);
  }

}
