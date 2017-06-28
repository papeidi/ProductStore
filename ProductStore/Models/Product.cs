using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductStore.Models
{
	/// <summary>
	/// Product class
	/// </summary>
	public class Product
	{
		/// <summary>
		/// Id du produit
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Nom du produit
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Catégorie du produit
		/// </summary>
		public string Category { get; set; }

		/// <summary>
		/// Prix du produit
		/// </summary>
		public decimal Price { get; set; }
	}
}