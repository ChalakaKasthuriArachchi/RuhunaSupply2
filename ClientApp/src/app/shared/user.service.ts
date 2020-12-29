import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  postUser(formData){
    console.log(formData);
    console.log(environment.apiBaseURI + '/User');
    return this.http.post(environment.apiBaseURI + '/User', formData);
  }
  getUserList(){
    return this.http.get(environment.apiBaseURI + '/User');
  }
  getUser(){
    var tok = localStorage.getItem('token');
    if(tok != null){
      var tokenHeader = new HttpHeaders({'Authorization':'Bearer ' + tok});
      return this.http.get(environment.apiBaseURI + '/User/getcurrentuser', {headers : tokenHeader});
    }
  }
}
