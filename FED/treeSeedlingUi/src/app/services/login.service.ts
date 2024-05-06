import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  baseurl = "https://localhost:7194";
  isLoginSuccessful: boolean = false;
  isLoggedOutSuccessful: boolean = false;
  profileDetails: any;

  constructor(private http: HttpClient) {}

  public getDetailsByEmail(username: any): Observable<any>{
    return this.http.get(this.baseurl + "/api/Users/getByUserName?userName=" +username );
  } 

 
}
