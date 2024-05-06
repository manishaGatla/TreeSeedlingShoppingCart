import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  baseurl = "https://localhost:7194";

  constructor(private http: HttpClient) {}

  public placeOrder(body :any): Observable<any>{
    return this.http.post(this.baseurl + "/api/Orders" , body );
  } 
}
