import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SpecificationService {

  constructor(private http: HttpClient) { }

  postSpecification(formData) {
    console.log(formData);
    console.log(environment.apiBaseURI + '/Specification');
    return this.http.post(environment.apiBaseURI + '/Specification', formData);
  }
  putSpecification(formData) {
    return this.http.put(environment.apiBaseURI + '/Specification/', formData);
  }
  getSpecificationList(category,search) {
    var tok = localStorage.getItem('token');
    if (tok != null) {
      var tokenHeader = new HttpHeaders({ 'Authorization': 'Bearer ' + tok });
      return this.http.get(environment.apiBaseURI + '/Specification?Category=' + category + '&search=' + search,
        { headers: tokenHeader });
    }  }
  deleteSpecification(id) {
    return this.http.delete(environment.apiBaseURI + '/Specification/' + id);
  }
}
