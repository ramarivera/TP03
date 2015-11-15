using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachine
{
	/// <summary>
	/// Representa el tablero de conexiones o PlugBoard de la Maquina Enigma. El mismo convierte las letras si existe una conexion en la misma.
	/// </summary>
	internal class TableroConexiones
	{
		/// <summary>
		/// Contiene los pares de configuraciones.
		/// </summary>
		private Dictionary<char, char> iConfiguracion;

		/// <summary>
		/// Propiedad Configuracion, LectoEscritura
		/// </summary>
		public Dictionary<char, char> Configuracion
		{
			get { return this.iConfiguracion; }
			set { this.iConfiguracion = value; }
		}

		/// <summary>
		/// Inicializa una nueva instancia de <see cref="TableroConexiones"/>. Inicializa el diccionario.
		/// </summary>
		public TableroConexiones()
		{
			Configuracion = new Dictionary<char, char>();
		}

		/// <summary>
		/// Verifica que la conexion ingresada no exista, y si es asi la agrega a la configuracion
		/// </summary>
		/// <param name="p1">Char 01</param>
		/// <param name="p2">Char 02</param>
		public void AgregarConexion (char p1, char p2)
		{
			if (!Configuracion.ContainsKey(p1) && !Configuracion.ContainsKey(p2))
			{
				Configuracion.Add(p1, p2);
				Configuracion.Add(p2, p1);
			}
		}

		/// <summary>
		/// Procesa un string de conexiones y agrega las mismas
		/// </summary>
		/// <param name="pConfiguracion">El string a procesar. El mismo debe estar en Mayuscula y sin Espacios, numeros, caracteres especiales</param>
		public void Configurar(string pConfiguracion)
		{
			int i = 0;
			while (i < pConfiguracion.Length)
			{
				AgregarConexion(pConfiguracion[i++], pConfiguracion[i++]);
			}
		}

		/// <summary>
		/// Verifica si un string de Configuracion es Valido.
		/// Se deberia llamar a este metodo antes de llamar a Configurar(string pConfiguracion)
		/// </summary>
		/// <param name="pConfiguracion">String a Verificar</param>
		/// <returns>-True si la configuracion es valida, falso en caso contrario</returns>
		public static bool ConfiguracionValida (string pConfiguracion)
		{
			if (pConfiguracion.Length % 2 != 0)															// Si los caracteres son impares la configuracion es invalida
			{
				return false;
			}
			if (!pConfiguracion.Any(char.IsUpper))														// Si existe algun caracter que no sea letra mayuscula la configuracion es invalida
			{
				return false;
			}
			return (new HashSet<char>(pConfiguracion.ToArray()).Count == pConfiguracion.Length);		// Si existe caracteres repetidos la configuracion no es valida.
																										// Comparo la cantidad de elementos de un HashSet con la cantidad de elementos Originales
		}

		/// <summary>
		/// Simula la conexion a traves de los cables del tablero al presionar una tecla
		/// </summary>
		/// <param name="pLetra">Char que se desea convertir</param>
		/// <returns>Puede devolver la misma letra u otra, dependiendo de la configuracion</returns>
		public char Conectar (char pLetra)
		{
			char lResult;
			if (!Configuracion.TryGetValue(pLetra,out lResult))
			{
				lResult = pLetra;
			}
			return lResult;
		}
	}
}
