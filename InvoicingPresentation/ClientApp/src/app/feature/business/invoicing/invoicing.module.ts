import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { CustomerComponent } from './component/customer/customer.component';
import { FormCustomersComponent } from './component/form-customers/form-customers.component';
import { FormCustomersModule } from './component/form-customers/form-customers.module';


const routes: Routes = [
  {
    path: '',
    component: CustomerComponent,
    children: [
      {
        path: 'form',
        loadChildren: () => import('./component/form-customers/form-customers.module').then( (m) => m.FormCustomersModule)
      },
    ],
  }
];

@NgModule({
  declarations: [
    CustomerComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    FormCustomersModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes)
  ],
  providers: [],
})
export class InvoicingModule {}
