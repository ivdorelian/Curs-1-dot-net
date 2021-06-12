import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaginatedProducts, Product } from './product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private apiUrl: string;

  constructor(private httpClient: HttpClient, @Inject('API_URL') apiUrl: string) {
    this.apiUrl = apiUrl;
  }

  getProducts(page: number): Observable<PaginatedProducts> {
    return this.httpClient.get<PaginatedProducts>(this.apiUrl + 'product', { params: {'page': page} });
  } 
}
