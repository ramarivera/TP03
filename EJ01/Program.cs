using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace EJ01
{
	class Program
	{
		static void Main(string[] args)
		{
			Animal[] iAnimales = new Animal[2];
			Veterinaria iVeterinaria = new Veterinaria();

			Gato iGato = new Gato();
			Perro iPerro = new Perro();
			

			iAnimales[0] = iGato;
			iAnimales[1] = iPerro;

			iVeterinaria.AceptarAnimales(iAnimales);
			Console.ReadKey();

	
		}
	}
}
