import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { tap } from 'rxjs/operators';
import { Customer } from 'src/app/shared/model/customer/customer';
import { CustomerService } from './customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})

export class CustomerComponent implements OnInit {

  customers = [] as Customer[];

  constructor(private customerService: CustomerService, private router: Router, private activatedRote: ActivatedRoute) { }

  ngOnInit(): void {
    this.getCustomer();
  }

  getCustomer(): void {
    this.customerService.getCustomer().pipe(tap((response: any) => {
      (response as Customer[]).forEach((customer) => { });
    })).subscribe((response) => {
      this.customers = response as Customer[];
    });
  }

  deleteCustomer(id: number): void {
    this.customerService.deleteCustomer(id).subscribe(() => {
      this.getCustomer();
    });
  }
}
