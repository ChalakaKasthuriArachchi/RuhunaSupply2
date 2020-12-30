import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PurchaseRequestService {

  constructor(private http: HttpClient) {
    
  }
  putPurcahseRequest(pr){
    var tok = localStorage.getItem('token');
    if(tok != null){
      var tokenHeader = new HttpHeaders({'Authorization':'Bearer ' + tok});
      return this.http.put(environment.apiBaseURI + '/PurchaseRequest', pr, {headers : tokenHeader});
    }
  }
  postPurchaseRequest(pr){
    var tok = localStorage.getItem('token');
    if(tok != null){
      var tokenHeader = new HttpHeaders({'Authorization':'Bearer ' + tok});
      return this.http.post(environment.apiBaseURI + '/PurchaseRequest', pr, {headers : tokenHeader});
    }
  }
  getPurchaseRequestList(status){
    var tok = localStorage.getItem('token');
    if(tok != null){
      var tokenHeader = new HttpHeaders({'Authorization':'Bearer ' + tok});
      return this.http.get(environment.apiBaseURI + '/PurchaseRequest?status=' + status,{headers : tokenHeader});
    }
  } 
  getAllowedForwardsList(){
    var tok = localStorage.getItem('token');
    if(tok != null){
      var tokenHeader = new HttpHeaders({'Authorization':'Bearer ' + tok});
      return this.http.get(environment.apiBaseURI + '/PurchaseRequest/allowedforwards',{headers : tokenHeader});
    }
  }
  getPurchaseRequest(id){
    var tok = localStorage.getItem('token');
    if(tok != null){
      var tokenHeader = new HttpHeaders({'Authorization':'Bearer ' + tok});
      return this.http.get(environment.apiBaseURI + '/PurchaseRequest/' + id,{headers : tokenHeader});
    }
  }
  callQuotations(id){
    var tok = localStorage.getItem('token');
    if(tok != null){
      var tokenHeader = new HttpHeaders({'Authorization':'Bearer ' + tok});
      return this.http.get(environment.apiBaseURI + '/PurchaseRequest/callquotations/' + id,
        {headers : tokenHeader});
    }
  }
}
