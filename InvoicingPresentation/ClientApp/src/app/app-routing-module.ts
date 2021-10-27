import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerModule } from './feature/customer/customer-module'
import { DashBoardComponent } from './shared/dashboard-component';

const routes: Routes = [
  {
    path: '',
    component: DashBoardComponent,
    children: [
      {
        path: 'customer',
        loadChildren: () => import('./feature/customer/customer-module').then((m) => m.CustomerModule)
      }
    ]
    //En caso  de tener loguin se configura en esta parte
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
