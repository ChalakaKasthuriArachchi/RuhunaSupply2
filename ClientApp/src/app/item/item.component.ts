import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ItemService  } from './../shared/item.service';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {
  Item = [];
  constructor(private ItemService : ItemService,private router : Router) { }

  ngOnInit(): void {
    if(localStorage.getItem('token') == null)
    this.router.navigateByUrl('user/login');
    this.getItemList();
  }

  getItemList(){
    this.ItemService.getItemList(0,0,0)
      .subscribe(res => this.Item = res as []);
  }

}
