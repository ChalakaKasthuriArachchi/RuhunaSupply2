import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class Category3Service {

  constructor(private http : HttpClient){}
  postCategory3(formData){
    console.log(environment.apiBaseURI + '/Category3');
    return this.http.post(environment.apiBaseURI + '/Category3',formData);
  }
  putCategory3(formData){
    return this.http.put(environment.apiBaseURI + '/Category3,',formData.Id);
  }
  getCategory3List(cat2,inc){
    return this.http.get(environment.apiBaseURI + '/Category3?category2='+ cat2 + '&Include='+inc);
  }

  
}
