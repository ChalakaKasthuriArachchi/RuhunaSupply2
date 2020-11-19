import { Router } from '@angular/router';
import { Component } from '@angular/core';
import { UserAccountService } from './shared/user-account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{
  title = 'Ruhuna Supply';
  constructor(private service:UserAccountService, public router : Router){

  }
  onLogout(){
    this.service.onLogout();
  }
  hasToken(){
    return localStorage.getItem('token') != null;
  }
}
