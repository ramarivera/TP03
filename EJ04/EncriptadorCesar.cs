using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    class EncriptadorCesar: Encriptador
    {
        private int iDesplazamiento;

        public EncriptadorCesar(int pDesplazamiento)
        {
            this.iDesplazamiento = pDesplazamiento;
        }

        public override string Encriptar(string pCadena)
        {
            for (int i = 0; i < pCadena.Length; i++)
            {
                int aux = (Convert.ToInt32(pCadena[i])) + this.iDesplazamiento;
                char aux1 = (Convert.ToChar(aux));
                string nuevaCadena.Concat;
            }
        }

    }
}
