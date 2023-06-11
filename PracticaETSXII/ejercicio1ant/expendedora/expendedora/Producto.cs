namespace expendedora
{
    internal class Producto
    {
        public int Cantidad { get; set; }
        public decimal Precio { get; }
        public string Nombre { get; }


        public Producto(string nombre, decimal precio, int cantidad)
        {
            if (nombre.Length >= 3 && precio > 0)
            {
                Nombre = nombre;
                Precio = precio;
                Cantidad = cantidad;
            }
            else
                throw new Exception("Los campos deben tener al menos tres letras.");
        }

        public int Count() => Cantidad;

        public override string ToString() => $"{Nombre} - {Precio}€";
    }
}
