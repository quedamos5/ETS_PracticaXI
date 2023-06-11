namespace expendedora
{
    internal class Funciones
    {
        public static int Menu(string titular, List<string> casos, bool AnyKeyAsExit = true, bool limpiarPrevio = true)
        {
            if (casos.Count > 9)
                throw new OverflowException();
            else
            {
                char caso;
                if (limpiarPrevio)
                    Console.Clear();
                Console.Write(titular);
                for (int i = 0; i < casos.Count; i++)
                    if (casos[i] != "")
                        Console.Write($"\n\t{i + 1}.- {casos[i]}");
                Console.Write($"\n\n\t0.- Salir\n\n\tOpción: ");
                do
                {
                    caso = Console.ReadKey().KeyChar;
                } while (!char.IsDigit(caso) && !AnyKeyAsExit);
                return caso > 97 ? caso : caso < 97 ? caso - 48 : caso - 96;
            }
        }

        public static int MenuLargo(string titular, List<string> casos, string msgSalida = "Salir", string eleccion = "Opción: ", bool limpiarPrevio = true)
        {
            if (limpiarPrevio)
                Console.Clear();
            Console.Write(titular);
            for (int i = 0; i < casos.Count; i++)
                if (casos[i] != "")
                    Console.Write($"\n\t{i + 1}.- {casos[i]}");
            Console.Write($"\n\n\t0.- {msgSalida}\n\n\t");
            return LeerEntero(eleccion, limInf: 0, limSup: casos.Count);
        }

        public static void Continuar(string msg, bool parada = true, bool limpiarPrevio = false)
        {
            if (limpiarPrevio)
                Console.Clear();
            Console.Write(msg);
            if (parada)
            {
                Console.Write("\n\n\tPulse una tecla para continuar... ");
                Console.ReadKey();
            }
        }

        public static int LeerEntero(string msg = "", bool borrarPrevio = false, bool borrarLuego = false, int? limInf = null, int? limSup = null)
        {
            bool inicio = false;
            int? num = null;
            do
            {
                if (borrarPrevio)
                    Console.Clear();
                if (inicio)
                {
                    if (num is null)
                        Console.Write($"\tDebes introducir un número.\n\n\t");
                    else if (limInf is not null && num < limInf)
                        Console.Write($"\tEl número no puede ser menor a {limInf}\n\n\t");
                    else if (limSup is not null && num > limSup)
                        Console.Write($"\tEl número no puede ser mayor a {limSup}\n\n\t");
                }
                else
                    inicio = true;
                Console.Write(msg);
                num = IntTryParseNullable(Console.ReadLine() ?? "");
            } while (num is null || (limInf is not null && num < limInf) || (limSup is not null && num > limSup));
            if (borrarLuego)
                Console.Clear();
            return (int)num;
        }

        public static int? IntTryParseNullable(string val) => int.TryParse(val, out int outValue) ? outValue : null;

        public static decimal LeerDecimal(string msg = "", bool borrarPrevio = false, bool borrarLuego = false, decimal? limInf = null, decimal? limSup = null)
        {
            bool inicio = false;
            decimal? num = null;
            do
            {
                if (borrarPrevio)
                    Console.Clear();
                if (inicio)
                {
                    if (num is not null)
                        if (limInf is not null && num < limInf)
                            Console.Write($"\tEl número no puede ser menor a {limInf}\n");
                        else if (limSup is not null && num > limSup)
                            Console.Write($"\tEl número no puede ser mayor a {limSup}\n");
                }
                else
                    inicio = true;
                if (msg != "")
                    Console.Write(msg);
                string temp = Console.ReadLine() ?? "";
                if (temp != "")
                    num = DecimalTryParseNullable(temp.Replace('.', ','));
            } while (num is null || (limInf is not null && num < limInf) || (limSup is not null && num > limSup));
            if (borrarLuego)
                Console.Clear();
            return (decimal)num;
        }
        public static decimal? DecimalTryParseNullable(string val) => decimal.TryParse(val, out decimal outValue) ? outValue : null;

        public static string LeerCadena(string msg = "", bool limpiarPrevio = false, bool limpiarLuego = false, int minLength = 0, int maxLength = 0,
            List<string> OracionesProhibidas = null, List<string> palabrasProhibidas = null, List<string> cadenasPermitidas = null)
        {
            if (limpiarPrevio)
                Console.Clear();
            if (msg != "")
                Console.Write(msg);
            string s;
            int salir = 0;
            do
            {
                if (salir == 1)
                    Console.Write($"Error, oración prohibida\n\n\t{msg}");
                else if (salir == 2)
                    Console.Write($"Error, palabra prohibida\n\n\t{msg}");
                else if (salir == 3)
                    Console.Write($"Error, esa cadena no está en la lista de las permitidas. Las cadenas permitidas son las siguientes:" +
                        $"\n\n\t{string.Join(", ", cadenasPermitidas)}\n\n\t{msg}");
                else if (salir == 4)
                    Console.Write($"Error, cadena demasiado corta. El mínimo es: {minLength}\n\n\t{msg}");
                else if (salir == 5)
                    Console.Write($"Error, cadena demasiado larga. El máximo es: {maxLength}\n\n\t{msg}");
                salir = 0;
                s = Console.ReadLine() ?? "";
                if (OracionesProhibidas is not null && OracionesProhibidas.Any(o => o == s))
                    salir = 1;
                else if (palabrasProhibidas is not null && palabrasProhibidas.Contains(s))
                    salir = 2;
                else if (cadenasPermitidas is not null && !cadenasPermitidas.Contains(s))
                    salir = 3;
                else if (s.Length < minLength)
                    salir = 4;
                else if (maxLength != 0 && s.Length > maxLength)
                    salir = 5;
            } while (salir != 0);
            if (limpiarLuego)
                Console.Clear();
            return s;
        }

        public static char LeerCaracter(string msg = "", char[] permitidos = null, char[] prohibidos = null, bool limpiarPrevio = false, bool limpiarLuego = false)
        {
            char caracter;
            do
            {
                if (limpiarPrevio)
                    Console.Clear();
                if (msg != "")
                    Console.Write(msg);
                caracter = Console.ReadKey().KeyChar;
            } while ((permitidos is not null && !permitidos.Contains(caracter)) || (prohibidos is not null && prohibidos.Contains(caracter)));
            if (limpiarLuego)
                Console.Clear();
            return caracter;
        }
    }
}
