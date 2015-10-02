using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    /// <summary>
    /// Representa un gallo. Es una subclase de la clase Animal
    /// </summary>
    class Gallo : Animal
    {
        /// <summary>
        /// Representa la accion de emitir ruido de un gallo, sobreescribiendo el metodo de la clase Animal
        /// </summary>
        public override void HacerRuido()
        {
            Console.WriteLine("Coc coc coc") ;
        }
    }
}
