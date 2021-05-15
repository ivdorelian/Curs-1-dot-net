import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from './product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private apiUrl: string;

  constructor(private httpClient: HttpClient, @Inject('API_URL') apiUrl: string) {
    this.apiUrl = apiUrl;
  }

  getProducts(): Observable<Product[]> {
    return this.httpClient.get<Product[]>(this.apiUrl + 'product');
  } 
}
