import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormCustomersComponent } from './form-customers.component';
import { FormsModule } from '@angular/forms';

const routes: Routes = [
  {
    path: 'form',
    component: FormCustomersComponent
  },
  {
    path: 'form/:id',
    component: FormCustomersComponent
  },
];

@NgModule({
  declarations: [
    FormCustomersComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    FormCustomersComponent,
  ],
  providers: [
  ],
})
export class FormCustomersModule { }
