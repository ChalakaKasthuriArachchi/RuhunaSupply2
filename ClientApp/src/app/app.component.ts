import { Component } from '@angular/core';
import { UserAccountService } from './shared/user-account.service';
import { NgModule } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Ruhuna Supply';

  constructor(private service:UserAccountService){

  }

  onLogout(){
    this.service.onLogout();
  }
}
