import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, throwError } from "rxjs";
import { catchError, map } from "rxjs/operators";
import { Product } from "../../../../../shared/model/product/product";
@Injectable({ providedIn: 'root' })

export class ProductService {

  private headers = new HttpHeaders().append(
    'Content-Type',
    'application/json'
  );

  constructor(private http: HttpClient, private router: Router, @Inject('BASE_URL') private baseUrl: string) { }

  getProduct(): Observable<any> {
    console.log(this.baseUrl);
    return this.http.get(this.baseUrl + 'Product/GetAll').pipe(map((response: any) => {
      (response as Product[]).map(product => {
        return product;
      });
      return response;
    }));
  }

  deleteProduct(id: number): Observable<any> {
    return this.http.delete<any>(this.baseUrl + 'Product/Delete?pId=' + id, { headers: this.headers }).pipe(catchError(err => {
      return throwError(err);
    }));
  }

  getProductById(id: number): Observable<any> {
    return this.http.get<Product>(this.baseUrl + 'Product/GetById?pId=' + id).pipe(catchError(err => {
      this.router.navigate(['product'])
      return throwError(err);
    }));
  }

  updateProduct(product: Product): Observable<Product> {
    return this.http.put<any>(this.baseUrl + 'Product/Update', product, { headers: this.headers }).pipe(catchError(err => {
      return throwError(err);
    }));
  }

  createProduct(product: Product): Observable<any> {
    return this.http.post<Product>(this.baseUrl + 'Product/Create', product, { headers: this.headers }).pipe(catchError(err => {
      return throwError(err);
    }));
  }
}
