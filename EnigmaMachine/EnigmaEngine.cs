using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachine
{
	/// <summary>
	/// Representa el Motor o Controlador de la Maquina Enigma, es le encargada de coordinar los rotores, reflectores y tableros
	/// </summary>
	public sealed class EnigmaEngine
	{

		/// <summary>
		/// Cantidad de caracteres en los que seperara los mensajes a encriptar y juntara luego de desencriptar
		/// </summary>
		private static readonly int TAMAÑO_BLOQUE = 6;

		/// <summary>
		/// Para escribir los numeros en el teclado de la Maquina Enigma, usamos YY_LETRA
		/// </summary>
		private static readonly char[] CONVERSION_NUMEROS = "PQWERTZUIO".ToCharArray();

		/// <summary>
		/// Conjunto de Rotores actualmente conectados
		/// </summary>
		private Rotores iRotores;

		/// <summary>
		/// Reflector insatalado en la maquina
		/// </summary>
		private Reflector iReflector;

		/// <summary>
		/// Tablero con sus respectivas conexiones
		/// </summary>
		private TableroConexiones iPlugBoard;

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="EnigmaEngine" />.
		/// Inicializa los respectivos elementos.
		/// </summary>
		public EnigmaEngine()
		{
			Rotores = new Rotores();
			Tablero = new TableroConexiones();
			Reflector = new Reflector();
		}

		/// <summary>
		/// Propiedad Rotores, Privada
		/// </summary>
		private Rotores Rotores
		{
			get { return this.iRotores; }
			set { this.iRotores = value; }
		}

		/// <summary>
		/// Propiedad Reflector, Privada
		/// </summary>
		private Reflector Reflector
		{
			get { return this.iReflector; }
			set { this.iReflector = value; }
		}

		/// <summary>
		/// Propiedad Tablero, Privada
		/// </summary>
		private TableroConexiones Tablero
		{
			get { return this.iPlugBoard; }
			set { this.iPlugBoard = value; }
		}

		/// <summary>
		/// Configura los distintos elementos, para empezar la codificacion/decodificacion
		/// </summary>
		/// <param name="pRotores">Numero de Rotores a Instalar</param>
		/// <param name="pAnillos">Posicion inicial de los Anillos de los Rotores</param>
		/// <param name="pConexiones">Conexiones del Tablero</param>
		public void Configurar(int[] pRotores, char[] pAnillos, string pConexiones)
		{
			Rotores.Inicializar(pRotores);
			Rotores.Configurar(pAnillos);
			Tablero.Configurar(pConexiones);
		}

		/// <summary>
		/// Encripta una cadena
		/// </summary>
		/// <param name="pCadena">Cadena a Encriptar</param>
		/// <returns>Cadena Encriptada</returns>
		public string Encriptar(string pCadena)
		{
			string lCadena = pCadena;
			lCadena = PrepararCadenaEncriptacion(lCadena);
			return CifrarCadena(lCadena);
		}

		/// <summary>
		/// Desencripta una cadena
		/// </summary>
		/// <param name="pCadena">Cadena a DesEncriptar</param>
		/// <returns>Cadena DesEncriptada</returns>
		public string Desencriptar(string pCadena)
		{
			string lCadena = pCadena;
			lCadena = CifrarCadena(lCadena);
			lCadena = PrepararCadenaDesencriptacion(lCadena);
			return lCadena;
		}


		/// <summary>
		/// Prepara una cadena para ser Encriptada.
		/// Reemplaza Espacios, ajusta en bloques, reemplaza numeros
		/// </summary>
		/// <param name="pCadena">Cadena a Encriptar</param>
		/// <returns>Cadena lista para ser encriptada</returns>
		private string PrepararCadenaEncriptacion (string pCadena)
		{
			string lCadena  = pCadena.Replace(" ", "$20");			// Elimino Espacios
			StringBuilder lConv = new StringBuilder ();
			
			for (int i = 0; i < lCadena.Length; i++)
			{
				if (char.IsDigit(lCadena[i]))
				{
					int ind = (int) char.GetNumericValue(lCadena[i]);
					lConv.Append("YY" + CONVERSION_NUMEROS[ind]);		// Reemplazo Numeros
				}
				else
				{
					lConv.Append(lCadena[i]);
				}
				if (lCadena.Length % TAMAÑO_BLOQUE == 0)
				{
					lConv.Append(' ');											// Separo en Bloques
				}
			}
			return lConv.ToString();
		}

		/// <summary>
		/// Prepara una cadena para ser Desencriptada.
		/// Reemplaza Espacios, elimina la separacion en bloques, reemplaza caracteres por numeros
		/// </summary>
		/// <param name="pCadena">Cadena a Desencriptar</param>
		/// <returns>Cadena lista para ser Desencriptada</returns>
		private string PrepararCadenaDesencriptacion(string pCadena)
		{
			string lResultado = pCadena.Replace(" ", string.Empty);
			lResultado = lResultado.Replace("YYP", "0");
			lResultado = lResultado.Replace("YYQ", "1");
			lResultado = lResultado.Replace("YYW", "2");
			lResultado = lResultado.Replace("YYE", "3");
			lResultado = lResultado.Replace("YYR", "4");
			lResultado = lResultado.Replace("YYT", "5");
			lResultado = lResultado.Replace("YYZ", "6");
			lResultado = lResultado.Replace("YYU", "7");
			lResultado = lResultado.Replace("YYO", "8");
			lResultado = lResultado.Replace("YYI", "9");
			lResultado = lResultado.Replace("$20", " ");
			return lResultado;
		}

		/// <summary>
		/// Cifra/Desencifra una cadena.
		/// Debido a la mecanica de la Maquina Enigma, este proceso es igual para ambos lados, cambiando solo los pasos previos y posteriores
		/// </summary>
		/// <param name="pCadena">Cadena a Cifrar</param>
		/// <returns>Cadena Cifrada</returns>
		private string CifrarCadena(string pCadena)
		{
			StringBuilder lResult = new StringBuilder();
			for (int i = 0; i < pCadena.Length; i++)
			{
				lResult.Append(CifrarChar(pCadena[i]));
			}
			return lResult.ToString();
		}

		/// <summary>
		/// Realiza el procedimiento de cifrado de un caracter, incluyendo el giro de los rotores.
		/// Este metodo emula la mecanica de la maquina para cada pulsacion de teclas, y nos devolveria el caracter cuya lampara se encenderia en la Maquina Enigma Original
		/// </summary>
		/// <param name="pChar">Char a cifrar</param>
		/// <returns>Char cifrado</returns>
		private char CifrarChar(char pChar)
		{
			char lResult = char.ToUpper(pChar);
			if (char.IsLetter(pChar))
			{
				lResult = Tablero.Conectar(lResult);					// La letra pasa atraves del tablero de conexiones, pudiendo o no cambiar su valor
				lResult = Rotores.Cifrar(true, lResult);				// Atraviesa toda la cadena de rotores de derecha a izquierda 
				lResult = Reflector.Reflejar(lResult);					// Se refleja en el reflector
				lResult = Rotores.Cifrar(false, lResult);				// Atraviesa la cadena de rotores de izquierda a derecha (Inversa)
				lResult = Tablero.Conectar(lResult);					// Atraviesa nuevamente el tablero de conexiones, pudiendo o no cambiar su valor
				Rotores.Girar();                                        // Por ultimo, se realiza el giro del primer rotor (El de mas a la derecha en la maquina enigma)
				lResult = char.IsLower(pChar) ? char.ToLower(lResult) : lResult;
			}
			return lResult;
		}

		public static bool ValidarConfiguracionTablero (string pConfiguracion)
		{
			return TableroConexiones.ConfiguracionValida(pConfiguracion);
		}
	}
}
