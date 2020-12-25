import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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

  putSpecificationCategory(formData) {
    return this.http.put(environment.apiBaseURI + '/SpecificationCategory/' + formData.Id,
      formData);
  }
  getSpecificationCategoryList(item, search) {
    var tok = localStorage.getItem('token');
    if (tok != null) {
      var tokenHeader = new HttpHeaders({ 'Authorization': 'Bearer ' + tok });
      return this.http.get(environment.apiBaseURI + '/SpecificationCategory?Item=' + item + '&search=' + search,
        { headers: tokenHeader });
    }
  }
  deletespecificationcategoryList(id) {
    return this.http.delete(environment.apiBaseURI + '/SpecificationCategory/' + id);
  }
  getSpecificationCategories(itemId){
    return this.http.get(environment.apiBaseURI + '/SpecificationCategory?ItemId=' + itemId);
  }
  getSpecificationCategoryById(id){
    return this.http.get(environment.apiBaseURI + '/SpecificationCategory/'+ id);
  }
}
