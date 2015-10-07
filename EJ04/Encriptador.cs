using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
	/// <summary>
	/// Representa la clase de la cual heredan todos los encriptadores.
	/// </summary>
	public abstract class Encriptador: IEncriptador
    {
        /// <summary>
        /// Representa el Nombre del Encriptador
        /// </summary>
        private string iNombre;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Encriptador"/>
        /// </summary>
        /// <param name="pNombre">Nombre del Encriptador</param>
        public Encriptador(string pNombre)
		{
			Nombre = pNombre;
		}

        /// <summary>
        /// Propiedad Nombre, solo lectura
        /// </summary>
        public string Nombre
        {
            get { return this.iNombre; }
            private set { this.iNombre = value; }
        }

        /// <summary>
        /// Encripta una cadena de texto
        /// </summary>
        /// <param name="pCadena">Cadena a encriptar</param>
        /// <returns>Cadena encriptada</returns>
        public abstract string Encriptar(string pCadena);

        /// <summary>
        /// Desencripta una cadena de texto previamente encriptada por este encriptador
        /// </summary>
        /// <param name="pCadena">Cadena a desencriptar</param>
        /// <returns>Cadena desencriptada</returns>
        public abstract string Desencriptar(string pCadena);
    }
}
