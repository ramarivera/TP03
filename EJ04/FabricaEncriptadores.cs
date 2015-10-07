using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    public class FabricaEncriptadores
    {
        private static FabricaEncriptadores cInstancia;
        private static Dictionary<string,IEncriptador> iEncriptadores;
        private static readonly int CESAR_DESP = 10;
        private static readonly string AES_SALT = "Rivera";
        private static readonly string AES_PASSWORD = "pFlEmEL5_¡4#pF";

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="FabricaEncriptadores"/>. Ademas inicializa los metodos de encriptacion y los coloca en el diccionario
        /// </summary>
        private FabricaEncriptadores()
        {
            iEncriptadores = new Dictionary<string,IEncriptador>();
    
            iEncriptadores.Add("Cesar", new EncriptadorCesar(CESAR_DESP));
            iEncriptadores.Add("AES", new EncriptadorAES(AES_PASSWORD, AES_SALT));
            iEncriptadores.Add("Nulo", new EncriptadorNulo());
        }

        /// <summary>
        /// Propiedad Instancia
        /// </summary>
        public static FabricaEncriptadores Instancia
        {
            get {if (cInstancia == null)
                  cInstancia = new FabricaEncriptadores();
                return cInstancia;}
        }

        /// <summary>
        /// Obtiene del diccionario el encriptador solicitado
        /// </summary>
        /// <param name="nombre">Nombre del encriptador</param>
        /// <returns>Instancia del encriptador</returns>
        public static IEncriptador GetEncriptador(string nombre) 
        {
            IEncriptador resultado;
            if (iEncriptadores.TryGetValue(nombre, out resultado))
            {
                return resultado;
            }
            else
            {
                return iEncriptadores["Nulo"];
            }
        }

        /// <summary>
        /// Obtiene los nombres de los distintos encriptadores
        /// </summary>
        /// <returns>Lista de nombres de los encriptadores</returns>
        public static List<string> GetNombres()
        {
            List<string> nombres = new List<string>();
            foreach (string nombre in iEncriptadores.Keys)
            {
                nombres.Add(nombre);
            }
            return nombres;
        }

    }
}
