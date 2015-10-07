using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using EJ04;
using EJ05.Properties;

namespace EJ05
{
    public class FabricaEncriptadores
    {
        private static FabricaEncriptadores cInstancia;
        private static Dictionary<string, IEncriptador> iEncriptadores;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="FabricaEncriptadores"/> Ademas inicializa los metodos de encriptacion y los coloca en el diccionario
        /// </summary>
        private FabricaEncriptadores()
        {
            iEncriptadores = new Dictionary<string, IEncriptador>();

            iEncriptadores.Add("Cesar", new EncriptadorCesar(GetCesarDesplazamiento()));
            iEncriptadores.Add("AES", new EncriptadorAES(GetAESContraseña(), GetAESSal()));
            iEncriptadores.Add("Enigma", new EncriptadorEnigma(GetEnigmaRotores(),GetEnigmaAnillos(),GetEnigmaConexiones()));
            iEncriptadores.Add("Nulo", new EncriptadorNulo());
        }
		private static int GetCesarDesplazamiento()
		{
			return Settings.Default.CesDesplazamiento;            
		}
		private static string GetAESSal()
		{
			return Settings.Default.AESSal;
		}
		private static string GetAESContraseña()
		{
			return Settings.Default.AESContraseña;
		}

		internal static char[] GetEnigmaAnillos ()
		{
			StringCollection lStringCol = Settings.Default.EngAnillos;
			int i = 0;
			char[] lArreglo = new char[lStringCol.Count];

			foreach (String lString in lStringCol)
			{
				lArreglo[i++] = Convert.ToChar(lString);
			}

			return lArreglo;
		}

		private static int[] GetEnigmaRotores()
		{
			StringCollection lStringCol = Settings.Default.EngRotores;
			int i = 0;
			int[] lArreglo = new int[lStringCol.Count];

			foreach (String lString in lStringCol)
			{
				lArreglo[i++] = Convert.ToInt32(lString);
			}

			return lArreglo;
		}

		private static string GetEnigmaConexiones()
		{
			return Settings.Default.EngConexiones;
		}

        /// <summary>
        /// Propiedad Instancia
        /// </summary>
		public static FabricaEncriptadores Instancia
        {
            get
            {
                if (cInstancia == null)
                    cInstancia = new FabricaEncriptadores();
                return cInstancia;
            }
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
