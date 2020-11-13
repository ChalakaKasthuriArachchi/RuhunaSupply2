import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class Category3Service {

  constructor(private http : HttpClient){}
  postCategory3(formData){
    console.log(formData);
    console.log(environment.apiBaseURI + '/Category3');
    return this.http.post(environment.apiBaseURI + '/Category3',formData);
  }
  putCategory3(formData){
    return this.http.put(environment.apiBaseURI + '/Catgory3,',formData.Id);
  }
  getCategory3List(){
    return this.http.get(environment.apiBaseURI + '/Category3');
  }

  
}
