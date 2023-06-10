using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
	internal class Circle : Formas
	{
		private const double PI = 3.1416;
		private double Radius { get; set; }

		public Circle(double Radius, string Color) : base(Color)
		{
			this.Radius = Radius;
		}

		public double GetRadius() => Radius;

		public static Circle ReadCircle()
		{
			string color = Functions.ReadString("Introduce el color del círculo", 3);
			double radius = Functions.ReadDouble("Introduce el radio (número positivo)", 0);
			return new Circle(radius, color);
		}

		public override double Area() => PI * GetRadius() * GetRadius();

		public string GetArea() => Convert.ToString(Area());

		public override string ToString() => $"Círculo:\nColor - {GetColor()}\nRadio - {GetRadius()}\nÁrea - {GetArea()}\n\n";
	}
}
