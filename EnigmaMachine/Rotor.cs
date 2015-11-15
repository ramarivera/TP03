using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachine
{
	/// <summary>
	/// Representa un rotor de la Maquina Enigma. El mismo transforma siempre una letra, y rota su cifrado cada vez que se pasa una letra
	/// </summary>
	internal class Rotor
	{
		/// <summary>
		/// Representa las bases de los rotores
		/// </summary>
		private static readonly string[] BASE_CIPHER = { "PLFTDXSGJNEZOHCKUWYIMRABQV", "CKUWYIMRABQVPLFTDXSGJNEZOH" , "QVPLFTDXSGJNCKUWYIMRABEZOH" };
		
		/// <summary>
		///  Representa las muescas de cada rotor
		/// </summary>
		private static readonly char[] BASE_MUESCA = { 'G', 'R' , 'A' };
		
		/// <summary>
		/// Representa el estado inicial de los anillos
		/// </summary>
		private static readonly string BASE_ANILLO = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	
		/// <summary>
		/// Representa la muesca del rotor, en la cual al girar luego de ella, debe hacer girar los rotores adyacentes
		/// </summary>
		private char iMuesca;
		
		/// <summary>
		/// Representa la configuracion actual del anillo externo de cada rotor
		/// </summary>
		private StringBuilder iAnillo;
		
		/// <summary>
		/// Representa la configuracion del anillo interno de cada rotor
		/// </summary>
		private StringBuilder iCipher;

		/// <summary>
		/// Inicializa una nueva instancia de la Clase <see cref="Rotor"/>
		/// </summary>
		/// <param name="pNum">Numero de rotor a instanciar</param>
		public Rotor(int pNum)
		{
			Anillo = new StringBuilder(Rotor.BASE_ANILLO);
			Muesca = Rotor.BASE_MUESCA[pNum - 1];
			Cipher = new StringBuilder(Rotor.BASE_CIPHER[pNum - 1]);
		}

		/// <summary>
		/// Propiedad Muesca, Privada
		/// </summary>
		private char Muesca
		{
			get { return this.iMuesca; }
			set { this.iMuesca = value; }
		}
	
		/// <summary>
		/// Propiedad Anillo, Solo Lectura
		/// </summary>
		public StringBuilder Anillo
		{
			get { return this.iAnillo; }
			private set { this.iAnillo = value; }
		}
		
		/// <summary>
		/// Propiedad Cipher, Solo Lectura
		/// </summary>
		public StringBuilder Cipher
		{
			get { return this.iCipher; }
			private set { this.iCipher = value; }
		}
		/// <summary>
        /// Propiedad PosicionActual, Solo Lectura, Permite conocer la posicion actual del anillo del rotor
        /// </summary>
        public char PosicionActual
        {
            get { return Anillo[0]; }
        }

		/// <summary>
		/// Configuro el anillo en una posicion inicial
		/// </summary>
		/// <param name="pPosicionInicial">posicion inicial del anillo</param>
		public void Configurar (char pPosicionInicial)
		{
			string lAnillo = Anillo.ToString();
            int lPos = lAnillo.IndexOf(pPosicionInicial);
			if (lPos != 0)
			{
				Anillo.Clear();
				Anillo.Append(lAnillo.Substring(lPos, (lAnillo.Length)-lPos));
				Anillo.Append(lAnillo.Substring(0, lPos));
			}
        }
		
		/// <summary>
		/// Modela el giro de los rotores, el cual se produce al alcanzar la muesca
		/// </summary>
		/// <returns></returns>
		public bool Girar () 
		{
			char lActual = Anillo[0];
			Anillo.Insert(Anillo.Length - 1, Anillo[0]);				// Inserto el primer caracter en el final del anillo
			Anillo.Remove(0, 1);										// Elimino el primer caracter, caso contrario queda duplicado
			return (lActual == Muesca);									// Si el caracter donde estaba antes de girar es la Muesca, entonces deberan girar los rotores adyacentes
		}
		
		/// <summary>
		/// Nos devuelve la posicion de una letra en uno de los anillos, internos o externo
		/// </summary>
		/// <param name="pLetra">Letra cuya posicion deseo conocer</param>
		/// <param name="pCadena">Anillo en el cual deseo conocer la ubicacion de la letra (Anillo o Cipher)</param>
		/// <returns></returns>
		public int PosicionLetra (char pLetra, StringBuilder pCadena)
		{
			return pCadena.ToString().IndexOf(pLetra);
		}

		/// <summary>
		/// Cifra una letra a traves del rotor
		/// </summary>
		/// <param name="pDerecha">Verdadero su debo cifrar hacia la derecha, falso si debo girar hacia la izquierda</param>
		/// <param name="pLetra">Letra a Cifrar</param>
		/// <returns>Letra cifrada</returns>
		public char Cifrar (bool pDerecha, char pLetra)
		{
			return (pDerecha) ? CifrarHaciaDerecha(pLetra) : CifrarHaciaIzquierda(pLetra);
		}

		/// <summary>
		/// Realiza el cifrado hacia la Derecha, pasando la entrada por el Anillo hacia el Cipher
		/// </summary>
		/// <param name="pLetra">Letra a Cifrar</param>
		/// <returns>Letra Cifrada</returns>
		public char CifrarHaciaDerecha (char pLetra)
		{
			return Cipher[PosicionLetra(pLetra, Anillo)];
		}

		/// <summary>
		/// Realiza el cifrado hacia la izquierda, pasando la entrada por el Cipher hacia el Anillo
		/// </summary>
		/// <param name="pLetra">Letra a Cifrar</param>
		/// <returns>Letra Cifrada</returns>
		public char CifrarHaciaIzquierda(char pLetra)
		{ 
			return Anillo[PosicionLetra(pLetra, Cipher)];
		}
	}
}
