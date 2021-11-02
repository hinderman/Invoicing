import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Invoicing } from '../../../../../shared/model/invoicing/invoicing';
import { InvoicingService } from '../invoicing/invoicing.service';

@Component({
  selector: 'app-form-invoicing',
  //templateUrl: './form-invoicing.component.html'
  template: '<div>form-invoicing.component</div>'
})

export class FormInvoicingComponent implements OnInit {
  invoicing: Invoicing = new Invoicing();

  constructor(private invoicingService: InvoicingService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadInvoicing();
  }

  loadInvoicing(): void {
    this.activatedRoute.params.subscribe((params) => {
      if (params.id && params.id != 0) {
        this.invoicing.id = params.id;
        this.invoicingService.getInvoicingById(this.invoicing.id).subscribe((response) => {
          this.invoicing = response;
        }, error => {
          alert(error);
        });
      }
    });
  }

  updateInvoicing(): void {
    this.invoicingService.updateInvoicing(this.invoicing).subscribe(() => {
      alert('!Actualización exitosa¡');
      this.router.navigate(['/']);
    });
  }

  createInvoicing(): void {
    this.invoicingService.createInvoicing(this.invoicing).subscribe((response) => {
      alert('!Creación exitosa¡');
      this.router.navigate(['/']);
    });
  }
}
