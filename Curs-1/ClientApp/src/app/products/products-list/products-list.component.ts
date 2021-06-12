import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product, PaginatedProducts } from '../product.model';
import { ProductsService } from '../products.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-list-products',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent {

  public products: PaginatedProducts;
  currentPage: number;

  constructor(private productsService: ProductsService) {

  }

  //constructor(
  //  private route: ActivatedRoute
  //) { }

  //ngOnInit() {
  //  const firstParam: string = this.route.snapshot.queryParamMap.get('page');
  //  const secondParam: string = this.route.snapshot.queryParamMap.get('perPage');
  //}

  getProducts(page: number = 1) {
    //console.log(event);
    //event.preventDefault();
    this.currentPage = page;
    this.productsService.getProducts(page).subscribe(p => this.products = p);
  }

  ngOnInit() {
    this.getProducts();
  }

}
