import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Router } from '@angular/router';
import { Customer } from '../../../../../shared/model/customer/customer';
@Injectable({ providedIn: 'root' })

export class CustomerService {

  private headers = new HttpHeaders().append(
    'Content-Type',
    'application/json'
  );

  constructor(private http: HttpClient, private router: Router, @Inject('BASE_URL') private baseUrl: string) {}

  getCustomer(): Observable<any> {
    return this.http.get(this.baseUrl + 'Customer/GetAll').pipe(map((response: any) => {
      (response as Customer[]).map(customer => {
        return customer;
      });
      return response;
    }));
  }

  deleteCustomer(id: number): Observable<any> {
    return this.http.delete<any>(this.baseUrl + 'Customer/Delete?pId=' + id, { headers: this.headers }).pipe(catchError(err => {
      return throwError(err);
    }));
  }

  getCustomerById(id: number): Observable<Customer> {
    return this.http.get<Customer>(this.baseUrl + 'Customer/GetById?pId=' + id).pipe(catchError(err => {
      this.router.navigate(['customer'])
      return throwError(err);
    }));
  }

  updateCustomer(customer: Customer): Observable<Customer> {
    return this.http.put<any>(this.baseUrl + 'Customer/Update', customer, { headers: this.headers }).pipe(catchError(err => {
      return throwError(err);
    }));
  }

  createCustomer(customer: Customer): Observable<any> {
    return this.http.post<Customer>(this.baseUrl + 'Customer/Create', customer, { headers: this.headers }).pipe(catchError(err => {
      return throwError(err);
    }));
  }
}
