import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DetailsService } from '../Services/details.service'
import { Product } from '../Model/Products/Product';
import { Router } from '@angular/router';
import { OrdersService } from '../Services/orders.service';
import { AuthenticationService } from '../Services/authentication.service';
import o = require("../Model/Orders/Order");
import Order = o.Order;

@Component({
    selector: 'product-details',
    templateUrl: 'app/Components/details.html',
})

export class DetailsComponent implements OnInit {
    private Id: any;
    private product: Product;
    private order: Order;
    constructor(private ref: ChangeDetectorRef, private activatedRoute: ActivatedRoute, private detailsService: DetailsService, private router: Router, private orderService: OrdersService, private authenticationService: AuthenticationService) {
        let params: any = this.activatedRoute.snapshot.params;
        this.Id = params.id;
        this.product = new Product();
            setInterval(() => {
                // the following is required, otherwise the view will not be updated
                this.ref.markForCheck();
            }, 1000);
    }

   ngOnInit() {
    this.detailsService.getProductById(this.Id).map((response) => response.json())
            .subscribe((data) => {
                console.log(data);
                this.product = data;
                console.log(this.product);
            });
    }

    forceRedraw() {
    }
   addToCart() {
       this.orderService.addItemToOrder(this.authenticationService.userID, this.Id).map((response) => response.json())
           .subscribe((data) => {
               this.order = data;
               console.log(data);
               this.router.navigateByUrl('/order/' + this.order.OrderId);
           });
   }
}