import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { CustomerComponent } from './customer-component'

const routes: Routes = [
  {
    path: 'customer',
    component: CustomerComponent,
    children: [
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'request'
      }
    ]
  }
];

@NgModule({
  declarations: [CustomerComponent],
  imports: [CommonModule, RouterModule.forChild(routes)],
})

export class CustomerModule { }
