import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SpecificationCategoryService {

  constructor(private http: HttpClient) { }

  postSpecificationCategory(formData) {
    console.log(formData);
    console.log(environment.apiBaseURI + '/SpecificationCategory');
    return this.http.post(environment.apiBaseURI + '/SpecificationCategory', formData);
  }
  getSpecificationCategories(itemId){
    return this.http.get(environment.apiBaseURI + '/SpecificationCategory?ItemId=' + itemId);
  }
}
