using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductStore.Models;

namespace ProductStore.Controllers
{
    public class ProductsController : ApiController
    {
		static readonly IProductRepository repository = new ProductRepository();

		/// <summary>
		/// Permet d'obtenir tous les produits
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Product> GetAllProducts()
		{
			return repository.GetAll();
		}

		/// <summary>
		/// Permet d'obtenir le produit dont l'id est specifié
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Product GetProduct(int id)
		{
			Product item = repository.Get(id);
			if (item == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			return item;
		}

		/// <summary>
		/// Permet d'obtenir les produits par catégorie
		/// </summary>
		/// <param name="category"></param>
		/// <returns></returns>
		public IEnumerable<Product> GetProductsByCategory(string category)
		{
			return repository.GetAll().Where(
				p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
		}

		//public Product PostProduct(Product item)
		//{
		//	item = repository.Add(item);
		//	return item;
		//}

		/// <summary>
		/// Permet de créer un nouveau produit
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public HttpResponseMessage PostProduct(Product item)
		{
			item = repository.Add(item);
			var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);

			string uri = Url.Link("DefaultApi", new { id = item.Id });
			response.Headers.Location = new Uri(uri);

			return response;
		}

		/// <summary>
		/// Permet de mettre à jour un produit
		/// </summary>
		/// <param name="id"></param>
		/// <param name="product"></param>
		public void PutProduct(int id, Product product)
		{
			product.Id = id;
			if (!repository.Update(product))
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
		}

		/// <summary>
		/// Permet de supprimer un produit
		/// </summary>
		/// <param name="id"></param>
		public void DeleteProduct(int id)
		{
			Product item = repository.Get(id);
			if (item == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}

			repository.Remove(id);
		}
	}
}
