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

    constructor(private productsService: ProductsService, private ordersService: OrdersService, private authenticationService: AuthenticationService) {
        
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

    addToCart(productId: number) {
        this.ordersService.addItemToOrder(this.authenticationService.userID, productId);
    }

    isLoggedIn() {
        return this.authenticationService.token != null;
    }
}
