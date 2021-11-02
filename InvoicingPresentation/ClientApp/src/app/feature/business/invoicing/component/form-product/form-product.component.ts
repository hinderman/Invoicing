import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../../../../../shared/model/product/product';
import { ProductService } from '../product/product.service';

@Component({
  selector: 'app-form-product',
  templateUrl: './form-product.component.html'
})

export class FormProductComponent implements OnInit {
  product: Product = new Product();

  constructor(private productService: ProductService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct(): void {
    this.activatedRoute.params.subscribe((params) => {
      if (params.Id && params.Id != 0) {
        this.product.id = params.id;
        this.productService.getProductById(this.product.id).subscribe((response) => {
          this.product = response;
        }, error => {
          alert(error);
        });
      }
    });
  }

  updateProduct(): void {
    this.productService.updateProduct(this.product).subscribe(() => {
      alert('!Actualización exitosa¡');
      this.router.navigate(['/']);
    });
  }

  createProduct(): void {
    this.productService.createProduct(this.product).subscribe((response) => {
      alert('!Creación exitosa¡');
      this.router.navigate(['/']);
    });
  }
}
