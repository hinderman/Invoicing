import { Component, Input, OnInit } from '@angular/core';
import DataSource from 'devextreme/data/data_source';
import { Phone } from '../../../../../shared/model/phone/phone';
import { PhoneService } from './phone.service';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-phone',
  templateUrl: './phone.component.html',
  styleUrls: ['./phone.component.css']
})

export class PhoneComponent implements OnInit {

  phone: Phone[];
  tasksDataSource: DataSource;
  isVisible = false;
  isLoading = false;
  type = 'info';
  message = '';
  pattern: any = /^(\(\+?\d{2,3}\)[\*|\s|\-|\.]?(([\d][\*|\s|\-|\.]?){6})(([\d][\s|\-|\.]?){2})?|(\+?[\d][\s|\-|\.]?){8}(([\d][\s|\-|\.]?){2}(([\d][\s|\-|\.]?){2})?)?)$/;
  loadPanelPosition = { of: '#gridContainer' };
  @Input() idPerson: number;

  constructor(private phoneService: PhoneService) {
  }

  ngOnInit(): void {
    this.isLoading = true;
    this.phoneService.getByIdPerson(this.idPerson).pipe(tap((response: any) => {
      response as Phone[]
    })).subscribe((response) => {
      this.phone = response as Phone[];
      this.isLoading = false;
    });
  }

  async updatePhone(event: any) {
    this.isLoading = true;
    try {
      event.promise = await this.phoneService.updatePhone(event.data);
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

  async createPhone(event: any) {
    event.data.idPerson = this.idPerson;
    this.isLoading = true;
    try {
      event.promise = await this.phoneService.createPhone(event.data);
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

  async deletePhone(event: any) {
    this.isLoading = true;
    try {
      event.promise = await this.phoneService.deletePhone(event.key);
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
