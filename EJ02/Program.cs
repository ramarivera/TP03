using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EJ01;

namespace EJ02
{
    /// <summary>
    /// Clase Solucion del ejercicio 02 del Trabajo Practico 03
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int tamaño = 5;
            Veterinaria veterinaria = new Veterinaria();
            Animal[] pAnimales = new Animal[tamaño];
            pAnimales[0] = new Gato();
            pAnimales[1] = new Perro();
            pAnimales[2] = new Cerdo();
            pAnimales[3] = new Caballo();
            pAnimales[4] = new Gallo();

            veterinaria.AceptarAnimales(pAnimales);
            Console.ReadKey();
        }
    }
}
