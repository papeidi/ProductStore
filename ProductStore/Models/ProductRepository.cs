using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductStore.Models
{
	public class ProductRepository : IProductRepository
	{
		private List<Product> products = new List<Product>();
		private int _nextId = 1;

		/// <summary>
		/// 
		/// </summary>
		public ProductRepository()
		{
			Add(new Product { Name = "T-Shirt", Category = "Textile", Price = 19.00M });
			Add(new Product { Name = "Clio", Category = "Voiture", Price = 35000M });
			Add(new Product { Name = "MacBook", Category = "Informatique", Price = 1200M });
			Add(new Product { Name = "Pomme", Category = "Fruit", Price = 1.2M });
			Add(new Product { Name = "Steak-Haché", Category = "Viande", Price = 7.50M });
			Add(new Product { Name = "Fromage", Category = "Laiterie", Price = 2.80M });
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Product> GetAll()
		{
			return products;
		}

		public Product Get(int id)
		{
			return products.Find(p => p.Id == id);
		}

		public Product Add(Product item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			item.Id = _nextId++;
			products.Add(item);
			return item;
		}

		public void Remove(int id)
		{
			products.RemoveAll(p => p.Id == id);
		}

		public bool Update(Product item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			int index = products.FindIndex(p => p.Id == item.Id);
			if (index == -1)
			{
				return false;
			}
			products.RemoveAt(index);
			products.Add(item);
			return true;
		}
	}
}