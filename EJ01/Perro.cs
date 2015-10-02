using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ01
{
    /// <summary>
    /// Representa un perro. Es una subclase de la clase Animal
    /// </summary>
	class Perro : Animal
	{
        /// <summary>
        /// Representa la accion de emitir ruido de un perro, sobreescribiendo el metodo de la clase Animal
        /// </summary>
		public override void HacerRuido()
		{
			Console.WriteLine("Guau Guau");
		}
	}
}
