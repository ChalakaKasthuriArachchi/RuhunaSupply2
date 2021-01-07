import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SpecificationCategoryService } from './../shared/specification-category.service';
import { ItemService } from './../shared/item.service';

@Component({
  selector: 'app-view-specification-category',
  templateUrl: './view-specification-category.component.html',
  styleUrls: ['./view-specification-category.component.css']
})
export class ViewSpecificationCategoryComponent implements OnInit {
  ViewSpecification=[];
  constructor(private SpecificationCategoryService : SpecificationCategoryService, private router : Router ) { }

  ngOnInit(): void {
    if(localStorage.getItem('token') == null)
    this.router.navigateByUrl('user/login');
    this.getSpecificationCatList();
  }
  getSpecificationCatList(){
    this.SpecificationCategoryService.getSpecificationCatList()
      .subscribe(res => this.ViewSpecification = res as []);
  }

}
