using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Presestance.Data;

namespace Presestance
{
    public class DbInitilaizer : IDbInitilaizer
    {
        private readonly StoreDbContext _storeDbContext;

        public DbInitilaizer(StoreDbContext  storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }
        public async Task IntilizerAsync()
        {
            

            #region Update Database 
            if(_storeDbContext.Database.GetPendingMigrations().Any())
            {
                await _storeDbContext.Database.MigrateAsync();
            }


            #endregion


            #region Product Types   
            try
            {
                var jsonData = await File.ReadAllTextAsync(@"E:\ASP\c#\ZAPI\Session 01\Files\types.json");
                var producttypes = JsonSerializer.Deserialize<List<ProductType>>(jsonData);

                if (producttypes != null && producttypes.Any())
                {
                    await _storeDbContext.ProductTypes.AddRangeAsync(producttypes);
                    await _storeDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // التعامل مع الاستثناء
                Console.WriteLine($"Error: {ex.Message}");
            }

            #endregion
       
            
            
            
            
            #region Product Brands
            if (!_storeDbContext.ProductBrands.Any())
            {
                var jsonData1 = await File.ReadAllTextAsync(@"E:\ASP\c#\ZAPI\Session 01\Files\brands.json");
                var productbrand =  JsonSerializer.Deserialize<List<ProductBrand>>(jsonData1);

                if (productbrand != null && productbrand.Any())
                {
                    await _storeDbContext.ProductBrands.AddRangeAsync(productbrand);
                    await _storeDbContext.SaveChangesAsync();
                }
            }
            #endregion
            #region Products

            if(!_storeDbContext.Products.Any())
            {
                //Read Data From Json File as String
                var jsonData2 = await File.ReadAllTextAsync(@"E:\ASP\c#\ZAPI\Session 01\Files\products.json");
                //Convert Json String to List of Product
                var product = JsonSerializer.Deserialize<List<Product>>(jsonData2);
                //Add Product to Database
                if (product is not null && product.Any())
                {
                    await _storeDbContext.Products.AddRangeAsync(product);
                    await _storeDbContext.SaveChangesAsync();
                }
            }
         

            #endregion

        




        }







    }
}
