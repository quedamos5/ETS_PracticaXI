using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
	abstract class Formas
	{
		public string Color { get; set; }
		public Formas(string Color)
		{
			this.Color = Color;
		}

		public string GetColor() => Color;

		public abstract double Area();

		public static void ShowList(List<Formas> formas)
		{
			formas.ForEach(f =>
			{
				if (f is Circle circle)
					Console.WriteLine(circle);
				else if (f is Rectangle rectangle)
					Console.WriteLine(rectangle);
				else
					Console.WriteLine((Triangle)f);
			});
		}
	}
}
