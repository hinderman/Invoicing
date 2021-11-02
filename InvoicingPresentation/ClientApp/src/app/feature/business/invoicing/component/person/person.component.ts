import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { tap } from 'rxjs/operators';
import { Person } from '../../../../../shared/model/person/person';
import { PersonService } from './person.service';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})

export class PersonComponent implements OnInit {

  person = [] as Person[];
  isVisible = false;
  isLoading = false;
  type = 'info';
  message = '';
  loadPanelPosition = { of: '#gridContainer' };

  constructor(private personService: PersonService, private router: Router, private activatedRote: ActivatedRoute) { }

  ngOnInit(): void {
    this.getPerson();
  }

  getPerson(): void {
    this.isLoading = true;
    this.personService.getPerson().pipe(tap((response: any) => {
      (response as Person[]).forEach((person) => { });
    })).subscribe((response) => {
      this.person = response as Person[];
      this.isLoading = false;
    });
  }

  async updatePerson(event: any) {
    this.isLoading = true;
    try {
      event.promise = await this.personService.updatePerson(event.data);
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
      this.getPerson();
    }
  }

  async createPerson(event: any) {
    this.isLoading = true;
    try {
      event.promise = await this.personService.createPerson(event.data);
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
      this.getPerson();
    }
  }

  async deletePerson(event: any) {
    this.isLoading = true;
    try {
      event.promise = await this.personService.deletePerson(event.key);
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
      this.getPerson();
    }
  }
}
