import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { tap } from 'rxjs/operators';
import { Product } from '../../../../../shared/model/product/product';
import { ProductService } from './product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})

export class ProductComponent implements OnInit {

  product = [] as Product[];

  constructor(private productService: ProductService, private router: Router, private activatedRote: ActivatedRoute) { }

  ngOnInit(): void {
    this.getProduct();
  }

  getProduct(): void {
    this.productService.getProduct().pipe(tap((response: any) => {
      (response as Product[]).forEach((product) => { });
    })).subscribe((response) => {
      this.product = response as Product[];
    });
  }

  deleteProduct(id: number): void {
    this.productService.deleteProduct(id).subscribe(() => {
      this.getProduct();
    });
  }
}
