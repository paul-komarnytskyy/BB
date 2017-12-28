import o = require("./Order");
import Order = o.Order;
import p = require("../Products/Product");
import Product = p.Product;

export class OrderItem
{
    public OrderId: string;
    public ProductId: number;
    public Count: number;
    public PricePerItem: number;
    public Product: Product;
    public Order: Order;
}