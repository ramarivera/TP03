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
	/// <summary>
	/// Representa la Fabrica de Encriptadores, encargada de centralizar la configuracion inicial y gestionar los mismos, mediante el patron de diseño Singleton, Factory y NullObjetc
	/// </summary>
	public class FabricaEncriptadores
	{
		/// <summary>
		/// Campo donde se almacena la unica instancia de IEncriptador
		/// </summary>
		private static FabricaEncriptadores cInstancia;

		/// <summary>
		/// Almacena los distintos encriptadores
		/// </summary>
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
			iEncriptadores.Add("Null", new EncriptadorNulo());
		}

		/// <summary>
		/// Obtiene el desplazamiento para inicializar el Encriptador Cesar del archivo de configuracion SettingsEJ05.settings
		/// </summary>
		/// <returns>Desplazamiento para inicializar el Encriptador Cesar</returns>
		private static int GetCesarDesplazamiento()
		{
			return SettingsEJ05.Default.CesDesplazamiento;            
		}

		/// <summary>
		/// Obtiene la sal para inicializar el Encriptador AES del archivo de configuracion SettingsEJ05.settings
		/// </summary>
		/// <returns>Sal para inicializar el Encriptador AES</returns>
		private static string GetAESSal()
		{
			return SettingsEJ05.Default.AESSal;
		}

		/// <summary>
		/// Obtiene la contraseña para inicializar el Encriptador AES del archivo de configuracion SettingsEJ05.settings
		/// </summary>
		/// <returns>Contraseña para inicializar el Encriptador AES</returns>
		private static string GetAESContraseña()
		{
			return SettingsEJ05.Default.AESContraseña;
		}

		/// <summary>
		/// Obtiene la posicion inicial de los anillos para inicializar el Encriptador Enigma del archivo de configuracion SettingsEJ05.settings
		/// </summary>
		/// <returns>Posicion inicial de los anillos para inicializar el Encriptador Enigma</returns>
		internal static char[] GetEnigmaAnillos ()
		{
			StringCollection lStringCol = SettingsEJ05.Default.EngAnillos;
			int i = 0;
			char[] lArreglo = new char[lStringCol.Count];

			foreach (String lString in lStringCol)
			{
				lArreglo[i++] = Convert.ToChar(lString);
			}

			return lArreglo;
		}

		/// <summary>
		/// Obtiene los rotores para inicializar el Encriptador Enigma del archivo de configuracion SettingsEJ05.settings
		/// </summary>
		/// <returns>Rotores para inicializar el Encriptador Enigma</returns>
		private static int[] GetEnigmaRotores()
		{
			StringCollection lStringCol = SettingsEJ05.Default.EngRotores;
			int i = 0;
			int[] lArreglo = new int[lStringCol.Count];

			foreach (String lString in lStringCol)
			{
				lArreglo[i++] = Convert.ToInt32(lString);
			}

			return lArreglo;
		}

		/// <summary>
		/// Obtiene la configuracion para el tablero de conexiones para inicializar el Encriptador Enigma del archivo de configuracion SettingsEJ05.settings
		/// </summary>
		/// <returns> Configuracion para el tablero de conexiones para inicializar el Encriptador Enigma</returns>
		private static string GetEnigmaConexiones()
		{
			return SettingsEJ05.Default.EngConexiones;
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
		public IEncriptador GetEncriptador(string nombre)
		{
			IEncriptador resultado;
			if (iEncriptadores.TryGetValue(nombre, out resultado))
			{
				return resultado;
			}
			else
			{
				return iEncriptadores["Null"];
			}
		}
	}
}
