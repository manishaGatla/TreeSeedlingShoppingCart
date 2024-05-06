import { Component } from '@angular/core';
import { RegisterService } from 'src/app/services/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  userName: string = '';
  firstName: string = '';
  lastName: string = '';
  isPasswordNotValid: boolean = true;
  email: string = '';
  confirmPassword: any = null;
  password: string = '';
  successMessage: any;
  errorMessage:any;
  constructor(private registerService: RegisterService) {}
  ngOnInit(): void {
  }

  onSubmit() {
    var reqbody = this.getBody();
    this.registerService.registerUser(reqbody).subscribe((res)=>{
      if(res){
        this.successMessage = "User Registered Successfully.";
        window.location.href ='login';
      }
    })
 
   }

   checkPasswordValidation(){
    this.isPasswordNotValid = this.password != null &&  this.confirmPassword != null ?  this.password != this.confirmPassword ? false : true : true;
   }

   getBody(){
    return  {
      userName: this.userName,
      email : this.email,
      password: this.password,
      lastName:this.lastName,
      firstName: this.firstName
    }

  }

  isValidEmail(email: string): boolean {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return email != null  && email != "" ? emailRegex.test(email) : true;
  }
}
