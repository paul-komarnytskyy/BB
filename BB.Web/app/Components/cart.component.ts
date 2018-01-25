import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../Services/orders.service'
import { AuthenticationService } from '../Services/authentication.service'
import { UserService } from '../Services/user.service'

import { Order } from '../Model/Orders//Order'

@Component({
    selector: 'cart-component',
    templateUrl: '/app/Components/cart.html',
})

export class CartComponent {

    private cart: Order;
    private totalPrice: number;
    private priceWithDiscount: number;
    private discountReason: string;
    private hasDiscount: boolean;

    constructor(private ordersService: OrdersService, private authenticationService: AuthenticationService, private userService: UserService) {
        this.totalPrice = 0;
    }

    ngOnInit() {
        this.ordersService.getCart().map((response) => response.json())
            .subscribe((data) => {
                this.cart = new Order();
                this.cart.OrderId = data.OrderId;
                this.cart.StatusUpdate = 1;
                this.cart.UserId = data.UserId;
                this.cart.OrderItems = data.OrderItems;
                this.totalPrice = 0;
                for (var i = 0; i < data.OrderItems.length; i++) {
                    this.totalPrice += data.OrderItems[i].Product.Price * data.OrderItems[i].Count;
                }

                switch (this.userService.CurrentUser.LoyaltyStatus) {
                    case 1:
                        this.priceWithDiscount = this.totalPrice * 0.9;
                        this.hasDiscount = true;
                        this.discountReason = "As a loyal customer, you get 10% off on all of your orders."
                        break;
                    case 2:
                        this.priceWithDiscount = this.totalPrice * 0.8;
                        this.hasDiscount = true;
                        this.discountReason = "As a VIP of our customer service, you get 20% off on all of your orders."
                        break;
                    default:
                        this.priceWithDiscount = this.totalPrice;
                        this.hasDiscount = false;
                        this.discountReason = '';
                        break;
                }

                console.log(this.cart);
            });
    }
}
