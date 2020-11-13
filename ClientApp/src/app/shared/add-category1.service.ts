import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class AddCategory1Service {

  constructor(private http:HttpClient) { }
  postCategory1(formData){
    return this.http.post(environment.apiBaseURI + '/category1',formData);
  }

  putCategory1(formData){
    return this.http.put(environment.apiBaseURI + '/category1/', + formData.Id);
  }

  getCategory1(formData){
    return this.http.get(environment.apiBaseURI + '/category1');
  }

  deleteCategory1(formData){
    return this.http.delete(environment.apiBaseURI +'/category1'+ formData.Id);
  }
}
