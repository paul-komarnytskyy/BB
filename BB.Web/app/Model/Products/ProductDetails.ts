import r = require("./Rating");
import Rating = r.Rating;
import pc = require("./ProductCharacteristic");
import ProductCharacteristic = pc.ProductCharacteristic;

export class ProductDetails {
    public Description: string;
    public Characteristics: ProductCharacteristic[];
    public Comments: Comment[];
    public Ratings: Rating[];
    public Images: string[];
}