import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { FormProductComponent } from './form-product.component';

const routes: Routes = [
  {
    path: 'form',
    component: FormProductComponent
  },
  {
    path: 'form/:id',
    component: FormProductComponent
  },
];

@NgModule({
  declarations: [
    FormProductComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    FormProductComponent,
  ],
  providers: [
  ],
})

export class FormProductModule { }
