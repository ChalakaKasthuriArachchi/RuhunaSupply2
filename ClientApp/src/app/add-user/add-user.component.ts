import { Component, OnInit } from '@angular/core';
import { FormBuilder,Validator,FormGroup} from '@angular/forms';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
  checkoutForm;
  userList;
  FacultyList: [];

  constructor(
    private formBuilder : FormBuilder,
    private userService : UserService,
    ) { 
        this.checkoutForm=this.formBuilder.group({
          Faculty:'',
          Department:'',
          FullName:'',
          ShortName:'',
          PermissionList:'',
          Possition:'',

        });
      }

  ngOnInit(): void {
    this.userService.getUserList().subscribe(
      res => this.userList = res as []
    );
  }
  onSubmit(userData){
    this.userService.postUser(userData.value)
      .subscribe(
        data => console.log('Success!',data),
        error => console.log('Error!',error)
      );
  }
  

}
