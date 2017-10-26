import { Component, OnInit } from '@angular/core';
import { CategoriesService } from '../Services/categories.service';

@Component({
    moduleId: module.id,
    selector: 'category-list',
    templateUrl: './category-list.html',
})

export class CategoryListComponent implements OnInit {
    name = 'Angular';
    private categories: string[];
    private categories2: string[];
    private categories3: string[];
    private category: string[];

    constructor(private categoriesService: CategoriesService) {
    }

    ngOnInit() {
        //called after the constructor and called  after the first ngOnChanges() 
        this.categoriesService.getCategories().map((response) => response.json())
            .subscribe((data) => {
                this.categories = [];
                for (var category of data) {
                    this.categories.push(category);
                }
            });

        this.categoriesService.getCategories2().map((response) => response.json())
            .subscribe((data) => {
                this.categories2 = [];
                for (var category of data) {
                    this.categories2.push(category);
                }
            });

        this.categoriesService.getCategories3().map((response) => response.json())
            .subscribe((data) => {
                this.categories3 = [];
                for (var category of data) {
                    this.categories3.push(category);
                }
            });

        this.categoriesService.getCategory().map((response) => response.json())
            .subscribe((data) => {
                this.category = data;
            });
    }
}
