using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    /// <summary>
    /// Clase necesaria para implementar el patron NullObject.
    /// Tanto La encriptacion como desencriptacion con este encriptador devuelven la misma cadena que se ingreso.
    /// </summary>
	internal class EncriptadorNulo : Encriptador
    {
		/// <summary>
		/// Inicializa una nueva instancia de <see cref="EncriptadorNulo"/>
		/// </summary>
		public EncriptadorNulo() : base("Null") { }
        /// <summary>
        /// Encripta una cadena de texto
        /// </summary>
        /// <param name="pCadena">Cadena a encriptar</param>
        /// <returns>Cadena encriptada</returns>
		public override string Encriptar(string pCadena)
		{
			return pCadena;
		}
        /// <summary>
        /// Desencripta una cadena de texto previamente encriptada por este encriptador
        /// </summary>
        /// <param name="pCadena">Cadena a desencriptar</param>
        /// <returns>Cadena desencriptada</returns>
		public override string Desencriptar(string pCadena)
		{
			return pCadena;
		}
	}
}
