using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Solteq_server.data;
using Solteq_server.models;
using System.Globalization;
using System.IO;

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
                var products = csv.GetRecords<Product>().ToList();
                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }

        if (!context.NutritionalDetails.Any())
        {
            var nutritionalDetailsFilePath = Path.Combine(dataDirectory, "nutritional_details.csv");
            using (var reader = new StreamReader(nutritionalDetailsFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var nutritionalDetails = csv.GetRecords<NutritionalDetails>().ToList();
                context.NutritionalDetails.AddRange(nutritionalDetails);
                context.SaveChanges();
            }
        }
    }
}