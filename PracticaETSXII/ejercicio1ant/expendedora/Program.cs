using System.Text;

namespace expendedora
{
    internal class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Expendedora.GetInstance();
        }
    }
}