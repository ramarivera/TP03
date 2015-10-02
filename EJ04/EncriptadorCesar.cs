using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    /// <summary>
    /// Representa un encriptador que utiliza el metodo Cesar. https://es.wikipedia.org/wiki/Cifrado_C%C3%A9sar
    /// </summary>
	public class EncriptadorCesar : Encriptador
	{
        /// <summary>
        /// Representa la cantidad de desplazamiento que realiza el encriptado
        /// </summary>
		private int iDesplazamiento;

        /// <summary>
        /// Propiedad Desplazamiento, lectura/escritura
        /// </summary>
		private int Desplazamiento
		{
			get { return this.iDesplazamiento; }
			set { this.iDesplazamiento = value; }
		}

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="pDesplazamiento">Cantidad de desplazamientos que realiza el encriptado</param>
		public EncriptadorCesar(int pDesplazamiento) : base("Cesar")
		{
			Desplazamiento = pDesplazamiento;
		}

        /// <summary>
        /// Encripta una cadena mediante el método Cesar. Soporta solo las 26 letras del abecedario en minuscula, de la "a" a la "z", sin ñ.
        /// </summary>
        /// <param name="pCadena">Cadena a encriptar</param>
        /// <returns>Cadena encriptada</returns>
		public override string Encriptar(string pCadena)
		{
            int ascii;
            char caracter;
			StringBuilder encriptado = new StringBuilder();
            int desplazar = Desplazamiento;
			desplazar %= 26;
            for (int i = 0; i < pCadena.Length; i++) // para todos los caracteres de la cadena
            {
                ascii = (Convert.ToInt32(pCadena[i]));//convertimos el caracter a encriptar en su valor ascii
                if ((ascii >= 97) && (ascii <= 122)) //verifica si el caracter a encriptar es soportado por el encriptador. 97 = a, 122 = z en ascii.
                {
                    ascii += desplazar;
                    if (ascii > 122) //si al sumar el desplazamiento nos pasamos del ultimo caracter permitido, volvemos a empezar desde el primero 
                    {
                        ascii -= 26;
                    }
                }
                caracter = (Convert.ToChar(ascii));//convertimos el valor ascii en el caracter que representa
				encriptado.Append(caracter);
            }
            return encriptado.ToString();
		}

        /// <summary>
        /// Desencripta una cadena mediante el método Cesar. Soporta solo las 26 letras del abecedario, de la "a" a la "z", sin ñ.
        /// </summary>
        /// <param name="pCadena">Cadena a desencriptar</param>
        /// <returns>Cadena desencriptada</returns>
		public override string Desencriptar(string pCadena)
		{
            int ascii;
            char caracter;
            string desencriptado = null;
            int desplazar = Desplazamiento;
            if (desplazar > 26) //si el desplazamiento es mayor a 26 caracteres, vuelve a empezar a contar la cantidad de desplazamientos. Por ejemplo 27 desplazamientos = 1 desplazamiento
            {
                while (desplazar > 26)
                {
                    desplazar -= 26;
                }
            }
            for (int i = 0; i < pCadena.Length; i++) // para todos los caracteres de la cadena
            {
                ascii = (Convert.ToInt32(pCadena[i]));//convertimos el caracter a encriptar en su valor ascii
                if ((ascii >= 97) && (ascii <= 122)) //verifica si el caracter a encriptar es soportado por el encriptador. 97 = a, 122 = z en ascii.
                {
                    ascii -= desplazar;
                    if (ascii < 97) //si al restar el desplazamiento nos pasamos del primer caracter permitido, volvemos a empezar desde el ultimo 
                    {
                        ascii += 26;
                    }
                }
                caracter = (Convert.ToChar(ascii));//convertimos el valor ascii en el caracter que representa
                desencriptado += string.Concat(caracter);
            }
            return desencriptado;
		}
	}
}
