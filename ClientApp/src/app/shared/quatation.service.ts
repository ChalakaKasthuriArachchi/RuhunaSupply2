import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class QuataionService {

  constructor(private http: HttpClient) { }
  postQuataion(formData) {
    return this.http.post(environment.apiBaseURI + '/Quataion', formData);
  }
  getQuataion() {
    return this.http.get(environment.apiBaseURI + '/Quataion');
  }
}
