import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  baseurl = "https://localhost:7194";
  showPaymentSection: boolean = false;
  addressDetails: any = {
    userId: null,
    address1: null,
    address2: null,
    zip:null,
    state: null,
    city: null,
    postalCode: null,
    country: null

  } ;
  cartItems: any =[];
  constructor(private http: HttpClient) {}

  public getCartItemsByUserId(userId: any): Observable<any>{
    return this.http.get(this.baseurl + "/api/Cart/getCartItemsByUserId?userId=" + userId);
  } 

  public addCartItem(body: any): Observable<any>{
    return this.http.post(this.baseurl + "/api/Cart" , body);
  } 

  removeItemFromCart(cartItemId : any): Observable<any>{
    return this.http.delete(this.baseurl + '/api/Cart?id=' + cartItemId);
  }

  buyCartItems(cartItems: any, emailId: any): Observable<any>{
    return this.http.post(this.baseurl + '' + emailId , cartItems);
  }

  updateItemFromCart(cartItem: any): Observable<any>{
    return this.http.put(this.baseurl + '/api/Cart', cartItem);
  }
}
