using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using EJ04;


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

            IEncriptador encriptador = null;
            string texto = null;
            string encriptado = null;
            bool seguir = true;
            while (seguir)
            {
                SeparadorMenuPrincipal();
                Console.WriteLine("¿Que operacion desea realizar?");
                Console.WriteLine("1:\t Ingresar texto a encriptar");
                Console.WriteLine("2:\t Mostrar texto a encriptar");
                Console.WriteLine("3:\t Elegir metodo para encriptar");
                Console.WriteLine("4:\t Encriptar texto");
                Console.WriteLine("5:\t Mostrar texto encriptado");
                Console.WriteLine("6:\t Guardar texto encriptado");
                Console.WriteLine("7:\t Descencriptar");
                Console.WriteLine("0:\t Salir");
                Console.Write("Opcion elegida: ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        if (texto == null)
                        {
                            SeparadorOperatoria();
                            Console.Write("Ingrese el texto que desea encriptar ");
                            texto = Console.ReadLine();
                            Console.WriteLine("Texto cargado correctamente");
                            Console.ReadKey();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Ya existe un texto cargado para su encriptacion. Si desea cargar otro reinicie el programa");
                            Console.ReadKey();
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        if (texto != null)
                        {
                            SeparadorOperatoria();
                            Console.WriteLine("El texto guardado es: {0}", texto);
                        }
                        else
                        {
                            Console.WriteLine("No hay texto cargado");
                        }
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 3:
                        SeparadorOperatoria();
                        Console.WriteLine("Ingrese el numero del metodo que quiere utilizar ");
                        List<string> nombres = cFachada.ObtenerNombresEncriptadores();
                        for (int i = 0; i < nombres.Count; i++)
                        {
                            Console.WriteLine("\t {0}: {1}", i, (nombres.ElementAt(i)));
                        }
                        Console.Write("\nOpcion ingresada: ");
                        encriptador = cFachada.SeleccionarEncriptador(nombres.ElementAt(int.Parse(Console.ReadLine())));
                        Console.WriteLine("Encriptador seleccionado correctamente");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 4:
                        if (encriptador != null)
                        {
                            encriptado = encriptador.Encriptar(texto);
                            Console.WriteLine("Texto encriptado correctamente");
                        }
                        else
                        {
                            Console.WriteLine("Elija un metodo para encriptar");
                        }
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 5:
                        if (encriptado != null)
                        {
                            Console.WriteLine("El texto encriptado es: {0}", encriptado);
                        }
                        else
                        {
                            Console.WriteLine("No hay texto encriptado");
                        }
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 6:
                        if (encriptado != null)
                        {
                            texto = encriptado;
                            Console.WriteLine("Texto guardado correctamente");
                        }
                        else
                        {
                            Console.WriteLine("No hay texto encriptado");
                        }
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 7:
                        if (encriptado != null)
                        {
                            texto = encriptador.Desencriptar(texto);
                            Console.WriteLine("El texto obtenido es: {0}", texto);
                        }
                        else
                        {
                            Console.WriteLine("No hay texto encriptado");
                        }
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case 0:
                        seguir = false;
                        break;
                    default:
                        Console.Write("Opcion incorrecta. Reintente\n");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                }
            }
            GoodBye();
        }
    }
}
