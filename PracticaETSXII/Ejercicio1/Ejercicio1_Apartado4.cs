using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ejercicio1
{
	internal class Ejercicio1_Apartado4
	{
		// Encabezado de la cola
		private Node head;

		// Variables de referencia para trabajar con la cola
		private Node work, work2;

		// Constructor
		public Queue()
		{
			// Instanciamos la cabeza;
			head = new Node();
			// Cola vacia
			head.Next = null;
		}

		// Introducir nodos a la cola
		public void Push(Order data)
		{
			Node temp = new Node();
			temp.Data = data;

			temp.Next = head.Next;
			head.Next = temp;

		}

		// Eliminar nodos de la cola
		public Order Pop()
		{
			Order dato;
			work = head;
			work2 = work.Next;
			while (work2.Next != null)
			{
				work = work2;
				work2 = work.Next;
			}
			dato = work2.Data;
			work.Next = work2.Next;

			return dato;
		}

		public int Size()
		{
			int size = 0;
			work = head;
			while (work.Next != null)
			{
				work = work.Next;
				size++;
			}
			return size;
		}

		public bool IsEmpty() => head.Next == null;
	}
}
