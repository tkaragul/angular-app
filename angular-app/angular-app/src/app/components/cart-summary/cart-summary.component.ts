import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-cart-summary',
  imports: [CommonModule], 
  templateUrl: './cart-summary.component.html'
})
export class CartSummaryComponent implements OnInit {
  subtotal: number = 0;
  vat: number = 0;
  total: number = 0;
  totalItems: number = 0;

  constructor(private cartService: CartService) {}

  ngOnInit() {
    this.cartService.getCart().subscribe(items => {
      this.totalItems = items.reduce((sum, item) => sum + item.quantity, 0);
      this.subtotal = items.reduce((sum, item) => sum + (item.product.price * item.quantity), 0);
      this.vat = this.subtotal * 0.20;
      this.total = this.subtotal + this.vat;
    });
  }
}
