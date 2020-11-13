import { SupplierService } from './../shared/supplier.service';
import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.css']
})
export class SuppliersComponent implements OnInit {

  supplierList = [];
  searchText : string;
  category : number;
  constructor(private supplierService : SupplierService,private route : ActivatedRoute) { 
    this.route.queryParams.subscribe((params) => {
     //this.params = params;
    })
  }

  ngOnInit(): void {
    //this.supplierService.getSupplierList()
    //.subscribe(res => this.supplierList = res as []);
    this.getSuppliers();
  }
  getSuppliers(){
    this.supplierService.getSupplierList(this.category,this.searchText)
     .subscribe(res => this.supplierList = res as []);
  }
}
