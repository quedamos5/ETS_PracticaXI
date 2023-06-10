using System.Drawing;

namespace Ejercicio3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
			List<Formas> formas = new List<Formas>();
			int option;
			do
			{
				option = Functions.Menu();
				switch (option)
				{
					case 1:
						formas.Add(Circle.ReadCircle());
						break;
					case 2:
						formas.Add(Triangle.ReadTriangle());
						break;
					case 3:
						formas.Add(Rectangle.ReadRectangle());
						break;
					case 4:
						if (formas.Count != 0) Formas.ShowList(formas);
						break;
				}

				Console.ReadKey();
				Console.Clear();
			} while (option != 0);
		}
	}
}
