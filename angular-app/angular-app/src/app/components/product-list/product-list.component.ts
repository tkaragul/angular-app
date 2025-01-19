import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ProductService } from '../../services/product.service';
import { CartService } from '../../services/cart.service';
import { MiniCartComponent } from '../mini-cart/mini-cart.component';
import { Category, Product } from '../../models/product.model';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { ActivatedRoute,Router } from '@angular/router';


@Component({
  selector: 'app-product-list',
  imports: [CommonModule, RouterModule, FormsModule, MiniCartComponent, NgbPaginationModule  ],
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
  
})
export class ProductListComponent implements OnInit {
  products: Product[] = [];
  currentPage = 1;
  limit = 10;
  categories: Category[] = [];
  selectedCategory: string = '';
  minPrice: number | null = null;
  maxPrice: number | null = null;

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router,
    private cartService: CartService
  ) {}

  ngOnInit() {
    this.loadProducts();
    this.loadCategories();
  }

  loadProducts() {
    this.productService
      .getProducts(this.currentPage, this.limit)
      .subscribe(
        response => {

          this.products = response.data || [];
      });
  }

  loadCategories() {
    this.productService
      .getCategories(this.currentPage, this.limit)
      .subscribe(
        response => {

          this.categories = response.data || [];
      });
  }

  addToCart(product: Product) {
    this.cartService.addToCart(product);
  }
}
