import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AddPurchaseRequestService {
    // formData: "Books";
  constructor(private http: HttpClient) { }

  postAddPurchaseRequest(formData) {
    console.log(formData);
    return this.http.post(environment.apiBaseURI + '/AddPurchaseRequestt', formData);
  }
  putAddPurchaseRequest(formData) {
    return this.http.put(environment.apiBaseURI + '/AddPurchaseRequest/' ,formData);
  }
  getAddPurchaseRequest() {
    return this.http.get(environment.apiBaseURI + '/AddPurchaseRequest');
  }
  deleteAddPurchaseRequest(id) {
    return this.http.delete(environment.apiBaseURI + '/AddPurchaseRequest/' + id);
  }
}
