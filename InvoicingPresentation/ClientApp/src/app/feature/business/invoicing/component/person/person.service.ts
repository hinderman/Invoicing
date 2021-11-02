import { HttpClient, HttpHeaders, HttpResponse } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Person } from "../../../../../shared/model/person/person";

@Injectable({ providedIn: 'root' })
export class PersonService{

  private headers = new HttpHeaders().append(
    'Content-Type',
    'application/json'
  );

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getPerson(): Observable<Person>{
    return this.http.get(`${this.baseUrl}Person/GetAll`).pipe(map((response: any) => {
      (response as Person[]).map(person => {
        return person;
      });
      return response;
    }));
  }

  async deletePerson(id: number): Promise<any> {
    let response = await this.http.delete<any>(`${this.baseUrl}Person/Delete?pId=${id}`, { headers: this.headers }).toPromise();
    return response;
  }

  async updatePerson(person: Person): Promise<any> {
    let response = await this.http.put<Person>(`${this.baseUrl}Person/Update`, person, { headers: this.headers }).toPromise();
    return response;
  }

  async createPerson(person: Person): Promise<any> {
    let response = await this.http.post<Person>(`${this.baseUrl}Person/Create`, person, { headers: this.headers }).toPromise();
    return response;
  }

  //async getPersonById(id: number): Promise<any> {
  //  return await this.http.get<Person>(this.baseUrl + 'Person/GetById?pId=' + id).pipe(catchError(err => {
  //    return throwError(err);
  //  }));
  //}
}
