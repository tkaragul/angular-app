import { Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductDetailComponent } from './components/product-detail/product-detail.component';
import { CartComponent } from './components/cart/cart.component';


export const routes: Routes = [
    { path: '', redirectTo: '/products', pathMatch: 'full'},
    { path: 'products', component: ProductListComponent },
    { path: 'product/:id', component: ProductDetailComponent },
    { path: 'cart', component: CartComponent },
];
