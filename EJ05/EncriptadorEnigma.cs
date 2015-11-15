using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnigmaMachine;
using EJ04;

namespace EJ05
{
	/// <summary>
	/// Representa un Encriptador que utiliza el Algoritmo de la Maquina Enigma M3.
	/// Modificada para permitir trabajar con Caracteres AlfaNumericos y espacios.
	/// </summary>
	class EncriptadorEnigma : Encriptador
	{
		/// <summary>
		/// Representa el Motor de la maquina enigma utilizado para encriptar y desencriptar
		/// </summary>
		private EnigmaEngine MaquinaEnigma { get; set; }
		/// <summary>
		/// Almacena los rotores seleccionados en la configuracion inicial
		/// </summary>
		private int[] Rotores { get; set; }
		/// <summary>
		/// Almacena la posicion inicial de los anillos seleccionados en la configuracion inicial
		/// </summary>
		private char[] Anillos { get; set; }
		/// <summary>
		/// Almacena la configuracion del tablero de conexiones seleccionados en la configuracion inicial
		/// </summary>
		private string Conexiones { get; set; }
		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="EncriptadorEnigma"/>
		/// </summary>
		public EncriptadorEnigma() : base("EncriptadorEnigma")
		{
			MaquinaEnigma = new EnigmaEngine();
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="EncriptadorEnigma"/>
		/// </summary>
		/// <param name="pRotores">Rotores a utilizar</param>
		/// <param name="pAnillos">Posicion inicial de los anillos</param>
		/// <param name="pConexiones">Configuracion del tablero de configuraciones</param>
		public EncriptadorEnigma(int[] pRotores, char[] pAnillos, string pConexiones) : this()
		{
			Rotores = pRotores;
			Anillos = pAnillos;
			Conexiones = pConexiones;
			MaquinaEnigma.Configurar(pRotores, pAnillos, pConexiones);
		}

		/// <summary>
		/// Reinicia la configuracion de la maquina, de manera de poder desencriptar las cadenas encriptadas
		/// </summary>
		private void Reiniciar()
		{
			MaquinaEnigma.Configurar(Rotores, Anillos, Conexiones);
		}

		/// <summary>
		/// Encripta una cadena de texto
		/// </summary>
		/// <param name="pCadena">Cadena a encriptar</param>
		/// <returns>Cadena encriptada</returns>
		public override string Encriptar(string pCadena)
		{
			string lResult = MaquinaEnigma.Encriptar(pCadena);
			Reiniciar();
			return lResult;
		}

		/// <summary>
		/// Desencripta una cadena de texto previamente encriptada por este encriptador
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
