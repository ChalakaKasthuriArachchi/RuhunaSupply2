import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class Category2Service {

  constructor(private http : HttpClient) { }
  getSupplierList(){
    return this.http.get(environment.apiBaseURI + '/Category2');
  }
}
