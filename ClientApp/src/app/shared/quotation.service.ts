import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class QuotationService {
  constructor(private http: HttpClient) { }
  postQuotation(formData) {
    return this.http.post(environment.apiBaseURI + '/Quotation', formData);
  }
  getQuotation(id) {
    var tok = localStorage.getItem('token');
    if(tok != null){
      var tokenHeader = new HttpHeaders({'Authorization':'Bearer ' + tok});
      return this.http.get(environment.apiBaseURI + '/Quotation/' + id,
      {headers : tokenHeader});
    }
  }
}
