import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  baseurl = "https://localhost:7194";
  isLoginSuccessful: boolean = false;
  isLoggedOutSuccessful: boolean = false;
  profileDetails: any;

  constructor(private http: HttpClient) {}

  public registerUser(body: any): Observable<any>{
    return this.http.post(this.baseurl + "/api/Users" , body);
  } 

}
