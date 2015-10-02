using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnigmaMachine;

namespace EJ04
{
	class EncriptadorEnigma : Encriptador
	{

		private EnigmaEngine iMaquinaEnigma;

		private EnigmaEngine MaquinaEnigma
		{
			get { return this.iMaquinaEnigma; }
			set { this.iMaquinaEnigma = value; }
		}

		public EncriptadorEnigma() : base("EncriptadorEnigma")
		{
			MaquinaEnigma = new EnigmaEngine();
		}

		public void Configurar(int[] pRotores, char[] pAnillos, string pConexiones)
		{
			MaquinaEnigma.Configurar(pRotores, pAnillos, pConexiones);
		}

		public void Configurar()
		{
			int[] pRotores = { 1, 2, 3 };
			char[] pAnillos = { 'A', 'A', 'A' };
			string pConexiones = "ADFTHUJIKOLP";
            MaquinaEnigma.Configurar(pRotores, pAnillos, pConexiones);
		}
		public override string Encriptar(string pCadena)
		{
			return MaquinaEnigma.Encriptar(pCadena);
		}

		public override string Desencriptar(string pCadena)
		{
			return MaquinaEnigma.Desencriptar(pCadena);
		}
	}
}
