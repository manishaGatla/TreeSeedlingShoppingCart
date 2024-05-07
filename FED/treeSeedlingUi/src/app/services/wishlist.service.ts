import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WishlistService {
  baseurl = "https://localhost:7194";
  constructor(private http: HttpClient) {}

  public getWishlistItems(userId: any): Observable<any>{
    return this.http.get(this.baseurl + "/api/WishList/getWishListsByUserId?id=" + userId);
  } 

  public addWishlistItem(body: any): Observable<any>{
    return this.http.post(this.baseurl + "/api/WishList" , body);
  } 

  removeItemFromWishlist(wishlistId : any): Observable<any>{
    return this.http.delete(this.baseurl + '/api/WishList?id=' + wishlistId);
  }
}
