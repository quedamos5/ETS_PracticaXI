namespace expendedora
{
    internal class Moneda
    {
        public decimal Valor { get; }
        public string Nombre { get; }

        static List<decimal> ValoresPosibles { get; } = new List<decimal>() { 2, 1, 0.5m, 0.2m, 0.1m, 0.05m, 0.02m, 0.01m };

        public Moneda(decimal valor)
        {
            if (ValoresPosibles.Any( v => v == valor))
            {
                Nombre = valor == 2 ? "Euros" : valor == 1 ? "Euro" : valor > 0.01m ? "Centimos" : "Centimo";
                Valor = valor;
            }
            else
                throw new Exception("Error de acuñado.");
        }

        public override string ToString() => $"{Valor} {Nombre}";

        public static List<Moneda> ToMoneda(decimal cantidad)
        {
            List<Moneda> monedas = new();
            ValoresPosibles.ForEach(v => 
            {
                while (cantidad >= v)
                {
                    cantidad -= v;
                    monedas.Add(new(v));
                }
            });
            return monedas;
        }
    }
}
