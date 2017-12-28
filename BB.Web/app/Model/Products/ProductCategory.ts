import p = require("../Products/Product");
import Product = p.Product;
import pp = require("../Products/ProductPicture");
import ProductPicture = pp.ProductPicture;
import c = require("../Characteristic/Characteristic");
import Characteristics = c.Characteristic;

export class ProductCategory {
    public ProductCategoryId: number;
    public Name: string;
    public ParentCategoryId?: number;
    public FacingImageId?: string;
    public FacingImage: ProductPicture;
    public ParentCategory: ProductCategory;
    public ChildrenCategories: ProductCategory[];
    public Characteristics: Characteristics[];
    public Products: Product[];

    constructor(childrenCategories: ProductCategory[], products: Product[], characteristics: Characteristics[])
    {
        this.ChildrenCategories = childrenCategories;
        this.Products = products;
        this.Characteristics = characteristics;
    }
}