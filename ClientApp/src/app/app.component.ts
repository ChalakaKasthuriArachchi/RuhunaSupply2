import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { UserAccountService } from './shared/user-account.service';
import { NgModule } from '@angular/core';
import { UserService } from './shared/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{
  title = 'Ruhuna Supply';
  navbarLinks = [];
  constructor(private service:UserAccountService, 
    public router : Router,private userService : UserService){
      var temp = this.userService.getNavebarLinks();
      if(temp != null){
        temp.subscribe(res => {
        this.navbarLinks = res as [];
        console.log(this.navbarLinks);
        });
      }
  }
  onLogout(){
    this.service.onLogout();
    this.router.navigateByUrl('user/login');
  }
  hasToken(){
    return localStorage.getItem('token') != null;
  }
}
