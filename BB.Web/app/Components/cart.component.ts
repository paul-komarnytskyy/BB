import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../Services/orders.service'

@Component({
    selector: 'cart-component',
    templateUrl: '/app/Components/cart.html',
})

export class CartComponent {

    private cart: any;

    constructor (private ordersService: OrdersService) {
    }

    ngOnInit() {
        this.ordersService.getCart().map((response) => response.json())
            .subscribe((data) => {
                this.cart = data;
                console.log(this.cart);
            });
    }
}
