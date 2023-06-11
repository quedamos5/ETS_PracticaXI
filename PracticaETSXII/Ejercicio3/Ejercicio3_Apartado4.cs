using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
	internal class Rectangle : Formas
	{
		private double Width { get; set; }
		private double Length { get; set; }

		public Rectangle(double Width, double Length, string Color) : base(Color)
		{
			this.Width = Width;
			this.Length = Length;
		}

		public double GetWidth() => Width;
		public double GetLength() => Length;

		public static Rectangle ReadRectangle()
		{
			string color = Functions.ReadString("Introduce el color del rectángulo", 3);
			double width = Functions.ReadDouble("Introduce el ancho (número positivo)", 0),
				   length = Functions.ReadDouble("Introduce el largo (número positivo)", 0);
			return new Rectangle(width, length, color);
		}
		public override double Area() => GetLength() * GetWidth();

		public string GetArea() => Convert.ToString(Area());

		public override string ToString() => $"Rectángulo:\nColor - {GetColor()}\nAncho - {GetWidth()}\nLargo - {GetWidth()}\nÁrea - {GetArea()}\n\n";
	}
}
