using CsvHelper.Configuration;
using Solteq_server.models;
public class ProductMap : ClassMap<Product>
{
    public ProductMap()
    {
        Map(m => m.Id).Name("id");
        Map(m => m.ProductName).Name("title");
        Map(m => m.CustomText).Name("custom_text");
        Map(m => m.Weight).Name("weight");
        Map(m => m.Warning).Name("warning");
        Map(m => m.Ingredients).Name("ingredients");
        Map(m => m.ProductContains).Name("product_contains");
        Map(m => m.ProductDoesNotContain).Name("product_does_not_contain");
        Map(m => m.Category).Name("category");
    }
}

public class CSVProductMap : ClassMap<ProductCsv>
{
    public CSVProductMap()
    {
        Map(m => m.Id).Name("id");
        Map(m => m.ProductName).Name("title");
        Map(m => m.CustomText).Name("custom_text");
        Map(m => m.Weight).Name("weight");
        Map(m => m.Warning).Name("warning");
        Map(m => m.Ingredients).Name("ingredients");
        Map(m => m.ProductContains).Name("product_contains");
        Map(m => m.ProductDoesNotContain).Name("product_does_not_contain");
        Map(m => m.Category).Name("category");
    }
}
public class NutritionalDetailsMap : ClassMap<NutritionalDetails>
{
    public NutritionalDetailsMap()
    {
        Map(m => m.ProductId).Name("product_id");
        Map(m => m.Calories).Name("calories");
        Map(m => m.Fat).Name("fat");
        Map(m => m.SaturatedFat).Name("saturated_fat");
        Map(m => m.Carbohydrates).Name("carbohydrates");
        Map(m => m.Sugars).Name("sugars");
        Map(m => m.Polyols).Name("polyols");
        Map(m => m.Protein).Name("protein");
        Map(m => m.Salt).Name("salt");
    }
}

public class GenericProductsMap : ClassMap<GenericProduct>
{
    public GenericProductsMap()
    {
        Map(m => m.Id).Name("id");
        Map(m => m.ProductName).Name("title");
        Map(m => m.Category).Name("category");
    }
}