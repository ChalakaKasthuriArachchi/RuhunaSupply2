import { UserAccountService } from './../../shared/user-account.service';
import { NgForm,FormGroup,FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { combineLatest } from 'rxjs';
import {FormControl } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Input, Component, OnInit, NgModule } from '@angular/core';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  checkoutForm;
  formModel = {
  Email : '',
  Password : ''
}
  constructor(
    private service : UserAccountService,
    private formBuilder : FormBuilder,
    private router: Router,
    ) { 
      this.checkoutForm = this.formBuilder.group({
        Email: '',
        Password: '',
      });
      }

  ngOnInit(): void {
    if(localStorage.getItem('token') != null)
    this.router.navigateByUrl('');
  }
  // onSubmit(form:NgForm){
  //   this.service.login(form.value).subscribe(
  //     (res : any) =>{
  //       localStorage.setItem('token',res.token);
  //       this.router.navigateByUrl('');
  //     },
  //     err =>{
  //       if(err.status == 400){

  //       }
  //       else{
  //         console.log(err);
  //       }
  //     }
  //   );
  // }

  onSubmit(fg: FormGroup) {
    console.log(fg.value);
    this.service.login(fg.value)
      .subscribe(
        data => { 
          console.log('Success!', data);
          localStorage.setItem('token',data['token']);
          const el: HTMLElement = document.getElementById('success_alert');
          el.style.display = 'block';
          const timer: ReturnType<typeof setTimeout> = setTimeout(() =>   el.style.display = 'none', 3000);  
          //const resetForm: HTMLFormElement = document.getElementById('checkform');
          fg.reset();
          this.router.navigateByUrl('');
        },

        error => { 
          console.log('error!', error);
          const el: HTMLElement = document.getElementById('error_alert');
          el.style.display = 'block';
          const timer: ReturnType<typeof setTimeout> = setTimeout(() =>   el.style.display = 'none', 3000);  
      }
      );
  }
}
