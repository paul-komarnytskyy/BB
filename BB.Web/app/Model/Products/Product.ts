import r = require("./Rating");
import Rating = r.Rating;

export class Product {
    public ProductID: number;
    public Name: string;
    public Price: number;
    public ImageURL: string;
    public Rating: Rating;
    public Category: any;
}