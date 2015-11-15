using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using EJ04;
using System.Security.Cryptography;

namespace EJ05
{
    /// <summary>
    /// Clase Solucion del Ejercicio 04 del Trabajo Practico 03
    /// </summary>
    class Program
    {
        private static Facade cFachada;
        /// <summary>
        /// Muestra la Pantalla de Despedida del programa
        /// </summary>
        static void GoodBye()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n                    Thank you for trusting MARR Systems Inc.  ");
            Console.ReadKey();
        }
        /// <summary>
        /// Muestra una cadena de caracteres, utilizado como separador en los menues principales por consola
        /// </summary>
        static void SeparadorMenuPrincipal()
        {
            Console.WriteLine("\n************************** Menu Principal *************************\n");
        }

        /// <summary>
        /// Muestra una cadena de caracteres, utilizado como separador en los menues secundarios por consola
        /// </summary>
        static void SeparadorOperatoria()
        {
            Console.WriteLine("\n-------------------Operando------------------\n");
        }

        static void Main(string[] args)
        {
            cFachada = new Facade();
            string lTexto = null;
            string lEncriptado = null;
            string lEncriptador = null;
            bool lSeguir = true;

            while (lSeguir)
            {
                SeparadorMenuPrincipal();
                Console.WriteLine("¿Que operacion desea realizar?");
                Console.WriteLine("1:\t Ingresar texto a encriptar");
                Console.WriteLine("2:\t Mostrar texto a encriptar");
                Console.WriteLine("3:\t Elegir metodo para encriptar/desencriptar");
                Console.WriteLine("4:\t Encriptar texto");
                Console.WriteLine("5:\t Mostrar texto encriptado");
                Console.WriteLine("6:\t Guardar texto encriptado");
                Console.WriteLine("7:\t Descencriptar");
                Console.WriteLine("0:\t Salir");
                Console.Write("Opcion elegida: ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        if (lTexto == null)
                        {
                            SeparadorOperatoria();
                            Console.Write("Ingrese el texto que desea encriptar ");
                            lTexto = Console.ReadLine();
                            Console.Write("Texto cargado correctamente. ");
                        }
                        else
                        {
                            Console.Write("Ya existe un texto cargado para su encriptacion. Si desea cargar otro reinicie el programa. ");
                        }
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 2:
                        if (lTexto != null)
                        {
                            SeparadorOperatoria();
                            Console.Write("El texto guardado es: {0}. ", lTexto);
                        }
                        else
                        {
                            Console.Write("No hay texto cargado. ");
                        }
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 3:
                        SeparadorOperatoria();
                        Console.WriteLine("Ingrese el numero del metodo que quiere utilizar ");
                        List<string> lNombres = cFachada.ObtenerNombresEncriptadores();
                        for (int i = 0; i < lNombres.Count; i++)
                        {
                            Console.WriteLine("\t\t {0}: {1}", i, (lNombres[i]));
                        }
                        Console.Write("\t Opcion ingresada: ");
                        lEncriptador = lNombres[int.Parse(Console.ReadLine())];
                        Console.Write("Encriptador seleccionado correctamente. ");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 4:
                        if (lEncriptador != null)
                        {
                            lEncriptado = cFachada.Encriptar(lEncriptador, lTexto);
                            Console.Write("Texto encriptado correctamente. ");
                        }
                        else
                        {
                            Console.Write("Elija un metodo para encriptar. ");
                        }
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 5:
                        if (lEncriptado != null)
                        {
                            Console.WriteLine("El texto encriptado es: {0}. ", lEncriptado);
                        }
                        else
                        {
                            Console.WriteLine("No hay texto encriptado. ");
                        }
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 6:
                        if (lEncriptado != null)
                        {
                            lTexto = lEncriptado;
                            Console.WriteLine("Texto guardado correctamente. ");
                        }
                        else
                        {
                            Console.WriteLine("No hay texto encriptado. ");
                        }
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 7:
                        if (lEncriptador != null)
                        {
                            lTexto = cFachada.Desencriptar(lEncriptador, lTexto);
                            Console.WriteLine("El texto obtenido es: {0}. ", lTexto);
                        }
                        else
                        {
                            Console.WriteLine("No hay texto encriptado. ");
                        }
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 0:
                        lSeguir = false;
                        break;
                    default:
                        Console.Write("Opcion incorrecta. Reintente. ");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                }
            }
            GoodBye();
        }
    }
}
