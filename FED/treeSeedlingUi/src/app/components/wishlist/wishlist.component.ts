import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CartService } from 'src/app/services/cart.service';
import { LoginService } from 'src/app/services/login.service';
import { WishlistService } from 'src/app/services/wishlist.service';

@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.scss']
})
export class WishlistComponent {
  wishlistItems: any;
  expandedItemId: number | null = null;
  constructor(private wishlistService: WishlistService, private cartService: CartService, private loginService: LoginService, private router: Router) { }
  ngOnInit(): void {
    this.loadWishlist();
  }

  loadWishlist(): void {
    this.wishlistService.getWishlistItems(this.loginService.profileDetails.id).subscribe((res) =>{
      this.wishlistItems = res;
    }
       );
  }

  toggleItemDetails(itemId: number): void {
    this.expandedItemId = this.expandedItemId === itemId ? null : itemId;
  }

  removeFromWishlist(itemId: number): void {
    this.wishlistService.removeItemFromWishlist(itemId).subscribe((res) =>{
      this.loadWishlist();
    }
    );
  }

  moveToCart(treeId: number, itemId: any): void {
    const body  ={
      userId :this.loginService.profileDetails.id ,
      treeId: treeId,
      quantity: 1
    };
   
    
    this.cartService.addCartItem(body).subscribe((res: any)=>{
      this.removeFromWishlist(itemId);
      this.router.navigateByUrl('/cart');
    })
  }
}
