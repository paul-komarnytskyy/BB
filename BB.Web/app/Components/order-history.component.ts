import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../Services/orders.service';

@Component({
    moduleId: module.id,
    selector: 'order-history',
    templateUrl: './order-history.html',
})

export class OrderHistoryComponent implements OnInit {
    private orders: any[];

    constructor(private orderService: OrdersService) {
    }

    ngOnInit() {
        //called after the constructor and called  after the first ngOnChanges() 
        this.orderService.getOrders().map((response) => response.json())
            .subscribe((data) => {
                this.orders = [];
                for (var order of data) {
                    this.orders.push(order);
                }
            });
    }
}