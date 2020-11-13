import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class Category2Service {

  constructor(private http : HttpClient) { }
  postCategory2(formData){
    console.log(formData);
    console.log(environment.apiBaseURI + '/Category2');
    return this.http.post(environment.apiBaseURI + '/Category2',formData);
  }
  putCategory2(formData){
    return this.http.put(environment.apiBaseURI + '/Category2/' + formData.Id,
      formData);
  }
  
  deleteCategory2(id){
    return this.http.delete(environment.apiBaseURI + '/Category2/' + id);
  }
  getCategory2List(cat1){
    return this.http.get(environment.apiBaseURI + '/Category2?Category1=' + cat1);
  }
}
