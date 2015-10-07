using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EJ04;

namespace EJ05
{
    class Facade
    {
        /// <summary>
        /// Permite seleccionar el metodo de encriptacion que se desea utilizar
        /// </summary>
        /// <param name="metodo">Nombre del metodo que se desea utilizar</param>
        /// <returns>Instancia del metodo de encriptacion</returns>
        public IEncriptador SeleccionarEncriptador(string metodo)
        {
            return (FabricaEncriptadores.Instancia.GetEncriptador(metodo));
        }

        /// <summary>
        /// Permite obtener los nombres de los distitnos metodos de encriptacion
        /// </summary>
        /// <returns>Una lista con los nombres de los metodos de encriptacion</returns>
        public List<string> ObtenerNombresEncriptadores()
        {
            List<string> lLista = new List<string>();
            lLista.AddRange(new string[] { "Cesar", "AES", "Null", "Enigma"});
            return lLista;
        }
    }
}
