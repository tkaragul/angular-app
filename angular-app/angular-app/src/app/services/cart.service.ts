import { Inject, Injectable, PLATFORM_ID  } from "@angular/core";
import { CartItem, CartListResponse, Product, ProductListResponse } from "../models/product.model";
import { BehaviorSubject, Observable } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "../../../environments/environment";

@Injectable({
    providedIn: 'root'
  })

  export class CartService {
    private cartItems: CartItem[] = [];
    private cartSubject = new BehaviorSubject<CartItem[]>([]);
  

      private apiUrl = environment.apiUrl;
    
      constructor(@Inject(PLATFORM_ID) private platformId: Object, private http: HttpClient) {}
    
      getCarts(): Observable<CartListResponse> {
        let clientId = 'guest-client';

        if (this.platformId === 'browser') {
          clientId = localStorage.getItem('Client-ID') || 'guest-client';
        }

        const headers = new HttpHeaders({
          'Content-Type': 'application/json',
          'Client-ID': clientId,
        });

        let url = `${this.apiUrl}/carts/`;
    
        return this.http.get<CartListResponse>(url, { headers });
      }

      addCart(request: CartItem): Observable<CartListResponse> {

        let clientId = 'guest-client';

        if (this.platformId === 'browser') {
          clientId = localStorage.getItem('Client-ID') || 'guest-client';
        }

        const headers = new HttpHeaders({
          'Content-Type': 'application/json',
          'Client-ID': clientId,
        });

        let url = `${this.apiUrl}/carts/`;
    
        return this.http.post<CartListResponse>(url, request, { headers });
      }

    getCart() {
      return this.cartSubject.asObservable();
    }
  
    addToCart(product: Product, quantity: number = 1) {
      const existingItem = this.cartItems.find(item => item.product.id === product.id);
      if (existingItem) {
        existingItem.quantity += quantity;
      } else {
        this.cartItems.push({ product, quantity });
      }
      this.cartSubject.next([...this.cartItems]);
      
      this.addCart({ product, quantity })
        .subscribe(
            (response) => {
                
                this.cartItems = response.data || [];  
                this.cartSubject.next([...this.cartItems]);  
            },
            (error) => {
                
                console.error('Sepete ürün eklenirken bir hata oluştu:', error);
            }
        );
    }
  
    updateQuantity(productId: number, quantity: number) {
      const item = this.cartItems.find(item => item.product.id === productId);
      if (item) {
        item.quantity = quantity;
        this.cartSubject.next([...this.cartItems]);
      }
    }
  
    removeFromCart(productId: number) {
      this.cartItems = this.cartItems.filter(item => item.product.id !== productId);
      this.cartSubject.next([...this.cartItems]);
    }
  
    getTotal() {
      return this.cartItems.reduce((total, item) => {
        return total + (item.product.price * item.quantity);
      }, 0);
    }
  }