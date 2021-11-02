import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { FormInvoicingComponent } from './form-invoicing.component';

const routes: Routes = [
  {
    path: 'form',
    component: FormInvoicingComponent
  },
  {
    path: 'form/:id',
    component: FormInvoicingComponent
  },
];

@NgModule({
  declarations: [
    FormInvoicingComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    FormInvoicingComponent,
  ],
  providers: [
  ],
})

export class FormInvoicingModule { }
