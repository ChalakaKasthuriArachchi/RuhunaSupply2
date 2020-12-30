import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from "src/environments/environment";
@Injectable({
  providedIn: 'root'
})
export class FacultyService {

  constructor(private http : HttpClient) { }
  getFacultyList(){
    return this.http.get(environment.apiBaseURI + '/Faculties/');
  }
}
