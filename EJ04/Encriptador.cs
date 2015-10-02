using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    /// <summary>
    /// 
    /// </summary>
    abstract class Encriptador: IEncriptador
    {
        /// <summary>
        /// Representa el Nombre del Encriptador
        /// </summary>
        private string iNombre;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pNombre"></param>
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
        /// 
        /// </summary>
        /// <param name="pCadena"></param>
        /// <returns></returns>
        public abstract string Encriptar(string pCadena);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCadena"></param>
        /// <returns></returns>
        public abstract string Desencriptar(string pCadena);
    }
}
