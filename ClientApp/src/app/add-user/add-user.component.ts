import { Component, OnInit } from '@angular/core';
import { FormBuilder,Validator,FormGroup} from '@angular/forms';
import { UserService } from '../shared/user.service';
import { FacultyService } from '../shared/faculty.service';
import { DepartmentService } from '../shared/department.service';
import { Router } from "@angular/router";
@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
  checkoutForm;
  UserList: [];
  FacultyList: [];
  userPositions : [];
  DepartmentList : [];

  constructor(
    private formBuilder : FormBuilder,
    private UserService : UserService,
    private FacultyService : FacultyService,
    private DepartmentService : DepartmentService,
    private router : Router
    ) { 
        this.checkoutForm=this.formBuilder.group({
          Faculty:'',
          Department:'',
          FullName:'',
          ShortName:'',
          Position:'',
          MergedId:''

        });
      }

  ngOnInit(): void {
    this.FacultyService.getFacultyList().subscribe(
      res => this.FacultyList = res as []
    );
    this.UserService.getUserList().subscribe(
      res => this.UserList = res as []
    );
  }
  onSubmit(userData){
    console.log("OK" + userData);
    this.UserService.postUser(userData.value)
      .subscribe(
        data => { console.log('Success!',data);
        this.router.navigateByUrl('');
      },
        error => console.log('Error!',error)
      );
      
  }
  recordSubmit(fg: FormGroup){
    this.UserService.postUser(fg.value);
  }
  onFacultySelect(fg:FormGroup){
    this.DepartmentService.getDepartmentList(fg.value.Faculty).subscribe(
      res => this.DepartmentList = res as []
    );
  }
  

}
