import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';  
import { AppComponent } from './app.component';
import { ProductListComponent } from './components/product-list/product-list.component';  
import { ProductDetailComponent } from './components/product-detail/product-detail.component';  
import { CartComponent } from './components/cart/cart.component';  

@NgModule({
  declarations: [
    AppComponent,  
    ProductListComponent, 
    ProductDetailComponent,  
    CartComponent  
  ],
  imports: [
    BrowserModule,  
    HttpClientModule  
  ],
  providers: [],
  //bootstrap: [AppComponent]  
})
export class AppModule {}