import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserAccountService {

  constructor(private http: HttpClient) { }

  postUserAccount(formData) {
    return this.http.post(environment.apiBaseURI + '/UserAccount/SignUp', formData);
    
  }
  putUserAccount(formData) {
    return this.http.put(environment.apiBaseURI + '/UserAccount/' ,formData);
  }
  getUserAccountList() {
    return this.http.get(environment.apiBaseURI + '/UserAccount')
  }
  deleteUserAccount(id) {
    return this.http.delete(environment.apiBaseURI + '/UserAccount/' + id);
  }
  login(formData){
    return this.http.post(environment.apiBaseURI + '/UserAccount/login',formData);
  }
  onLogout(){
    localStorage.removeItem('token');
  }
}
