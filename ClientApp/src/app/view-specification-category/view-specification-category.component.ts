import { SpecificationCategoryService } from './../shared/specification-category.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-view-specification-category',
  templateUrl: './view-specification-category.component.html',
  styleUrls: ['./view-specification-category.component.css']
})
export class ViewSpecificationCategoryComponent implements OnInit {

  specificationcategoryList = [];
  searchText: string;
  item: number;

  constructor(private specificationcategoryService: SpecificationCategoryService, private route: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.getSpecificationcategories();
  }

  getSpecificationcategories() {
    this.specificationcategoryService.getSpecificationCategoryList(this.item, this.searchText)
      .subscribe(res => this.specificationcategoryList = res as []);
  }
}
