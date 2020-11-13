import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  constructor(private http : HttpClient) { }

  postSupplier(formData){
    var tok = localStorage.getItem('token');
    if(tok != null){
      var tokenHeader = new HttpHeaders({'Authorization':'Bearer ' + tok});
      return this.http.post(environment.apiBaseURI + '/Supplier', formData,
      {headers : tokenHeader});
    }
  }
  putSupplier(formData){
    return this.http.put(environment.apiBaseURI + '/Supplier/' + formData.bankAccountID,
      formData);
  }
  getSupplierList(category,search){
    var tok = localStorage.getItem('token');
    if(tok != null){
      var tokenHeader = new HttpHeaders({'Authorization':'Bearer ' + tok});
      return this.http.get(environment.apiBaseURI + '/Supplier?Category=' + category + '&search=' + search,
      {headers : tokenHeader});
    }
  }
  deleteSupplier(id){
    return this.http.delete(environment.apiBaseURI + '/Supplier/' + id);
  }
}
