import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../Services/products.service'

@Component({
    moduleId: module.id,
    selector: 'product-list',
    templateUrl: './product-list.html',
})

export class ProductListComponent implements OnInit {
    public products: any[];

    constructor(private productsService: ProductsService) {
        
    }

    ngOnInit() {
        this.productsService.getProducts().map((response) => response.json())
            .subscribe((data) => {
                this.products = [];
                for (var product of data) {
                    this.products.push(product);
                }
            });
    }
}
