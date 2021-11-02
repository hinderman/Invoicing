import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, throwError } from "rxjs";
import { catchError, map } from "rxjs/operators";
import { Invoicing } from "../../../../../shared/model/invoicing/invoicing";
@Injectable({ providedIn: 'root' })

export class InvoicingService {

  private headers = new HttpHeaders().append(
    'Content-Type',
    'application/json'
  );

  constructor(private http: HttpClient, private router: Router, @Inject('BASE_URL') private baseUrl: string) { }

  getInvoicing(): Observable<any> {
    return this.http.get(this.baseUrl + 'Invoicing/GetAll').pipe(map((response: any) => {
      (response as Invoicing[]).map(person => {
        return person;
      });
      return response;
    }));
  }

  deleteInvoicing(id: number): Observable<any> {
    return this.http.delete<any>(this.baseUrl + 'Invoicing/Delete?pId=' + id, { headers: this.headers }).pipe(catchError(err => {
      return throwError(err);
    }));
  }

  getInvoicingById(id: number): Observable<any> {
    return this.http.get<Invoicing>(this.baseUrl + 'Invoicing/GetById?pId=' + id).pipe(catchError(err => {
      this.router.navigate(['invoicing'])
      return throwError(err);
    }));
  }

  updateInvoicing(person: Invoicing): Observable<Invoicing> {
    return this.http.put<any>(this.baseUrl + 'Invoicing/Update', person, { headers: this.headers }).pipe(catchError(err => {
      return throwError(err);
    }));
  }

  createInvoicing(person: Invoicing): Observable<any> {
    return this.http.post<Invoicing>(this.baseUrl + 'Invoicing/Create', person, { headers: this.headers }).pipe(catchError(err => {
      return throwError(err);
    }));
  }
}
