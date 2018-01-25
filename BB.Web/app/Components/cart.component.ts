import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../Services/orders.service'
import { AuthenticationService } from '../Services/authentication.service'
import { UserService } from '../Services/user.service'

@Component({
    selector: 'cart-component',
    templateUrl: '/app/Components/cart.html',
})

export class CartComponent {

    private cart: any;
    private totalPrice: number;
    private priceWithDiscount: number;

    constructor (private ordersService: OrdersService, private authenticationService: AuthenticationService, private userService: UserService) {
    }

    ngOnInit() {
        this.ordersService.getCart().map((response) => response.json())
            .subscribe((data) => {
                this.cart = data;
                this.totalPrice = 0;
                for (var i = 0; i < data.OrderItems.length; i++) {
                    this.totalPrice += data.OrderItems[i].Product.Price * data.OrderItems[i].Count;
                }

                switch (this.userService.CurrentUser.LoyaltyStatus) {
                    case 1:
                        this.priceWithDiscount = this.totalPrice * 1;
                        break;
                    case 2:
                        this.priceWithDiscount = this.totalPrice * 0.9;
                        break;
                    default:
                        this.priceWithDiscount = this.totalPrice;
                        break;
                }

                console.log(this.cart);
            });
    }
}
