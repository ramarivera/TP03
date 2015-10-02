using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{   
    /// <summary>
    /// Representa un animal que puede ser atendido en la veterinaria
    /// </summary>
	abstract class  Animal
	{
        /// <summary>
        /// Representa la accion de correr de un animal
        /// </summary>
		void Correr()
		{
			Console.WriteLine("Corriendo");
		}

        /// <summary>
        /// Representa la accion de saltar de un animal
        /// </summary>
		void Saltar()
		{
			Console.WriteLine("Saltando");
		}

        /// <summary>
        /// Representa la accion de emitir sonido de un animal
        /// </summary>
		public abstract void HacerRuido();
	}
}
