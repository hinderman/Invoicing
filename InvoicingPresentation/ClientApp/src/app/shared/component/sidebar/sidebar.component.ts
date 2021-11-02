import { Component, OnInit, ViewChild } from '@angular/core';
import { DxDrawerComponent } from 'devextreme-angular';
import { Sidebar } from '../../model/sidebar/sidebar';
import { SidebarService } from './sidebar.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})

export class SidebarComponent implements OnInit {
  @ViewChild(DxDrawerComponent, { static: false }) drawer: DxDrawerComponent;
  sidebar: Sidebar[];
  openedStateMode: string = 'shrink';
  position: string = 'left';
  revealMode: string = 'expand';
  isDrawerOpen: Boolean = true;

  constructor(sidebarService: SidebarService) {
    this.sidebar = sidebarService.getNavigationList();
  }

  ngOnInit(): void {
  }

  toolbarContent = [{
    widget: 'dxButton',
    location: 'before',
    options: {
      icon: 'menu',
      onClick: () => this.isDrawerOpen = !this.isDrawerOpen
    }
  }];

}
