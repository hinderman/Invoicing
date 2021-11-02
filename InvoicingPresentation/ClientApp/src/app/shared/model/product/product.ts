import { Category } from "../Category/category";

export class Product {
  id!: number;
  category!: Category;
  description!: string;
  barCode!: string;
  unitPrice!: number;
  stock!: number;
}
