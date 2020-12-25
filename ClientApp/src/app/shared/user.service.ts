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
}
