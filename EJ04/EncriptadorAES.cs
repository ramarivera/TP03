using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
	class EncriptadorAES : Encriptador
	{

		public EncriptadorAES() : base("EncriptadorAES") { }


		public override string Encriptar(string pCadena)
		{
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
