import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Address } from "../../../../../shared/model/address/address";

@Injectable({ providedIn: 'root' })
export class AddressService {

  private headers = new HttpHeaders().append(
    'Content-Type',
    'application/json'
  );

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getByIdPerson(idPerson: number): Observable<Address> {
    return this.http.get(`${this.baseUrl}Address/GetByIdPerson?pIdPerson=${idPerson}`).pipe(map((response: any) => {
      (response as Address[]).map(address => {
        return address;
      });
      return response;
    }));
  }

  async deleteAddress(id: number): Promise<any> {
    let response = await this.http.delete<any>(`${this.baseUrl}Address/Delete?pId=${id}`, { headers: this.headers }).toPromise();
    return response;
  }

  async updateAddress(address: Address): Promise<any> {
    let response = await this.http.put<Address>(`${this.baseUrl}Address/Update`, address, { headers: this.headers }).toPromise();
    return response;
  }

  async createAddress(address: Address): Promise<any> {
    let response = await this.http.post<Address>(`${this.baseUrl}Address/Create`, address, { headers: this.headers }).toPromise();
    return response;
  }

  async getAddressById(idAddress: number): Promise<Address> {
    let response = await this.http.get<Address>(`${this.baseUrl}Address/GetByIdAddress?pIdAddress=${idAddress}`, { headers: this.headers }).toPromise();
    return response;
  }
}
