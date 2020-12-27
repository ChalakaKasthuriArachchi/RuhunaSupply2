import { Component, OnInit } from '@angular/core';
import { FormBuilder,Validator,FormGroup} from '@angular/forms';
import { UserService } from '../shared/user.service';
import { FacultyService } from '../shared/faculty.service';
import { DepartmentService } from '../shared/department.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
  checkoutForm;
  userList;
  FacultyList: [];
  userPositions : [];
  DepartmentList : [];
  UserType : [];

  constructor(
    private formBuilder : FormBuilder,
    private addUserService : UserService,
    private FacultyService : FacultyService,
    private DepartmentService : DepartmentService
    ) { 
        this.checkoutForm=this.formBuilder.group({
          Faculty:'',
          Department:'',
          FullName:'',
          ShortName:'',
          PermissionList:'',
          Position:'',
          UserType:'',
          MergedId:''

        });
      }

  ngOnInit(): void {
    this.FacultyService.getFacultyList().subscribe(
      res => this.FacultyList = res as []
    );
  }
  onSubmit(userData){
    this.addUserService.postUser(userData.value)
      .subscribe(
        data => console.log('Success!',data),
        error => console.log('Error!',error)
      );
  }
  recordSubmit(fg: FormGroup){
    this.addUserService.postUser(fg.value);
  }
  onFacultySelect(fg:FormGroup){
    this.DepartmentService.getDepartmentList(fg.value.Faculty).subscribe(
      res => this.DepartmentList = res as []
    );
  }
  

}
