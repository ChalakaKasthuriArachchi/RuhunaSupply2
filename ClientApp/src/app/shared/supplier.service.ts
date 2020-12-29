import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  constructor(private http: HttpClient) { }

  postSupplier(formData){
    var tok = localStorage.getItem('token');
    if(tok != null){
      var tokenHeader = new HttpHeaders({'Authorization':'Bearer ' + tok});
      return this.http.post(environment.apiBaseURI + '/Supplier', formData,
      {headers : tokenHeader});
    }
  }
  putSupplier(formData){
    return this.http.put(environment.apiBaseURI + '/Supplier/' + formData.Id,
      formData);
  }
  getSupplierList(category,search){
    var tok = localStorage.getItem('token');
    if(tok != null){
      var tokenHeader = new HttpHeaders({'Authorization':'Bearer ' + tok});
      return this.http.get(environment.apiBaseURI + '/Supplier?Category=' + category + '&Search=' + search,
      {headers : tokenHeader});
    }
  }
  getActiveSupplierList(category){
    var tok = localStorage.getItem('token');
    if(tok != null){
      var tokenHeader = new HttpHeaders({'Authorization':'Bearer ' + tok});
      return this.http.get(environment.apiBaseURI + '/Supplier/activeSuppliers?Category=' + category,
      {headers : tokenHeader});
    }
  }
  deleteSupplier(id){
    return this.http.delete(environment.apiBaseURI + '/Supplier/' + id);
  }
}
