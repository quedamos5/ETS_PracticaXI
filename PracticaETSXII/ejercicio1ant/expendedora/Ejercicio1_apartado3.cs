using System.Collections.ObjectModel;

namespace expendedora
{
    internal class Expendedora
    {
        const int rows = 5, cols = 4, cellDepth = 10;
        static decimal precioMin, precioMax;
        static readonly List<Moneda> monedas = new();

        static ObservableCollection<Producto> Productos { get; } = new();

        readonly Dictionary<string, decimal> productosHC = new()
        {
            {"Coca cola", 1 }, { "Fanta", 0.9m }, { "Acuarius", 0.9m }, { "Acuarius Nar.", 0.9m }, { "Cliper", 1 },
            {"Cuña", 1 }, { "Herradura", 0.9m }, { "Herradura choco", 1 }, { "Palmera", 1 }, { "Palmera int.", 1.2m },
            {"Risquetos", 0.5m }, { "Rufles jamón", 0.69m }, { "Munchitos", 0.69m }, { "Munchitos ajo", 0.69m }, { "Pelotazos", 0.5m },
            {"Agua", 0.5m }, { "Zumo pera piña", 0.9m }, { "Zumo melocotón", 0.9m }, { "Zumo naranja", 0.9m }, { "Limonada", 1 }
        };

        private static readonly Expendedora _instance = new();

        public static Expendedora GetInstance() => _instance;

        private Expendedora()
        {
            for (int i = 0; i < 50; i++)
                monedas.Add(new(0.01m));
            for (int i = 0; i < 50; i++)
                monedas.Add(new(0.02m));
            for (int i = 0; i < 50; i++)
                monedas.Add(new(0.1m));
            for (int i = 0; i < 50; i++)
                monedas.Add(new(0.2m));
            for (int i = 0; i < 50; i++)
                monedas.Add(new(0.5m));
            for (int i = 0; i < 50; i++)
                monedas.Add(new(1));
            for (int i = 0; i < 50; i++)
                monedas.Add(new(2));
            RellenarStock();
            Init();
        }

        private void Init()
        {
            bool continuar = true;
            do
            {
                int opc = Funciones.Menu("\n\tElija una opción: ", new() { "Comprar", "Rellenar todo el Stock", "Añadir nuevo producto", "Eliminar existencias de un producto" });
                switch (opc)
                {
                    case 1:
                        Comprar();
                        break;
                    case 2:
                        RellenarStock();
                        break;
                    case 3:
                        AñadirNuevoProducto();
                        break;
                    case 4:
                        EliminarProducto();
                        break;
                    default:
                        continuar = false;
                        break;
                }
            } while (continuar);
        }

        static void Comprar() => MostrarOpciones(ProcesarMonedas());

        static decimal ProcesarMonedas()
        {
            decimal saldo = Funciones.LeerDecimal("\n\n\tIntroduce tu monedas: ", true, true, precioMin, precioMax);
            Moneda.ToMoneda(saldo).ForEach(m => monedas.Add(m));
            return saldo;
        }

        static void MostrarOpciones(decimal saldo)
        {
            int cont = 0;
            List<Producto> TempPs = Productos.Where(p => p.Precio <= saldo).ToList();
            TempPs.ForEach(p =>
            {
                if (cont == 0 || cont % cols == 0)
                    Console.Write("\n");
                if (p.Cantidad > 0)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                string text = p.ToString();
                Console.Write($"{string.Format("{0:00}", ++cont)}. {text.ToUpper(),-20}");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("\t");
            });
            Console.ForegroundColor = ConsoleColor.White;

            Cobrar(TempPs, saldo);
        }

        static void Cobrar(List<Producto> ps, decimal saldo)
        {
            int index = Funciones.LeerEntero("\n\n\t0- Cancelar\n\n\tOpción: ", limInf: 0, limSup: ps.Count) - 1;
            if (index == -1)
            {
                Devolver(saldo);
                Funciones.Continuar($"\n\tVenta cancelada.");
            }
            else if (ps[index].Cantidad > 0)
            {
                ps[index].Cantidad--;
                Devolver(saldo - ps[index].Precio);
                Funciones.Continuar($"\n\tDisfrute de su {ps[index].Nombre}");
            }
            else
                Funciones.Continuar($"\n\tProducto agotado.");
        }

        static void Devolver(decimal dinero)
        {
            List<Moneda> vuelta = new();
            List<Moneda> monedasOrdenadas = new() { new(0.5m), new(0.2m), new(0.1m), new(0.05m), new(0.02m), new(0.01m), new(1), new(2) };
            foreach (Moneda m in monedasOrdenadas)
                while (dinero >= m.Valor && monedas.Any(mo => mo.Valor == m.Valor))
                {
                    dinero -= m.Valor;
                    vuelta.Add(new(m.Valor));
                    monedas.RemoveAt(monedas.FindIndex(mo => mo.Valor == m.Valor));
                }
            Console.Clear();
            Console.WriteLine($"\n\n{(dinero > 0 ? "Monedas insuficientes - " : "")} Vuelta {vuelta.Sum(m => m.Valor)}€ - Monedas:\n");
            foreach (Moneda m in vuelta)
                Console.WriteLine($"\t{m}");
        }

        void RellenarStock()
        {
            Productos.CollectionChanged -= Productos_CollectionChanged;
            if (Productos.Count > 0)
            {
                foreach (Producto p in Productos)
                    p.Cantidad = cellDepth;
                Funciones.Continuar("\n\n\tStock rellenado!", limpiarPrevio: true);
            }
            else
                foreach (var p in productosHC)
                    Productos.Add(new Producto(p.Key, p.Value, cellDepth));
            Productos.CollectionChanged += Productos_CollectionChanged;
            Productos_CollectionChanged(null, null);
        }

        static void AñadirNuevoProducto()
        {
            if (Productos.Count < rows * cols)
            {
                string nombre = Funciones.LeerCadena("\n\n\tNombre del producto: ", true, true, minLength: 3, palabrasProhibidas: Productos.Select(p => p.Nombre).ToList());
                decimal precio = Funciones.LeerDecimal($"\n\n\tPrecio de {nombre}: ", true, true, 0, 01);
                int cantidad = Funciones.LeerEntero($"\n\n\tCantidad de {nombre}: ", true, true, 1, cellDepth);
                Productos.Add(new(nombre, precio, cantidad));
            }
            else
                Funciones.Continuar("\n\n\tNo hay espacio para nuevos productos.", true, true);
        }

        static void EliminarProducto()
        {
            int opc = Funciones.MenuLargo("\n\n\tQue producto desea eliminar: ", Productos.Select(p => p.Nombre).ToList(), "Cancelar: ");
            if (opc != 0)
                Productos.RemoveAt(opc - 1);
        }

        static void Productos_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Productos is not null && Productos.Count > 0)
            {
                precioMin = Productos.Select(p => p.Precio).Min();
                precioMax = Math.Ceiling(Productos.Select(p => p.Precio).Max());
            }
        }
    }
}