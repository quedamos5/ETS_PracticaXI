using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
	internal class Ejercicio1_Apartado1
	{
		public static int Menu()
		{
			int option;
			Console.WriteLine($"\n\n\tSeleccione una opcion:\n\t1: Hacer pedido.\n\t" +
				$"2: Esperar a que acaben pedidos\n\t3: Esperar al cierre y ver la" +
				$" caja que han hecho por curiosidad\n\t");
			option = ReadInt("Seleccione una opción: ", 1, 3);
			return option;
		}

		public static int ReadInt(string msg, int? min = null, int? max = null)
		{
			int num;

			do
				Console.Write(msg);
			while (!Int32.TryParse(Console.ReadLine(), out num) || num < min || num > max);
			return num;
		}
	}
}
