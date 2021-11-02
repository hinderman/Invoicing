import { Injectable } from '@angular/core';
import { Sidebar } from '../../model/sidebar/sidebar';

let sidebar: Sidebar[] = [
  { id: 1, text: "Customer", icon: "group", path: "" },
  { id: 2, text: "Employee", icon: "group", path: "" },
  { id: 3, text: "Invoicing", icon: "money", path: "formInvoicing" },
  { id: 3, text: "Category", icon: "tags", path: "formCategory" },
  { id: 4, text: "Product", icon: "product", path: "formProduct" }
];

@Injectable({ providedIn: 'root' })
export class SidebarService {
  getNavigationList(): Sidebar[] {
    return sidebar;
  }
}
