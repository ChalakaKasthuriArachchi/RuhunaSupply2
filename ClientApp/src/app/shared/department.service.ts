import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private http : HttpClient) { }
  getDepartmentList(fac1){
    return this.http.get(environment.apiBaseURI + '/Department?Faculty=/' +fac1);
  }
}
