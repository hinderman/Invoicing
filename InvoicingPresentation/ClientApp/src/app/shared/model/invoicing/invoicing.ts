import { Person } from "../person/person";

export class Invoicing {
  id!: number;
  Date!: Date;
  Hour!: Date;
  CustomerDocument!: Person
  SellerDocument!: Person
}
