import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from 'src/app/shared/model/customer/customer';
import { CustomerService } from '../customer/customer.service';

@Component({
  selector: 'app-form-customers',
  templateUrl: './form-customers.component.html',
  styleUrls: ['./form-customers.component.css']
})

export class FormCustomersComponent implements OnInit {
  customer: Customer = new Customer();

  constructor(private customerService: CustomerService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadCustomer();
  }

  loadCustomer(): void {
    this.activatedRoute.params.subscribe((params) => {
      if (params.id && params.id != 0) {
        this.customer.id = params.id;
        this.customerService.getCustomerById(this.customer.id).subscribe((response) => {
          this.customer = response;
        }, error => {
          alert(error);
        });
      }
    });
  }

  updateCustomer(): void {
    this.customerService.updateCustomer(this.customer).subscribe(() => {
      alert('!Actualización exitosa¡');
      this.router.navigate(['/']);
    });
  }

  createCustomer(): void {
    this.customerService.createCustomer(this.customer).subscribe((response) => {
      alert('!Creación exitosa¡');
      this.router.navigate(['/']);
    });
  }
}
