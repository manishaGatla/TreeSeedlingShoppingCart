import { Component } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  constructor(public loginService: LoginService,  private router: Router){}
  userName: any;
  password: any;
  errorMessage:any;
  successMessage: any;
  onLogin(){
    this.loginService.getDetailsByEmail(this.userName).subscribe((res : any)=>{
      if(res && res.error != null){
        this.resetFields();
        this.errorMessage ="User Not found, Please Register";
      }
      else{
        var data = res;
        this.loginService.profileDetails = res;
        this.errorMessage = null;

        if(data.password == this.password){
          this.loginService.isLoginSuccessful= true;
          this.router.navigateByUrl('/home');
        }
        else if(data.password !== this.password){
          this.resetFields();
          this.errorMessage = "Incorrect password, please enter correct password and try again.";
        }

      }

    })
  }

  resetFields(){
    this.userName = null;
    this.password = null;
  }

}
