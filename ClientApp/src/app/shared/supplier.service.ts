import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
// import { throwError } from 'rxjs/internal/observable/throwError';
import { Observable, of, throwError, pipe} from "rxjs"
import { map, filter, catchError, mergeMap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  constructor(private http: HttpClient) { }

//   public apiURL:string= "./register-supplier.component.html";
//   RegisterUser (user:any)
//   {
//     return this.http.post(this.apiURL, user)
//     .pipe(
//       map(res => res),
//        catchError( this.errorHandler)
//       );
//   }
//   errorHandler(error: Response) {  
//     console.log(error);  
//     return throwError(error);  
// } 


  postSupplier(formData){
    var tok = localStorage.getItem('token');
    if(tok != null){
      var tokenHeader = new HttpHeaders({'Authorization':'Bearer ' + tok});
      return this.http.post(environment.apiBaseURI + '/Supplier', formData,
      {headers : tokenHeader});
    }
    // return this.http.post(environment.apiBaseURI + '/Supplier', formData);

  }
  
  // postSpecification(formData) {
  //   console.log(formData);
  //   console.log(environment.apiBaseURI + '/Specification');
  //   return this.http.post(environment.apiBaseURI + '/Specification', formData);
  // }
  putSupplier(formData){
    return this.http.put(environment.apiBaseURI + '/Supplier/' + formData.Id,
      formData);
  }
  getSupplierList(category,search){
    var tok = localStorage.getItem('token');
    if(tok != null){
      var tokenHeader = new HttpHeaders({'Authorization':'Bearer ' + tok});
      return this.http.get(environment.apiBaseURI + '/Supplier?Category=' + category + '&search=' + search,
      {headers : tokenHeader});
    }
  }
  deleteSupplier(id){
    return this.http.delete(environment.apiBaseURI + '/Supplier/' + id);
  }
}
