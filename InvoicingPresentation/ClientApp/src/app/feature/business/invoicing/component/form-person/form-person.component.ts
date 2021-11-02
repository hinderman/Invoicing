import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Person } from 'src/app/shared/model/person/person';
import { PersonService } from '../person/person.service';

@Component({
  selector: 'app-form-person',
  templateUrl: './form-person.component.html'
})

export class FormPersonComponent implements OnInit {
  person: Person = new Person();

  constructor(private personService: PersonService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    //this.loadPerson();
  }

  //loadPerson(): void {
  //  this.activatedRoute.params.subscribe((params) => {
  //    if (params.id && params.id != 0) {
  //      this.person.id = params.id;
  //      this.personService.getPersonById(this.person.id).subscribe((response) => {
  //        this.person = response;
  //      }, error => {
  //        alert(error);
  //      });
  //    }
  //  });
  //}

  //updatePerson(e: any): void {
  //  //this.personService.updatePerson(this.person).subscribe(() => {
  //  //  alert('!Actualización exitosa¡');
  //  //  this.router.navigate(['/']);
  //  //});
  //}

  //createPerson(): void {
  //  this.personService.createPerson(this.person).subscribe((response) => {
  //    alert('!Creación exitosa¡');
  //    this.router.navigate(['/']);
  //  });
  //}
}
