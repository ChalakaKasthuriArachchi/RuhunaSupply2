import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  UserList= [];
  constructor(private http: HttpClient) { }

  postUser(formData){
    var tok = localStorage.getItem('token');
    if(tok != null){
      var tokenHeader = new HttpHeaders({'Authorization':'Bearer ' + tok});
    return this.http.post(environment.apiBaseURI + '/User', formData,
    {headers : tokenHeader});
  }
}
  getUserList(){
    var tok = localStorage.getItem('token');
    if(tok != null){
      var tokenHeader = new HttpHeaders({'Authorization':'Bearer ' + tok});
    return this.http.get(environment.apiBaseURI + '/User',
    {headers : tokenHeader});
    
  }
  getUser(){
    var tok = localStorage.getItem('token');
    if(tok != null){
      var tokenHeader = new HttpHeaders({'Authorization':'Bearer ' + tok});
      return this.http.get(environment.apiBaseURI + '/User/getcurrentuser', {headers : tokenHeader});
    }
  }
}

}
