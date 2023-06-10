namespace Cafeteria
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Order> orders = new();
			Queue cola = new();
			int option;
			Console.WriteLine("Bienvenido a la cafeteria");
			bool value = true;
			do
			{
				option = Functions.Menu();
				switch (option)
				{
					case 1:
						if (!Order.ItIsFull(cola))
						{
							Order o = Order.MakeOrder();
							orders.Add(o);
							cola.Push(o);
						}
						else
							Console.WriteLine("La cola esta llena, espere o vayase.");
						break;
					case 2:
						cola.Pop();
						break;
					default:
						value = false;
						break;
				}
				Console.ReadKey();
				Console.Clear();
			} while (value);
			decimal total = Order.CountMoney(orders);
			Order.ShowOrders(orders);
			Console.WriteLine($"El total de dinero recaudado ha sido: {total}");

		}
	}
}
