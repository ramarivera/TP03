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
        /// Abstrae la creacion de una buena fabrica de encriptadores
        /// </summary>
        /// <returns>Una instancia de FabricaEncriptadores</returns>
        public FabricaEncriptadores CrearFabrica()
        {
            return FabricaEncriptadores.Instancia;
        }

        /// <summary>
        /// Permite seleccionar el metodo de encriptacion que se desea utilizar
        /// </summary>
        /// <param name="metodo">Nombre del metodo que se desea utilizar</param>
        /// <returns>Instancia del metodo de encriptacion</returns>
        public IEncriptador SeleccionarEncriptador(string metodo)
        {
            return (FabricaEncriptadores.GetEncriptador(metodo));
        }

        /// <summary>
        /// Permite obtener los nombres de los distitnos metodos de encriptacion
        /// </summary>
        /// <returns>Una lista con los nombres de los metodos de encriptacion</returns>
        public List<string> ObtenerNombresEncriptadores()
        {
            return (FabricaEncriptadores.GetNombres());
        }
    }
}
