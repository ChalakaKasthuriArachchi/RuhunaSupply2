import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PurchaseRequestService {
    // formData: "Books";
  constructor(private http: HttpClient) { }

  postPurchaseRequest(formData) {
    console.log(formData);
    return this.http.post(environment.apiBaseURI + '/PurchaseRequestt', formData);
  }
  putPurchaseRequest(formData) {
    return this.http.put(environment.apiBaseURI + '/PurchaseRequest/' ,formData);
  }
  getPurchaseRequest() {
    return this.http.get(environment.apiBaseURI + '/PurchaseRequest');
  }
  deletePurchaseRequest(id) {
    return this.http.delete(environment.apiBaseURI + '/PurchaseRequest/' + id);
  }
}