import { Component, Input, OnInit } from '@angular/core';
import { Address } from '../../../../../shared/model/address/address';
import { AddressService } from './address.service';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css']
})

export class AddressComponent implements OnInit {

  address: Address[];
  isVisible = false;
  isLoading = false;
  type = 'info';
  message = '';
  loadPanelPosition = { of: '#gridContainer' };
  @Input() idPerson: number;

  constructor(private addressService: AddressService) {
  }

  ngOnInit(): void {
    this.isLoading = true;
    this.addressService.getByIdPerson(this.idPerson).pipe(tap((response: any) => {
      response as Address[]
    })).subscribe((response) => {
      this.address = response as Address[];
      this.isLoading = false;
    });
  }

  async updateAddress(event: any) {
    this.isLoading = true;
    try {
      event.promise = await this.addressService.updateAddress(event.data);
      if (event.promise.isSuccessStatusCode) {
        this.type = 'success';
        this.message = 'Update susses!';
      } else {
        this.type = 'error';
        this.message = `${event.promise.statusCode}: ${event.promise.reasonPhrase}`;
      }
    } finally {
      this.isLoading = false;
      this.isVisible = true;
    }
  }

  async createAddress(event: any) {
    event.data.idPerson = this.idPerson;
    this.isLoading = true;
    try {
      event.promise = await this.addressService.createAddress(event.data);
      if (event.promise.isSuccessStatusCode) {
        this.type = 'success';
        this.message = 'Create susses!';
      } else {
        this.type = 'error';
        this.message = `${event.promise.statusCode}: ${event.promise.reasonPhrase}`;
      }
    } finally {
      this.isLoading = false;
      this.isVisible = true;
    }
  }

  async deleteAddress(event: any) {
    this.isLoading = true;
    try {
      event.promise = await this.addressService.deleteAddress(event.key);
      if (event.promise.isSuccessStatusCode) {
        this.type = 'success';
        this.message = 'Create susses!';
      } else {
        this.type = 'error';
        this.message = `${event.promise.statusCode}: ${event.promise.reasonPhrase}`;
      }
    } finally {
      this.isLoading = false;
      this.isVisible = true;
    }
  }
}
