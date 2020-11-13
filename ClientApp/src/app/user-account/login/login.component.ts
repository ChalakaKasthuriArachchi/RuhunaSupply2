import { UserAccountService } from './../../shared/user-account.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { combineLatest } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
formModel = {
  Email : '',
  Password : ''
}
  constructor(private service:UserAccountService,private router: Router) { }

  ngOnInit(): void {
    if(localStorage.getItem('token') != null)
    this.router.navigateByUrl('');
  }
  onSubmit(form:NgForm){
    this.service.login(form.value).subscribe(
      (res : any) =>{
        localStorage.setItem('token',res.token);
        this.router.navigateByUrl('');
      },
      err =>{
        if(err.status == 400){

        }
        else{
          console.log(err);
        }
      }
    );
  }
}
