using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
	internal class Ejercicio1_Apartado3
	{
		public static List<Product> products = new List<Product>()
		{
			{ new Product("Sandwicht de pollo", 3) },
			{ new Product("Zumo de Naranja", 2) },
			{ new Product("Agua", 1) },
			{ new Product("Tortilla española", 3.5m) },
			{ new Product("Pan tumaca", 2.3m) },
		};
		string Name { get; set; }
		decimal Price { get; set; }

		public Product(string Name, decimal Price)
		{
			this.Name = Name;
			this.Price = Price;
		}

		public static void ShowProducts()
		{
			int i = 0;
			products.ForEach(product =>
			{
				Console.WriteLine($"{i}:\n\t{product}");
				i++;
			});
		}

		public string GetName() => Name;

		public decimal GetPrice() => Price;

		public override string ToString() => $"Nombre: {GetName()}\n\tPrecio: {GetPrice()}$";
	}
}
