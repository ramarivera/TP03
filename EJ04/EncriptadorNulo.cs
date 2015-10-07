using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
	internal class EncriptadorNulo : Encriptador
    {
		/// <summary>
		/// Inicializa una nueva instancia de <see cref="EncriptadorNulo"/>
		/// </summary>
		public EncriptadorNulo() : base("Nulo") { }

		public override string Encriptar(string pCadena)
		{
			return pCadena;
		}

		public override string Desencriptar(string pCadena)
		{
			return pCadena;
		}
	}
}
