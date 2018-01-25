import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../Services/orders.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    moduleId: module.id,
    selector: 'cart',
    templateUrl: './order.html',
})

export class OrderComponent implements OnInit {
    public products: any[];
    public discountReason: string;
    public discValue: number;
    public hasDiscount: boolean;
    public discountAmmount: number;
    public totalPrice: number;

    constructor(private orderService: OrdersService, private router: Router) {
        console.log('activated 1');
        
    }

    ngOnInit() {
        console.log('activated 2');
        this.orderService.getCart().map((response) => response.json())
            .subscribe((data) => {
                if (data == "No order found") {
                    return;
                }

                this.products = [];
                this.discountReason = data.reason;
                this.discValue = data.discV;
                this.hasDiscount = false;
                if (this.discValue != null)
                {
                    this.discValue = this.discValue * 100;
                    this.hasDiscount = true;
                }
                this.totalPrice = 0;
                this.discountAmmount = 0;
                for (var product of data.products) {
                    this.products.push(product);
                    this.totalPrice = this.totalPrice + product.Count * product.PricePerItem;
                    this.discountAmmount = this.discountAmmount + product.Product.Price * product.Count;
                }
                this.discountAmmount = this.discountAmmount - this.totalPrice;
                console.log(data);
            });
       
    }

    onClick() {
        //this.orderService.submitOrder().subscribe(data => {
        //});

        this.router.navigateByUrl("home");
    }
}