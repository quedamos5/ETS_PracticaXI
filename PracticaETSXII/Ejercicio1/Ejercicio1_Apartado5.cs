using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ejercicio1
{
	internal class Ejercicio1_Apartado5
	{
		// Dato que guarda el nodo
		private Order data;

		// Variable de referencia para apuntar al siguiente nodo
		private Node next = null;

		// Propiedades
		public Order Data { get => data; set => data = value; }

		internal Node Next { get => next; set => next = value; }
	}
}
