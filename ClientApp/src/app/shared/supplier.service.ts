import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  constructor(private http : HttpClient) { }

  postSupplier(formData){
    console.log(formData);
    console.log(environment.apiBaseURI + '/Supplier');
    return this.http.post(environment.apiBaseURI + '/Supplier',formData);
  }
  putSupplier(formData){
    return this.http.put(environment.apiBaseURI + '/Supplier/' + formData.bankAccountID,
      formData);
  }
  getSupplierList(category,search){
    //console.log(environment.apiBaseURI + '/Supplier');
    console.log(category);
    console.log(search);
    return this.http.get(environment.apiBaseURI + '/Supplier?Category=' + category + '&search=' + search);
    
  }
  deleteSupplier(id){
    return this.http.delete(environment.apiBaseURI + '/Supplier/' + id);
  }
}
