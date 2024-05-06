import { Component } from '@angular/core';
import { CartService } from 'src/app/services/cart.service';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent {
  cartItems: any;
  constructor(public cartService: CartService, private loginService: LoginService){}

  ngOnInit(): void{
    this.cartService.showPaymentSection = false;
    this.getCartDetails();
  }

  getCartDetails(){
    this.cartService.getCartItemsByUserId(this.loginService.profileDetails.id).subscribe((res)=>{
      if(res){
        this.cartItems = res;
        this.cartItems.forEach((item: any)=>{

          item.total = item.quantity * Number(item.tree.price);
        })

        this.cartService.cartItems = this.cartItems;
      }
    })
  }

  buyNow(){
    this.cartService.showPaymentSection = true;
  }

  toggleItemDetails(item : any) {
    item.showDetails = !item.showDetails;
  }

  remove(item : any){
    var cartItemId = item.id;
    this.cartService.removeItemFromCart(cartItemId).subscribe((res)=>{
      this.getCartDetails();
      if(res){
        //this.notificationService.messageshow.next('Item removed from Cart.');
        this.getCartDetails();
      }
    })
  }

  updateCartItem(item: any){
    this.cartService.updateItemFromCart(item).subscribe((res)=>{
      if(res){
        //this.notificationService.messageshow.next('Item Updated from Cart.');
        this.getCartDetails();
      }
    })
  }

  updateTotal(item: any){
    item.total = item.quantity * Number(item.tree.price.split('/')[0].split('$')[1]);
  }

}
