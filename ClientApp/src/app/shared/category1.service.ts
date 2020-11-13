import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class Category1Service {

  constructor(private http:HttpClient){ }
  postCategory1(formData){
    console.log(formData);
    console.log(environment.apiBaseURI + '/Category1');
    return this.http.post(environment.apiBaseURI + '/Category1',formData);
  }
  putCategory1(formData){
    return this.http.put(environment.apiBaseURI + '/Category1/' + formData.Id,
      formData);
  }
  
  deleteCategory1(id){
    return this.http.delete(environment.apiBaseURI + '/Category1/' + id);
  }
  getCategory1List()
  {
    return this.http.get(environment.apiBaseURI + '/Category1/' );
  }
}
