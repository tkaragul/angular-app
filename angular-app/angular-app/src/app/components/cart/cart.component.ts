import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart.service';
import { CartItem } from '../../models/product.model';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CartSummaryComponent } from '../cart-summary/cart-summary.component'; // CartSummaryComponent import edilmelidir
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-cart',
  imports: [CommonModule, RouterModule, FormsModule, CartSummaryComponent], // CartSummaryComponent import edilmelidir
  templateUrl: './cart.component.html'
})
export class CartComponent implements OnInit {
  cartItems: CartItem[] = [];

  constructor(private route: ActivatedRoute, private cartService: CartService) {}

  ngOnInit() {
    this.loadCarts();
    this.cartService.getCart().subscribe(items => {
      this.cartItems = items;
    });
  }

  updateQuantity(productId: number, quantity: number) {
    this.cartService.updateQuantity(productId, quantity);
  }

  removeItem(productId: number) {
    this.cartService.removeFromCart(productId);
  }

  loadCarts() {
    this.cartService
      .getCarts()
      .subscribe(
        response => {

          this.cartItems = response.data || [];
      });
  }

}