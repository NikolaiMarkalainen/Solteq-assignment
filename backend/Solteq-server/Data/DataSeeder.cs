using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Solteq_server.data;
using Solteq_server.models;
using System.Globalization;
using System.IO;
using System.Text.Json;
public static class DataSeeder
{
    public static void SeedData(ApplicationDbContext context, string dataDirectory)
    {
        context.Database.EnsureCreated();

        if (!context.Products.Any())
        {
            var productsFilePath = Path.Combine(dataDirectory, "products.csv");
            using (var reader = new StreamReader(productsFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<CSVProductMap>();
                var rawProducts = csv.GetRecords<ProductCsv>().ToList();

                var products = rawProducts.Select(rawProduct => new Product
                {
                    Id = rawProduct.Id,
                    ProductName = rawProduct.ProductName,
                    CustomText = rawProduct.CustomText,
                    Weight = rawProduct.Weight,
                    Warning = rawProduct.Warning,
                    Ingredients = rawProduct.Ingredients,
                    Category = rawProduct.Category,
                    ProductContains = JsonSerializer.Deserialize<List<string>>(rawProduct.ProductContains) ?? new List<string>(),
                    ProductDoesNotContain = JsonSerializer.Deserialize<List<string>>(rawProduct.ProductDoesNotContain) ?? new List<string>()
                }).ToList();
                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }

        if (!context.NutritionalDetails.Any())
        {
            var nutritionalDetailsFilePath = Path.Combine(dataDirectory, "nutrition.csv");
            using (var reader = new StreamReader(nutritionalDetailsFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<NutritionalDetailsMap>();
                var nutritionalDetails = csv.GetRecords<NutritionalDetails>().Select(nd => 
                {
                    nd.Id = 0;
                    return nd;
                }).ToList();
                context.NutritionalDetails.AddRange(nutritionalDetails);
                context.SaveChanges();
            }
        }

        if (!context.GenericProducts.Any())
        {
            var genericProductsFilePath = Path.Combine(dataDirectory, "products.csv");

            using (var reader = new StreamReader(genericProductsFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Register the class map to map specific columns
                csv.Context.RegisterClassMap<GenericProductsMap>();

                // Read records from the CSV and select only the necessary fields
                var genericProducts = csv.GetRecords<GenericProduct>().ToList();

                // Add the generic products to the context and save changes
                context.GenericProducts.AddRange(genericProducts);
                context.SaveChanges();
            }
        }
    }
}