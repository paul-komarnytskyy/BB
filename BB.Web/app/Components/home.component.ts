import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../Services/products.service'

@Component({
    selector: 'my-app',
    templateUrl: 'app/Components/home.html',
})
export class HomeComponent  {
    products: any[];
    
    constructor(private productsService: ProductsService) {
        this.products = [];
    }

    ngOnInit() {
        this.productsService.getProducts().map((response) => response.json())
            .subscribe((data) => {
                this.products.length = 0;
                var i = 0;
                for (var product of data) {
                    this.products.push(product);
                    i++;
                    if (i == 5) {
                        return;
                    }
                }
            });
    }
}
