import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from '../../../../../shared/model/category/category';
import { CategoryService } from '../category/category.service';

@Component({
  selector: 'app-form-category',
  templateUrl: './form-category.component.html'
})

export class FormCategoryComponent implements OnInit {
  category: Category = new Category();

  constructor(private categoryService: CategoryService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadCategory();
  }

  loadCategory(): void {
    this.activatedRoute.params.subscribe((params) => {
      if (params.Id && params.Id != 0) {
        this.category.id = params.Id;
        this.categoryService.getCategoryById(this.category.id).subscribe((response) => {
          this.category = response;
        }, error => {
          alert(error);
        });
      }
    });
  }

  updateCategory(): void {
    this.categoryService.updateCategory(this.category).subscribe(() => {
      alert('!Actualización exitosa¡');
      this.router.navigate(['/']);
    });
  }

  createCategory(): void {
    this.categoryService.createCategory(this.category).subscribe((response) => {
      alert('!Creación exitosa¡');
      this.router.navigate(['/']);
    });
  }
}
