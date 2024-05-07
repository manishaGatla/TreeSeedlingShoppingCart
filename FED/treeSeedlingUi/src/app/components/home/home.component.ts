import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CartService } from 'src/app/services/cart.service';
import { LoginService } from 'src/app/services/login.service';
import { ProductsService } from 'src/app/services/products.service';
import { WishlistService } from 'src/app/services/wishlist.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  product: any;  
  price: any;
  products: any ;
  quantity: any;
  selectedQuantity: any;
  isAvaliable: any;
  isCatReturnable: any = null;

  ngOnInit() {
    this.getProducts();
  }

  constructor(public loginService: LoginService, private productService: ProductsService, private router: Router,
    private wishlistService: WishlistService,
     private cartService: CartService) {}


  getProducts(){
    this.productService.getProducts().subscribe((res: any)=>{
      this.products = res;
      this.products.forEach((c: any)=> {c.selectedQuantity = 1;});
      this.products = this.products.filter((c: any)=> c.quantity > 0);
    })
  }

  resetFields(){
    this.products = null;
    this.price = null;
    this.selectedQuantity = null;
  }

  cancel(item: any){
    this.price = null;
  }

  addToCart(item : any) {
    const body  ={
      userId :this.loginService.profileDetails.id ,
      treeId: item.id,
      quantity: item.selectedQuantity
    };
   
    
    this.cartService.addCartItem(body).subscribe((res: any)=>{
      this.router.navigateByUrl('/cart');
    })
  }


  addToWishList(item: any){
    const body  ={
      userId :this.loginService.profileDetails.id ,
      treeId: item.id,
    };
   
    
    this.wishlistService.addWishlistItem(body).subscribe((res: any)=>{
      this.router.navigateByUrl('/wishlist');
    })
  }
 
}
