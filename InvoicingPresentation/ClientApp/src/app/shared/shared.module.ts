import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './component/dashboard/dashboard.component';
import { HeaderComponent } from './component/header/header.component';
import { PaginatorComponent } from './component/paginator/paginator.component';
import { FooterComponent } from './component/footer/footer.component';
import { SidebarComponent } from './component/sidebar/sidebar.component';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { DxDrawerModule, DxListModule, DxRadioGroupModule, DxToolbarModule } from 'devextreme-angular';

@NgModule({
  declarations: [
    DashboardComponent,
    HeaderComponent,
    PaginatorComponent,
    FooterComponent,
    SidebarComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    BrowserModule,
    DxDrawerModule,
    DxListModule,
    DxRadioGroupModule,
    DxToolbarModule
  ],
  exports: [
    SidebarComponent
  ]
})

export class SharedModule { }
