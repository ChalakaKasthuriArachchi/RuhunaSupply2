import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class QuotationService {
  postSupplier(value: any) {
    throw new Error('Method not implemented.');
  }

  constructor(private http: HttpClient) { }
  postQuotation(formData) {
    return this.http.post(environment.apiBaseURI + '/Quotation', formData);
  }
  // getQuotation(id) {
  //   return this.http.get(environment.apiBaseURI + '/Quotation/' + id);
  // }
}
