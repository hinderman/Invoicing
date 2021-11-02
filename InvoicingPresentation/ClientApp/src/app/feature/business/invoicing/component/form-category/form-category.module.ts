import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { FormCategoryComponent } from './form-category.component';

const routes: Routes = [
  {
    path: 'form',
    component: FormCategoryComponent
  },
  {
    path: 'form/:id',
    component: FormCategoryComponent
  },
];

@NgModule({
  declarations: [
    FormCategoryComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(routes)
  ],
  exports: [
    FormCategoryComponent,
  ],
  providers: [
  ],
})

export class FormCategoryModule { }
