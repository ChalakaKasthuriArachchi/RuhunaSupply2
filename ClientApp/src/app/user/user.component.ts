import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import { UserService } from './../shared/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  User= [];
  constructor(private UserService : UserService, private router : Router) { }

  ngOnInit(): void {
    if(localStorage.getItem('token') == null)
    this.router.navigateByUrl('user/login');
    this.getUserList();
  }
  getUserList(){
    this.UserService.getUserList()
      .subscribe(res => this.User = res as []);
  }
}
