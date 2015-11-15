using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    class Facade
    {
        /// <summary>
        /// Permite obtener los nombres de los distitnos metodos de encriptacion
        /// </summary>
        /// <returns>Una lista con los nombres de los metodos de encriptacion</returns>
        public List<string> ObtenerNombresEncriptadores()
        {
            return new List<string>(){ "Cesar", "AES", "Null"};
        }

        /// <summary>
        /// Encripta el texto ingresado segun el nombre del encriptador
        /// </summary>
        /// <param name="pNombreEncriptador">Nombre del encriptador a utilizar.</param>
        /// <param name="pTextoLLano">Texto a encriptar</param>
        /// <returns>Texto encriptado</returns>
        public string Encriptar(string pNombreEncriptador, string pTextoLLano)
        {
            IEncriptador lEncriptador = FabricaEncriptadores.Instancia.GetEncriptador(pNombreEncriptador);
            return lEncriptador.Encriptar(pTextoLLano);
        }

        /// <summary>
        /// Desencripta el texto ingresado segun el nombre del encriptador
        /// </summary>
        /// <param name="pNombreEncriptador">Nombre del encriptador a utilizar.</param>
        /// <param name="pTextoEncriptado">Texto a desencriptar</param>
        /// <returns>Texto desencriptado</returns>
        public string Desencriptar(string pNombreEncriptador, string pTextoEncriptado)
        {
            IEncriptador lEncriptador = FabricaEncriptadores.Instancia.GetEncriptador(pNombreEncriptador);
            return lEncriptador.Desencriptar(pTextoEncriptado);
        }
    }
}
