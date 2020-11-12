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
    console.log(environment.apiBaseURI + '/category2');
    return this.http.post(environment.apiBaseURI + '/category2',formData);
  }
  putCategory2(formData){
    return this.http.put(environment.apiBaseURI + '/category2/' + formData.Id,
      formData);
  }
  
  deleteCategory2(id){
    return this.http.delete(environment.apiBaseURI + '/category2/' + id);
  }
  getCategory2List(){
    return this.http.get(environment.apiBaseURI + '/Category2');
  }
}
