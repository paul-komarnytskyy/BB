import { Component } from '@angular/core';
import PLI = require("../Model/Products/ProductListItem");
import ProductListItem = PLI.ProductListItem;

@Component({
    moduleId: module.id,
    selector: 'product-list',
    templateUrl: './product-list.html',
})

export class ProductListComponent {
    public Items: ProductListItem[];
}
