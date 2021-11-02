import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, throwError } from "rxjs";
import { catchError, map } from "rxjs/operators";
import { Category } from "../../../../../shared/model/category/category";
@Injectable({ providedIn: 'root' })

export class CategoryService {

  private headers = new HttpHeaders().append(
    'Content-Type',
    'application/json'
  );

  constructor(private http: HttpClient, private router: Router, @Inject('BASE_URL') private baseUrl: string) { }

  getCategory(): Observable<any> {
    return this.http.get(this.baseUrl + 'Category/GetAll').pipe(map((response: any) => {
      (response as Category[]).map(category => {
        return category;
      });
      return response;
    }));
  }

  deleteCategory(id: number): Observable<any> {
    return this.http.delete<any>(this.baseUrl + 'Category/Delete?pId=' + id, { headers: this.headers }).pipe(catchError(err => {
      return throwError(err);
    }));
  }

  getCategoryById(id: number): Observable<any> {
    return this.http.get<Category>(this.baseUrl + 'Category/GetById?pId=' + id).pipe(catchError(err => {
      this.router.navigate(['category'])
      return throwError(err);
    }));
  }

  updateCategory(category: Category): Observable<Category> {
    return this.http.put<any>(this.baseUrl + 'Category/Update', category, { headers: this.headers }).pipe(catchError(err => {
      return throwError(err);
    }));
  }

  createCategory(category: Category): Observable<any> {
    return this.http.post<Category>(this.baseUrl + 'Category/Create', category, { headers: this.headers }).pipe(catchError(err => {
      return throwError(err);
    }));
  }
}
