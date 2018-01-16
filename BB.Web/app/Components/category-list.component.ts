import { Component, OnInit } from '@angular/core';
import { CategoriesService } from '../Services/categories.service';

@Component({
    moduleId: module.id,
    selector: 'category-list',
    templateUrl: './category-list.html',
})

export class CategoryListComponent implements OnInit {
    private categories: any[];

    constructor(private categoriesService: CategoriesService) {
        this.categories = [];
    }

    ngOnInit() {
        //called after the constructor and called  after the first ngOnChanges() 
        this.categoriesService.getCategories().map((response) => response.json())
            .subscribe((data) => {
                this.categories.length = 0;
                for (var category of data.result) {
                    this.categories.push(category);
                }
            });
    }
}
