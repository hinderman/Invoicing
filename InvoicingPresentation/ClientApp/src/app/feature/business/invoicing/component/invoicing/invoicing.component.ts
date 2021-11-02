import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { tap } from "rxjs/operators";
import { Invoicing } from "../../../../../shared/model/invoicing/invoicing";
import { InvoicingService } from "./invoicing.service";

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})

export class InvoicingComponent implements OnInit {

  invoicing = [] as Invoicing[];

  constructor(private invoicingService: InvoicingService, private router: Router, private activatedRote: ActivatedRoute) { }

  ngOnInit(): void {
    this.getInvoicing();
  }

  getInvoicing(): void {
    this.invoicingService.getInvoicing().pipe(tap((response: any) => {
      (response as Invoicing[]).forEach((person) => { });
    })).subscribe((response) => {
      this.invoicing = response as Invoicing[];
    });
  }

  deleteInvoicing(id: number): void {
    this.invoicingService.deleteInvoicing(id).subscribe(() => {
      this.getInvoicing();
    });
  }
}
