import r = require("./Rating");
import Rating = r.Rating;

export class ProductListItem {
    public ProductID: number;
    public Name: string;
    public Price: number;
    public ImageURL: string;
    public Rating: Rating;
}