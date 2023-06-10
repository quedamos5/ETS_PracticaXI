using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
	internal class Triangle : Formas
	{
		private double Base { get; set; }
		private double Height { get; set; }

		public Triangle(double Base, double Height, string Color) : base(Color)
		{
			this.Base = Base;
			this.Height = Height;
		}

		public double GetBase() => Base;
		public double GetHeight() => Height;

		public static Triangle ReadTriangle()
		{
			string color = Functions.ReadString("Introduce el color del triángulo", 3);
			double Base = Functions.ReadDouble("Introduce la base (número positivo)", 0),
				   height = Functions.ReadDouble("Introduce la altura (número positivo)", 0);
			return new Triangle(Base, height, color);
		}
		public override double Area() => GetBase() * GetHeight() / 2;

		public string GetArea() => Convert.ToString(Area());


		public override string ToString() => $"Triángulo:\nColor - {GetColor()}\nBase - {GetBase()}\nAltura - {GetHeight()}\nÁrea - {GetArea()}\n\n";

	}
}
