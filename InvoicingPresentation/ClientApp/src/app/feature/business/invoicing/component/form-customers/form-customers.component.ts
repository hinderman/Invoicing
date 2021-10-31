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
          console.log(response);
          this.customer = response;
        }, error => {
          console.log(error)
        });
      }
    });
  }

  updateCustomer(): void {
    this.customerService.updateCustomer(this.customer).subscribe(() => {
      this.router.navigate(['/Customers']);
    });
  }

  createCustomer(): void {
    this.customerService.createCustomer(this.customer).subscribe((response) => {
      alert('se creo el usuario ' + response.name + ' ' + response.lastname);
      this.router.navigate(['Customers']);
    });
  }
}
