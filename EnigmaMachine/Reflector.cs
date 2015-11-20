using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachine
{
	/// <summary>
	/// Representa el reflector de la Maquina Enigma. El mismo es similar en funcionamiento al Plugboard, solo que este siempre realiza una transformacion
	/// </summary>
	internal class Reflector
	{
		/// <summary>
		/// Base a usar para el reflector
		/// </summary>
		private static readonly string BASE_REFLECTOR = "PZOEJDHCGFUTXMALRBKYINSQVW";

		/// <summary>
		/// Configuracion actual
		/// </summary>
		private string iConfiguracion;

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="Reflector"/>
		/// </summary>
		public Reflector()
		{
			Configuracion = Reflector.BASE_REFLECTOR;
		}

		/// <summary>
		/// Propiedad Configuracion, Privada
		/// </summary>
		private string Configuracion
		{
			get { return this.iConfiguracion; }
			set { this.iConfiguracion = value; }
		}

		/// <summary>
		/// Refleja la letra ingresada
		/// </summary>
		/// <param name="pLetra">Letra a reflejar</param>
		/// <returns>La letra reflejada</returns>
		public char Reflejar(char pLetra)
		{
			int lPos = Configuracion.IndexOf(pLetra);
            return Configuracion[(lPos+13) % 26];
		}
	}
}
