using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    /// <summary>
    /// Representa una veterinaria para la atencion de animales
    /// </summary>
	class Veterinaria
	{
        /// <summary>
        /// Acepta los animales en la veterinaria, haciendo que emitan su sonido
        /// </summary>
        /// <param name="pAnimales">Arreglo que contiene objetos de la clase Animal</param>
		public void AceptarAnimales(Animal[] pAnimales)
		{
			foreach (Animal iAnimal in pAnimales)
			{
				iAnimal.HacerRuido();
			}
		}
	}
}
