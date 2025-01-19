import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product, ProductResponse } from '../models/product.model';
import { ProductListResponse  } from '../models/product.model';
import { CategoryListResponse  } from '../models/product.model';
import { environment } from '../../../environments/environment';




@Injectable({
  providedIn: 'root'
})



export class ProductService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getProducts(page: number, limit: number): Observable<ProductListResponse> {
    let url = `${this.apiUrl}/products/${page}/${limit}`;

    return this.http.get<ProductListResponse>(url);
  }

  getCategories(page: number, limit: number): Observable<CategoryListResponse> {
    let url = `${this.apiUrl}/categories`;

    return this.http.get<CategoryListResponse>(url);
  }

  getProductById(id: number): Observable<ProductResponse> {
    return this.http.get<ProductResponse>(`${this.apiUrl}/products/${id}`);
  }
}