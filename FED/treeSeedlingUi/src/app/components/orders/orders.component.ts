import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';
import { OrdersService } from 'src/app/services/orders.service';
interface Order {
  id: number;
  date: string;
  total: number;
  items: OrderItem[];
}

interface OrderItem {
  treeId: number;
  quantity: number;
  price: number;
}
@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})


export class OrdersComponent implements OnInit {
  orders: any;
  expandedOrderId: number | null = null;

  constructor(public loginService: LoginService, private orderService: OrdersService) { }

  ngOnInit(): void {
    this.orderService.getOrderDetailsByUserId(this.loginService.profileDetails.id).subscribe({
      next: (data: any) => {
        this.orders = data;
      },
      error: (error: any) => {
        console.error('Failed to fetch orders', error);
      }
    });
  }

  toggleOrderDetails(orderId: number): void {
    this.expandedOrderId = this.expandedOrderId === orderId ? null : orderId;
  }
}
