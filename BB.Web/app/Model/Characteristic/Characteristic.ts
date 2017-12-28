import pc = require("../Products/ProductCategory")
import ProductCategory = pc.ProductCategory;
import pch = require("../Products/ProductCharacteristic");
import ProductCharacteristic = pch.ProductCharacteristic;
import co = require("./CharacteristicOption");
import CharacteristicOption = co.CharacteristicOption;

export class Characteristic {
    public CharacteristicId: string;
    public Name: string;
    public Type: number;
    public ProductCharacteristics: ProductCharacteristic[];
    public ProductCategories: ProductCategory[];
    public CharacteristicOptions: CharacteristicOption[];
}