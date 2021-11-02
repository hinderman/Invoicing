import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Email } from "../../../../../shared/model/email/email";

@Injectable({ providedIn: 'root' })
export class EmailService {

  private headers = new HttpHeaders().append(
    'Content-Type',
    'application/json'
  );

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getByIdPerson(idPerson: number): Observable<Email> {
    return this.http.get(`${this.baseUrl}Email/GetByIdPerson?pIdPerson=${idPerson}`).pipe(map((response: any) => {
      (response as Email[]).map(email => {
        return email;
      });
      return response;
    }));
  }

  async deleteEmail(id: number): Promise<any> {
    let response = await this.http.delete<any>(`${this.baseUrl}Email/Delete?pId=${id}`, { headers: this.headers }).toPromise();
    return response;
  }

  async updateEmail(email: Email): Promise<any> {
    let response = await this.http.put<Email>(`${this.baseUrl}Email/Update`, email, { headers: this.headers }).toPromise();
    return response;
  }

  async createEmail(email: Email): Promise<any> {
    let response = await this.http.post<Email>(`${this.baseUrl}Email/Create`, email, { headers: this.headers }).toPromise();
    return response;
  }

  async getEmailById(idEmail: number): Promise<Email> {
    let response = await this.http.get<Email>(`${this.baseUrl}Email/GetByIdEmail?pIdEmail=${idEmail}`, { headers: this.headers }).toPromise();
    return response;
  }
}
