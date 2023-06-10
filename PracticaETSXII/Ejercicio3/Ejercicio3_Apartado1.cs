using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
	internal class Functions
	{

		public static int Menu()
		{
			int option;
			Console.WriteLine($"\n\n\tSeleccione una opcion:\n\t1: Crear Círculo.\n\t" +
				$"2: Crear Triángulo\n\t3: Crear Rectángulo\n\t" +
				$"4: Mostrar formas\n\t0: Salir");
			option = ReadInt("Seleccione una opción: ", 0, 4);
			return option;
		}

		public static string ReadString(string msg, int? min = null, int? max = null)
		{
			string text;
			do
			{
				Console.WriteLine(msg);
				text = Console.ReadLine() ?? "";

			} while (text.Trim() == "");
			return text;
		}

		public static int ReadInt(string msg, int? min = null, int? max = null)
		{
			int num;

			do
				Console.WriteLine(msg);
			while (!Int32.TryParse(Console.ReadLine(), out num) || num < min || num > max);
			return num;
		}

		public static double ReadDouble(string msg, int? min = null, int? max = null)
		{
			double num;

			do
				Console.WriteLine(msg);
			while (!Double.TryParse(Console.ReadLine(), out num) || num < min || num > max);
			return num;
		}
	}
}
