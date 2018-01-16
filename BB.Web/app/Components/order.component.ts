import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../Services/orders.service';
import o = require("../Model/Orders/Order");
import Order = o.Order;

@Component({
    moduleId: module.id,
    selector: 'order',
    templateUrl: './order.html',
})

export class OrderComponent implements OnInit {
    private order: Order;

    constructor(private orderService: OrdersService) {
        this.order = new Order();
    }

    ngOnInit() {
        //called after the constructor and called  after the first ngOnChanges() 
        this.orderService.getOrders().map((response) => response.json())
            .subscribe((data) => {
                this.order = data;
            });
    }

    getTranslation(status: number): string {
        switch (status) {
            case 1:
                return "In cart";
            case 2:
                return "Ordered";
            case 3:
                return "Processed";
            case 4:
                return "Delivered";
            default:
                return "Undefined";
        }
    }

    createOrder() {
        this.orderService.createOrder(1).map((response) => response.json())
            .subscribe((data) => {
               // this.order = data
                console.log(data);
            });
    }
}