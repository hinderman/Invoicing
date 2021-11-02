import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { FormPersonComponent } from './form-person.component';

const routes: Routes = [
  {
    path: 'form',
    component: FormPersonComponent
  },
  {
    path: 'form/:id',
    component: FormPersonComponent
  },
];

@NgModule({
  declarations: [
    FormPersonComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    FormPersonComponent,
  ],
  providers: [
  ],
})

export class FormPersonModule { }
