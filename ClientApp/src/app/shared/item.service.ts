import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  constructor(private http: HttpClient) { }

  postItem(formData){
    console.log(formData);
    console.log(environment.apiBaseURI + '/Item');
    return this.http.post(environment.apiBaseURI + '/Item', formData);
  }
  putItem(formData){
    return this.http.put(environment.apiBaseURI + '/Item/',formData.Id);
  }
  getItemList(category, search){
    return this.http.get(environment.apiBaseURI + '/Item?Category=' + category + '&search=' + search);
  }
  deleteItem(id){
    return this.http.delete(environment.apiBaseURI + '/Item/' + id);
  }
}
