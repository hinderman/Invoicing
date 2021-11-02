import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Phone } from "../../../../../shared/model/phone/phone";

@Injectable({ providedIn: 'root' })
export class PhoneService {

  private headers = new HttpHeaders().append(
    'Content-Type',
    'application/json'
  );

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getByIdPerson(idPerson: number): Observable<Phone> {
    return this.http.get(`${this.baseUrl}Phone/GetByIdPerson?pIdPerson=${idPerson}`).pipe(map((response: any) => {
      (response as Phone[]).map(phone => {
        return phone;
      });
      return response;
    }));
  }

  async deletePhone(id: number): Promise<any> {
    let response = await this.http.delete<any>(`${this.baseUrl}Phone/Delete?pId=${id}`, { headers: this.headers }).toPromise();
    return response;
  }

  async updatePhone(phone: Phone): Promise<any> {
    let response = await this.http.put<Phone>(`${this.baseUrl}Phone/Update`, phone, { headers: this.headers }).toPromise();
    return response;
  }

  async createPhone(phone: Phone): Promise<any> {
    let response = await this.http.post<Phone>(`${this.baseUrl}Phone/Create`, phone, { headers: this.headers }).toPromise();
    return response;
  }

  async getPhoneById(idPhone: number): Promise<Phone> {
    let response = await this.http.get<Phone>(`${this.baseUrl}Phone/GetByIdPhone?pIdPhone=${idPhone}`, { headers: this.headers }).toPromise();
    return response;
  }
}
