import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {FormGroup, FormControl, FormBuilder} from '@angular/forms';
import { UserAccountService } from '../shared/user-account.service';

@Component({
  selector: 'app-user-account',
  templateUrl: './user-account.component.html',
  styleUrls: ['./user-account.component.css']
})

export class UserAccountComponent implements OnInit {
  items;
  checkoutForm;
  form: FormGroup;

  constructor(
    private userAccountService : UserAccountService,
    private formBuilder : FormBuilder,
    
  ) {
    this.checkoutForm = this.formBuilder.group({
      FullName: '',
      ShortName: '',
      Email: '',
      HashedPassword: '',
      ConfirmPassword:'',
      Type: '',
    });
  }

  ngOnInit():void{
  }


  onSubmit(userAccountData) {
    this.userAccountService.postUserAccount(userAccountData.value)
      .subscribe(
      data => console.log('Success!', data),
      error=> console.log('Error',error)
    );
    console.log('Account Created Successfully', userAccountData);
    this.checkoutForm.reset();

  }

  recordSubmit(fg: FormGroup) {

    this.userAccountService.postUserAccount(fg.value);

  }
   

}
