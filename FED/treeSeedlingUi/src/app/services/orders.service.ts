import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  baseurl = "https://localhost:7194";
  constructor(private http: HttpClient) {}

  public getOrderDetailsByUserId(userId: any): Observable<any>{
    return this.http.get(this.baseurl + "/api/Orders/getOrdersByUserId?userId=" +userId );
  } 

}
