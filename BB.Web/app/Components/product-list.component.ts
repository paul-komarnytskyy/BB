import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../Services/products.service'
import { OrdersService } from '../Services/orders.service'
import { AuthenticationService } from '../Services/authentication.service'

@Component({
    moduleId: module.id,
    selector: 'product-list',
    templateUrl: './product-list.html',
})

export class ProductListComponent implements OnInit {
    public products: any[];
    public discount: string;
    public discValue: number;
    private isAuthenticated: boolean;

    constructor(private productsService: ProductsService, private orderService: OrdersService, private authenticationService: AuthenticationService) {
        this.authenticationService.getUserID();
        this.isAuthenticated = this.authenticationService.token != null;
    }

    ngOnInit() {
        this.productsService.getProducts().map((response) => response.json())
            .subscribe((data) => {
                this.products = [];
                for (var product of data.products) {
                    this.products.push(product);
                }
            });
    }

    onClick(productId: number) {
        this.orderService.addToCart(productId).map((response) => response.json())
            .subscribe((data) => {
                console.log(data);
            });
    }
}
