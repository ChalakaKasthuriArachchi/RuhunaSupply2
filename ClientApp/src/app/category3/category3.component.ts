import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category3Service  } from './../shared/category3.service';
@Component({
  selector: 'app-category3',
  templateUrl: './category3.component.html',
  styleUrls: ['./category3.component.css']
})
export class Category3Component implements OnInit {
  Category3 = [];
  constructor(private Category3Service : Category3Service,private router : Router) { }

  ngOnInit(): void {
    if(localStorage.getItem('token') == null)
    this.router.navigateByUrl('user/login');
    this.getCategory3List();
  }
  getCategory3List(){
    this.Category3Service.getCategory3List(0,0)
      .subscribe(res => this.Category3 = res as []);
  }
}
