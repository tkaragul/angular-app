export interface Product {
    id: number;
    name: string;
    price: number;
    categoryId: number;
    category: string;
    detail: string;
    imageUrl: string;
    stockQuantity: number;
  }
  
  export interface CartItem {
    product: Product;
    quantity: number;
  }

  export interface Category {
    name: string;
    id: number;
  }

  export interface ProductListResponse {
    data: Product[];  

  }

  export interface ProductResponse {
    data: Product;  

  }
  
  export interface CategoryListResponse {
    data: Category[];  
  }

  export interface CartListResponse {
    data: CartItem[];
  
  }