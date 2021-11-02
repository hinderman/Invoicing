import { Component, Input, OnInit } from '@angular/core';
import { Email } from '../../../../../shared/model/email/email';
import { EmailService } from './email.service';
import { tap } from 'rxjs/operators';

@Component({
  selector: 'app-email',
  templateUrl: './email.component.html',
  styleUrls: ['./email.component.css']
})

export class EmailComponent implements OnInit {

  email: Email[];
  isVisible = false;
  isLoading = false;
  type = 'info';
  message = '';
  pattern: any = /^(\(\+?\d{2,3}\)[\*|\s|\-|\.]?(([\d][\*|\s|\-|\.]?){6})(([\d][\s|\-|\.]?){2})?|(\+?[\d][\s|\-|\.]?){8}(([\d][\s|\-|\.]?){2}(([\d][\s|\-|\.]?){2})?)?)$/;
  loadPanelPosition = { of: '#gridContainer' };
  @Input() idPerson: number;

  constructor(private emailService: EmailService) {
  }

  ngOnInit(): void {
    this.isLoading = true;
    this.emailService.getByIdPerson(this.idPerson).pipe(tap((response: any) => {
      response as Email[]
    })).subscribe((response) => {
      this.email = response as Email[];
      this.isLoading = false;
    });
  }

  async updateEmail(event: any) {
    this.isLoading = true;
    try {
      event.promise = await this.emailService.updateEmail(event.data);
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

  async createEmail(event: any) {
    event.data.idPerson = this.idPerson;
    this.isLoading = true;
    try {
      event.promise = await this.emailService.createEmail(event.data);
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

  async deleteEmail(event: any) {
    this.isLoading = true;
    try {
      event.promise = await this.emailService.deleteEmail(event.key);
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
