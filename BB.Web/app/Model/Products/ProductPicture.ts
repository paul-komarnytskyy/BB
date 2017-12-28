import p = require("../Products/Product");
import Product = p.Product;
import pc = require("../Products/ProductCategory");
import ProductCategory = pc.ProductCategory;

export class ProductPicture{
    public ProductPictureId: string;
    public PictureUrl: string;
    public ProductId?: number;
    public Product: Product;
    public FacedProduct: Product[];
    public DefaultingCategory: ProductCategory[];
}