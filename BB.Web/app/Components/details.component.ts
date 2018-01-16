import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DetailsService } from '../Services/details.service'
import { Product } from '../Model/Products/Product';
import { Router } from '@angular/router';
import { OrdersService } from '../Services/orders.service';
import o = require("../Model/Orders/Order");
import Order = o.Order;

@Component({
    selector: 'details-app',
    templateUrl: 'app/Components/details.html',
})
export class DetailsComponent implements OnInit {
    private Id: any;
    private product: Product;
    private order: Order;
    constructor(private activatedRoute: ActivatedRoute, private detailsService: DetailsService, private router: Router, private orderService: OrdersService) {
        let params: any = this.activatedRoute.snapshot.params;
        this.Id = params.id;
        this.product = new Product();
        console.log(this.Id);
    }

   ngOnInit() {
    this.detailsService.getProductById(this.Id).map((response) => response.json())
            .subscribe((data) => {
                console.log(data);
                this.product = data;
                console.log(this.product);
            });
    }

   addToCart() {
       debugger;
       this.orderService.createOrder(1).map((response) => response.json())
           .subscribe((data) => {
               this.order = data
               console.log(data);
               this.router.navigateByUrl('/order/' + this.order.OrderId);
           });
   }
}