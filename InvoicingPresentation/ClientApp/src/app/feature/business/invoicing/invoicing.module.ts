import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { DxButtonModule, DxDataGridModule, DxLoadPanelModule, DxTemplateModule, DxToastModule } from 'devextreme-angular';
import { AddressComponent } from './component/address/address.component';
import { EmailComponent } from './component/email/email.component';
import { FormPersonModule } from './component/form-person/form-person.module';
import { PersonComponent } from './component/person/person.component';
import { PhoneComponent } from './component/phone/phone.component';

const routes: Routes = [
  {
    path: '',
    component: PersonComponent,
    children: [
      {
        path: 'form',
        loadChildren: () => import('./component/form-person/form-person.module').then((m) => m.FormPersonModule)
      },
      {
        path: 'formInvoicing',
        loadChildren: () => import('./component/form-invoicing/form-invoicing.module').then((m) => m.FormInvoicingModule)
      },
      {
        path: 'formCategory',
        loadChildren: () => import('./component/form-category/form-category.module').then((m) => m.FormCategoryModule)
      },
      {
        path: 'formProduct',
        loadChildren: () => import('./component/form-product/form-product.module').then((m) => m.FormProductModule)
      }
    ],
  }
];

@NgModule({
  declarations: [
    PersonComponent,
    PhoneComponent,
    EmailComponent,
    AddressComponent
  ],
  imports: [
    CommonModule,
    DxTemplateModule,
    FormsModule,
    FormPersonModule,
    ReactiveFormsModule,
    DxButtonModule,
    DxDataGridModule,
    DxToastModule,
    DxLoadPanelModule,
    RouterModule.forChild(routes)
  ],
  providers: [],
})

export class InvoicingModule {}
