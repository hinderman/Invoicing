import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { tap } from 'rxjs/operators';
import { Category } from '../../../../../shared/model/category/category';
import { CategoryService } from './category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})

export class CategoryComponent implements OnInit {

  category = [] as Category[];

  constructor(private categoryService: CategoryService, private router: Router, private activatedRote: ActivatedRoute) { }

  ngOnInit(): void {
    this.getCategory();
  }

  getCategory(): void {
    this.categoryService.getCategory().pipe(tap((response: any) => {
      (response as Category[]).forEach((category) => { });
    })).subscribe((response) => {
      this.category = response as Category[];
    });
  }

  deleteCategory(id: number): void {
    this.categoryService.deleteCategory(id).subscribe(() => {
      this.getCategory();
    });
  }
}
