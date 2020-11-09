import { ItemService } from './../shared/item.service';
import { Component, OnInit } from '@angular/core';
import { SupplierService } from './../shared/supplier.service';
import {ActivatedRoute} from '@angular/router';
import { FormControl } from '@angular/forms';
@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {

  ItemList = [];
  searchText: string;
  category: number;
  constructor(private itemService: ItemService, private route: ActivatedRoute) {
    this.route.queryParams.subscribe((params) => {
     //this.params = params;
    });
  }

  ngOnInit(): void {
    //this.supplierService.getSupplierList()
    //.subscribe(res => this.supplierList = res as []);
    this.getItem();
  }
  getItem(){
    this.itemService.getItemList(this.category, this.searchText)
     .subscribe(res => this.ItemList = res as []);
    //console.log(this.searchText);
  }
}

