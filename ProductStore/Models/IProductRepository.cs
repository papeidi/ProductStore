using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Models
{
	/// <summary>
	/// 
	/// </summary>
	interface IProductRepository
	{
		/// <summary>
		/// Permet d'obtenir la liste de tous les produits
		/// </summary>
		/// <returns></returns>
		IEnumerable<Product> GetAll();

		/// <summary>
		/// Permet d'obtenir le produit dont l'id est specifié
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Product Get(int id);

		/// <summary>
		/// Permet d'ajouter un produit à ma list
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		Product Add(Product item);

		/// <summary>
		/// Permet de supprimer un produit de ma liste
		/// </summary>
		/// <param name="id"></param>
		void Remove(int id);

		/// <summary>
		/// Permet de mettre à jour un produit
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		bool Update(Product item);
	}
}
