import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category2Service  } from './../shared/category2.service';
//import { Category1Service  } from './../shared/category1.service';

@Component({
  selector: 'app-category2',
  templateUrl: './category2.component.html',
  styleUrls: ['./category2.component.css']
})
export class Category2Component implements OnInit {
  Category2 = [];
  constructor(private category2Service : Category2Service,private router:Router) { }

  ngOnInit(): void {
    if(localStorage.getItem('token') == null)
        this.router.navigateByUrl('user/login');
    this.getCategory2List();
  }
  getCategory2List(){
    this.category2Service.getCategory2List(0)
      .subscribe(res => this.Category2 = res as []);
  }
}
