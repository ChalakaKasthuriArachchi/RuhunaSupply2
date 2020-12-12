import { Router } from '@angular/router';
import { PurchaseRequestService } from './../shared/purchase-request.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-purchase-request',
  templateUrl: './purchase-request.component.html',
  styleUrls: ['./purchase-request.component.css']
})
export class PurchaseRequestComponent implements OnInit {
  purchaseRequests = [];
  constructor(private service : PurchaseRequestService,private router : Router) { }

  ngOnInit(): void {
    if(localStorage.getItem('token') == null)
        this.router.navigateByUrl('user/login');
    this.getPurchaseRequestList('-1');
  }
  getPurchaseRequestList(status){
    this.service.getPurchaseRequestList(status)
      .subscribe(res => this.purchaseRequests = res as []);
  }
}
