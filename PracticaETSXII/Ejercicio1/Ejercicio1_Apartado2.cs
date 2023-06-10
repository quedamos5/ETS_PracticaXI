using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
	internal class Ejercicio1_Apartado2
	{
		Product Product { get; set; }
		string Time { get; set; }

		public Order(Product Product)
		{
			this.Product = Product;
			Time = GetDate();
		}

		public string GetDate()
		{
			DateTime actualDate = DateTime.Now;
			return actualDate.ToString("dd/MM/yyyy HH:mm:ss");
		}

		public static bool ItIsFull(Queue c) => c.Size() == 5 ? true : false;

		public static Order MakeOrder()
		{
			Order order;
			int option;
			Product.ShowProducts();
			option = Functions.ReadInt("Elija un producto: ", 0, Product.products.Count - 1);
			order = new Order(Product.products[option]);
			return order;
		}

		public static decimal CountMoney(List<Order> orders)
		{
			decimal total = 0;
			orders.ForEach(order =>
			{
				total += order.Product.GetPrice();
			});
			return total;
		}

		public static void ShowOrders(List<Order> orders)
		{
			orders.ForEach(order => {
				Console.WriteLine(order);
			});
		}
		public string GetTime() => Time;

		public override string ToString() => $"producto: {Product}\tfecha-hora:{GetTime()}";
	}
}
