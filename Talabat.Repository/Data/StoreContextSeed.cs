﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.DomainLayer.Entities;

namespace Talabat.Repository.Data
{
	public class StoreContextSeed
	{
		public static async Task SeedAsync(StoreContext storeContext)
		{
			if (!storeContext.ProductBrands.Any())
			{
				var data = File.ReadAllText("../Talabat.Repository/Data/DataSeed/brands.json");
				var brands = JsonSerializer.Deserialize<List<ProductBrand>>(data);
				if (brands is not null)
				{
					foreach (var item in brands)
						await storeContext.ProductBrands.AddAsync(item);
					await storeContext.SaveChangesAsync();
				}
			}

			if (!storeContext.ProductTypes.Any())
			{
				var data = File.ReadAllText("../Talabat.Repository/Data/DataSeed/categories.json");
				var types = JsonSerializer.Deserialize<List<ProductType>>(data);
				if (types is not null)
				{
					foreach (var item in types)
						await storeContext.ProductTypes.AddAsync(item);
					await storeContext.SaveChangesAsync();
				}
			}

			if (!storeContext.Products.Any())
			{
				var data = File.ReadAllText("../Talabat.Repository/Data/DataSeed/products.json");
				var products = JsonSerializer.Deserialize<List<Product>>(data);
				if (products is not null)
				{
					foreach (var item in products)
						await storeContext.Products.AddAsync(item);
					await storeContext.SaveChangesAsync();
				}
			}
		}
	}
}
