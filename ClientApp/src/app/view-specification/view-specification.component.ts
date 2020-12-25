import { SpecificationService } from '../shared/specification.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormControl } from '@angular/forms';
import { SpecificationCategoryService } from './../shared/specification-category.service';


@Component({
  selector: 'app-view-specification',
  templateUrl: './view-specification.component.html',
  styleUrls: ['./view-specification.component.css']
})
export class ViewSpecificationComponent implements OnInit {

  specificationList = [];
  specificationCategoryList = [];
  searchText: string;
  category: number;
  params: any;

  constructor(private specificationService: SpecificationService,
    private route: ActivatedRoute,
    private specificationCategoryService: SpecificationCategoryService)
  {
    this.route.queryParams.subscribe((params) => {
      this.params = params;
      })
  }

  ngOnInit(): void {
    this.specificationCategoryService.getSpecificationCategoryList(null,null)
      .subscribe(
        res => this.specificationCategoryList = res as []
    );

    this.getSpecification();
  }

  getSpecification() {
    this.specificationService.getSpecificationList(this.category,this.searchText)
      .subscribe(res => this.specificationList = res as []);
  }
}
