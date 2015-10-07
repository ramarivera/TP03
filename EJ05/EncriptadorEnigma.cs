using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnigmaMachine;
using EJ04;

namespace EJ05
{
    class EncriptadorEnigma : Encriptador
    {

        public EnigmaEngine MaquinaEnigma { get; set; }
        public int[] Rotores { get; set; }
        public char[] Anillos { get; set; }
        public string Conexiones { get; set; }
        public EncriptadorEnigma() : base("EncriptadorEnigma")
        {
            MaquinaEnigma = new EnigmaEngine();
        }


        public EncriptadorEnigma(int[] pRotores, char[] pAnillos, string pConexiones) : this()
        {
            Rotores = pRotores;
            Anillos = pAnillos;
            Conexiones = pConexiones;
            MaquinaEnigma.Configurar(pRotores, pAnillos, pConexiones);
        }


        private void Reiniciar()
        {
            MaquinaEnigma.Configurar(Rotores, Anillos, Conexiones);
        }

        /*
        private string RegenerarMinusculas(string pCadenaCifrada, string pCadenaOriginal)
        {
            StringBuilder lSbuilder = new StringBuilder();

            for (int i = 0; i < lResult.Length; i++)
            {
                lSbuilder.Append(char.IsUpper(pCadena[i]) ? lResult[i] : char.ToUpper(lResult[i]));
            }
        }*/

        /// <summary>
        /// Encripta una cadena mediante el método Enigma. Soporta solo las 26 letras del abecedario, en mayuscula o minuscula, y numeros
        /// </summary>
        /// <param name="pCadena">Cadena a desencriptar</param>
        /// <returns>Cadena desencriptada</returns>
        public override string Encriptar(string pCadena)
		{
            string lResult = MaquinaEnigma.Encriptar(pCadena);
            Reiniciar();
            return lResult;

		}

        /// <summary>
        /// Desencripta una cadena mediante el método Enigma. Soporta solo las 26 letras del abecedario, en mayuscula o minuscula, y numeros
        /// </summary>
        /// <param name="pCadena">Cadena a desencriptar</param>
        /// <returns>Cadena desencriptada</returns>
		public override string Desencriptar(string pCadena)
		{
            string lResult = MaquinaEnigma.Desencriptar(pCadena);
            Reiniciar();
            return lResult;
        }
	}
}
