import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
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

    constructor(private ref: ChangeDetectorRef, private ordersService: OrdersService, private authenticationService: AuthenticationService, private userService: UserService) {
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
                this.recalculatePrices();
            });
    }

    recalculatePrices() {

        this.totalPrice = 0;
        for (var i = 0; i < this.cart.OrderItems.length; i++) {
            this.totalPrice += this.cart.OrderItems[i].Product.Price * this.cart.OrderItems[i].Count;
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
    }

    addOne(productId: number) {
        var index = this.cart.OrderItems.findIndex((value, i, arr) => arr[i].ProductId == productId);
        this.cart.OrderItems[index].Count = this.cart.OrderItems[index].Count + 1;
        console.log(this.cart.OrderItems[index]);
        this.recalculatePrices();
        this.ref.markForCheck();
    }

    removeOne(productId: number) {
        var index = this.cart.OrderItems.findIndex((value, i, arr) => arr[i].ProductId == productId);
        this.cart.OrderItems[index].Count = this.cart.OrderItems[index].Count - 1;
        this.recalculatePrices();
        this.ref.markForCheck();
    }

    removeAll(productId: number) {
        this.cart.OrderItems = this.cart.OrderItems.filter((value, i, arr) => arr[i].ProductId != productId);
        this.recalculatePrices();
        this.ref.markForCheck();
    }

    updateOrder() {
    }
}
