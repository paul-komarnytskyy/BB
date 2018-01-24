import p = require("../Products/ProductShort");
import ProductShort = p.ProductShort;

export class OrderItem
{
    public OrderId: string;
    public ProductId: number;
    public Count: number;
    public PricePerItem: number;
    public Product: ProductShort;
}