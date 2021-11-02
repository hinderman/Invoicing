import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { BusinessComponent } from './business.component';

const routes: Routes = [
    {
      path: '',
      component: BusinessComponent,
      children: [
        {
          path: '',
          pathMatch: 'full',
          redirectTo: 'invoicing',
        },
        {
          path: 'invoicing',
          loadChildren: () =>
            import('./invoicing/invoicing.module').then((m) => m.InvoicingModule),
        }
      ],
    },
];

@NgModule({
  declarations: [
    BusinessComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})

export class BusinessModule { }
