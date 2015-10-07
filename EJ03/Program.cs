using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
	/// <summary>
	/// Clase Solucion del Ejercicio 03 del Trabajo Practico 03
	/// </summary>
	class Program
	{
		/// <summary>
		/// Miembro estatico Facade, utilizado para abstraer implementaciones de las clases particulares al ejercicio
		/// </summary>
		static Facade cFachada;

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
			GestorPrestamos gestor = cFachada.CrearGestor();
			string nombre, apellido;
			DateTime fecha;
			int tipo, cuotas;
			Empleo empleo = null;
			Cliente cliente=null;
            SolicitudPrestamo solicitud;
			double sueldo,monto;
			bool seguir = true;
			while (seguir)
			{
				SeparadorMenuPrincipal();
				Console.WriteLine("¿Que operacion desea realizar?");
				Console.WriteLine("1:\t Agregar un empleo");
				Console.WriteLine("2:\t Agregar un cliente");
				Console.WriteLine("3:\t Agregar una solicitud de prestamo");
				Console.WriteLine("0:\t Salir");
				Console.Write("Opcion elegida: ");
				switch (int.Parse(Console.ReadLine()))
				{
					case 1:
						if (empleo == null)
						{
							SeparadorOperatoria();
							Console.WriteLine("Ingrese los datos del nuevo empleo");
							Console.Write("\t Sueldo: ");
							sueldo = double.Parse(Console.ReadLine());
							Console.Write("\t Fecha de ingreso, en formato AAAA-MM-DD: ");
							fecha = DateTime.Parse(Console.ReadLine());
							empleo = cFachada.CrearEmpleo(sueldo, fecha);
							Console.WriteLine("Empleo cargado correctamente");
							Console.ReadKey();
							Console.WriteLine();
						}
						else
						{
							Console.WriteLine("Ya existe un empleo cargado");
							Console.ReadKey();
							Console.WriteLine();
						}
						break;
					case 2:
						if (empleo != null)
						{
							SeparadorOperatoria();
							Console.WriteLine("Ingrese los datos del nuevo cliente");
							Console.Write("\t Nombre: ");
							nombre = Console.ReadLine();
							Console.Write("\t Apellido: ");
							apellido = Console.ReadLine();
							Console.Write("\t Fecha de nacimiento, en formato AAAA-MM-DD: ");
							fecha = DateTime.Parse(Console.ReadLine());
							Console.WriteLine("\t Numero de tipo de Cliente: ");
							for (int i = 0; i < Enum.GetNames(typeof(TipoCliente)).Length; i++)
							{
								Console.WriteLine("\t {0}: {1}", i, (TipoCliente)i);
							}
							tipo = int.Parse(Console.ReadLine());
							cliente = cFachada.CrearCliente(nombre, apellido, fecha, empleo, (TipoCliente)tipo);
							Console.WriteLine("Cliente cargado correctamente");
						}
						else
						{
							Console.WriteLine("No hay un empleo cargado para el nuevo cliente. Cargue un empleo");			
						}
                        Console.ReadKey();
						Console.WriteLine();
                        break;
					case 3:
						SeparadorOperatoria();
						Console.WriteLine("Ingrese los datos de la nueva solicitud de prestamo");
						Console.Write("\t Monto del prestamo: ");
						monto = double.Parse(Console.ReadLine());
                        Console.Write("\t Cantidad de cuotas ");
                        cuotas = int.Parse(Console.ReadLine());
                        solicitud = cFachada.CrearSolicitudPrestamo(cliente,monto,cuotas);
                        if (cFachada.ValidarSolicitud(gestor,solicitud))
                        {
                            Console.WriteLine("La solicitud agregada es válida");
                        }
                        else
                        {
                            Console.WriteLine("La solicitud agregada no es válida");
                            Console.WriteLine("Su edad debe ser entre 18 y 75");
                            Console.WriteLine("Su antiguedad debe ser mayor a 6 meses");
                            Console.WriteLine("Su sueldo debe ser mayor a $5000");
                            Console.WriteLine("Verifique que el monto solicitado y la cantidad de cuotas se corresponda con su tipo de cliente");
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
