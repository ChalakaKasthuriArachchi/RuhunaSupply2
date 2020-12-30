import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category1Service  } from './../shared/category1.service';

@Component({
  selector: 'app-category1',
  templateUrl: './category1.component.html',
  styleUrls: ['./category1.component.css']
})
export class Category1Component implements OnInit {
  Category1 = [];
  constructor(private service : Category1Service,private router : Router) { }

  ngOnInit(): void {
    if(localStorage.getItem('token') == null)
        this.router.navigateByUrl('user/login');
    this.getCategory1List();
  }
  getCategory1List(){
    this.service.getCategory1List()
      .subscribe(res => this.Category1 = res as []);
  }
}
