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
			string lNombre, lApellido;
			DateTime lFecha;
			int lCuotas;
			string lTipo;
			double lSueldo, lMonto;
			bool lSeguir = true;
			while (lSeguir)
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
						SeparadorOperatoria();
						Console.WriteLine("Ingrese los datos del nuevo empleo");
						Console.Write("\t Sueldo: ");
						lSueldo = double.Parse(Console.ReadLine());
						Console.Write("\t Fecha de ingreso, en formato AAAA-MM-DD: ");
						lFecha = DateTime.Parse(Console.ReadLine());
						cFachada.CargarEmpleo(lSueldo, lFecha);
						Console.WriteLine("Empleo cargado correctamente");
						Console.ReadKey();
						Console.WriteLine();
						break;
					case 2:
						SeparadorOperatoria();
						Console.WriteLine("Ingrese los datos del nuevo cliente");
						Console.Write("\t Nombre: ");
						lNombre = Console.ReadLine();
						Console.Write("\t Apellido: ");
						lApellido = Console.ReadLine();
						Console.Write("\t Fecha de nacimiento, en formato AAAA-MM-DD: ");
						lFecha = DateTime.Parse(Console.ReadLine());
						Console.WriteLine("\t Tipo de Cliente: ");
						List<String> lListaTipos = cFachada.ObtenerNombreCuentas();
						for (int i = 0; i < lListaTipos.Count; i++)
						{
							Console.WriteLine("\t\t {0}: {1}", i, lListaTipos[i]);
						}
						Console.WriteLine("\t Eleccion:");
						lTipo = lListaTipos[int.Parse(Console.ReadLine())];
						if (cFachada.CargarCliente(lNombre, lApellido, lFecha, lTipo))
						{
							Console.WriteLine("Cliente cargado correctamente");
						} 
						else
						{
							Console.WriteLine("El cliente no se pudo cargar, verifique que exista un empleo cargado");
						}

						break;
					case 3:
						SeparadorOperatoria();
						Console.WriteLine("Ingrese los datos de la nueva solicitud de prestamo");
						Console.Write("\t Monto del prestamo: ");
						lMonto = double.Parse(Console.ReadLine());
						Console.Write("\t Cantidad de cuotas ");
						lCuotas = int.Parse(Console.ReadLine());
						if (cFachada.ValidarSolicitudPrestamo(lMonto, lCuotas))
						{
							Console.WriteLine("La solicitud agregada es válida");
						}
						else
						{
							Console.WriteLine(  "La solicitud agregada no es válida\n" +
												"Su edad debe ser entre 18 y 75\n" + 
												"Su antiguedad debe ser mayor a 6 meses\n" +
												"Su sueldo debe ser mayor a $5000\n" +
												"Verifique que el monto solicitado y la cantidad de cuotas se corresponda con su tipo de cliente");
						}
						Console.ReadKey();
						Console.WriteLine();
						break;
					case 0:
						lSeguir = false;
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
