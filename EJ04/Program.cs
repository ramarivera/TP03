using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    class Program
    {
        static void Main(string[] args)
        {
            EncriptadorCesar cesar = new EncriptadorCesar(28);
            string cadena = Console.ReadLine();
            cadena = cesar.Encriptar(cadena);
            Console.WriteLine(cadena);
            Console.ReadKey();
            Console.WriteLine(cesar.Desencriptar(cadena));
            Console.ReadKey();
        }
    }
}
