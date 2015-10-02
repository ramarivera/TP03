using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
	class EncriptadorCesar : Encriptador
	{
		private int iDesplazamiento;

		private int Desplazamiento
		{
			get { return this.iDesplazamiento; }
			set { this.iDesplazamiento = value; }
		}

		public EncriptadorCesar(int pDesplazamiento) : base("Encriptador Cesar")
		{
			this.iDesplazamiento = pDesplazamiento;
		}

		public override string Encriptar(string pCadena)
		{
			/* for (int i = 0; i < pCadena.Length; i++)
			 {
				 int aux = (Convert.ToInt32(pCadena[i])) + this.iDesplazamiento;
				 char aux1 = (Convert.ToChar(aux));
				 string nuevaCadena.Concat;
			 }*/
			string lCadena = "hola"; ;
			return lCadena;
		}

		public override string Desencriptar(string pCadena)
		{
			string lCadena = "hola"; ;
			return lCadena;
		}
	}
}
