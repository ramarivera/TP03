using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    /// <summary>
    /// Representa un cerdo. Es una subclase de la clase Animal
    /// </summary>
    class Cerdo : Animal
    {
        /// <summary>
        /// Representa la accion de emitir ruido de un cerdo, sobreescribiendo el metodo de la clase Animal
        /// </summary>
        public override void HacerRuido()
        {
            Console.WriteLine("Oik Oik"); ;
        }
    }
}
