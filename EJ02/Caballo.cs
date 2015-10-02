using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    /// <summary>
    /// Representa un caballo. Es una subclase de la clase Animal
    /// </summary>
    class Caballo : Animal
    {
        /// <summary>
        /// Representa la accion de emitir ruido de un caballo, sobreescribiendo el metodo de la clase Animal
        /// </summary>
        public override void HacerRuido()
        {
            Console.WriteLine("Hiiii Hiiii"); //segun http://etimologias.dechile.net/?onomatopeya
        }
    }
}
