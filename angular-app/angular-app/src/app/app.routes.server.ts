import { RenderMode, ServerRoute } from '@angular/ssr';
import { environment } from '../../environments/environment';

export const serverRoutes: ServerRoute[] = [

  {
    path: 'products',
    renderMode: RenderMode.Prerender 
  },
  {
    path: 'product/:id',
    renderMode: RenderMode.Prerender,
    getPrerenderParams: async () => {
      const apiUrl = environment.apiUrl;
      let url = `${apiUrl}/products`;
      
      const response = await fetch(url);
      const products = await response.json();
      return products.map((product: { id: any; }) => ({ id: product.id }));
    }
  },
  {
    path: 'cart',
    renderMode: RenderMode.Prerender 
  },
  {
    path: '**', 
    renderMode: RenderMode.Prerender
  }
];
