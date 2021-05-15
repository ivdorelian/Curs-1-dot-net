import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../product.model';
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-list-products',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent {

  public products: Product[];

  constructor(private productsService: ProductsService) {

  }

  getProducts() {
    this.productsService.getProducts().subscribe(p => this.products = p);
  }

  ngOnInit() {
    this.getProducts();
  }

}
