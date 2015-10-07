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

		public static FabricaEncriptadores Instancia
        {
            get
            {
                if (cInstancia == null)
                    cInstancia = new FabricaEncriptadores();
                return cInstancia;
            }
        }

        public IEncriptador GetEncriptador(string nombre)
        {
            IEncriptador resultado;
            if (iEncriptadores.TryGetValue(nombre.ToUpper(), out resultado))
            {
                return resultado;
            }
            else
            {
                return iEncriptadores["Nulo"];
            }
        }


    }
}
