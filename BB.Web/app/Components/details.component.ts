import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DetailsService } from '../Services/details.service'
import { Product } from '../Model/Products/Product';

@Component({
    selector: 'details-app',
    templateUrl: 'details.html',
})
export class DetailsComponent implements OnInit {
    private Id: any;
    private product: Product;
    constructor(private activatedRoute: ActivatedRoute, private detailsService: DetailsService) {
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
}