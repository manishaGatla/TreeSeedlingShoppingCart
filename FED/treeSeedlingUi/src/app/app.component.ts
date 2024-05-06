import { Component } from '@angular/core';
import { LoginService } from './services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(public loginService : LoginService, private router: Router){}
  

  logOut(){
    this.loginService.profileDetails = null;
    this.loginService.isLoginSuccessful = false;
    this.loginService.isLoggedOutSuccessful = true;
    this.router.navigateByUrl('login');
  }
}
