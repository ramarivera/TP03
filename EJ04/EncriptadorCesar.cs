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
    internal class EncriptadorCesar : Encriptador
    {
        private static readonly int MAYUS_A = 65;
        private static readonly int MAYUS_Z = 90;
        private static readonly int MINUS_A = 97;
        private static readonly int MINUS_Z = 122;
        private static readonly int CANTIDAD_LETRAS = 26;
        /// <summary>
        /// Representa la cantidad de desplazamiento que realiza el encriptado
        /// </summary>
        private int iDesplazamiento;

        /// <summary>
        /// Propiedad Desplazamiento, lectura/escritura
        /// </summary>
        public int Desplazamiento
        {
            get { return this.iDesplazamiento; }
            set { this.iDesplazamiento = value; }
        }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="EncriptadorCesar"/>
        /// </summary>
        /// <param name="pDesplazamiento">Cantidad de desplazamientos que realiza el encriptado</param>
        public EncriptadorCesar(int pDesplazamiento): base("Cesar")
        {
            Desplazamiento = pDesplazamiento;
        }

        /// <summary>
        /// Encripta una cadena mediante el método Cesar. Soporta solo las 26 letras del abecedario, en mayuscula o minuscula, y numeros
        /// </summary>
        /// <param name="pCadena">Cadena a encriptar</param>
        /// <returns>Cadena encriptada</returns>
        public override string Encriptar(string pCadena)
        {
            int ascii;
            char caracter;
            StringBuilder encriptado = new StringBuilder();
            int desplazar = Desplazamiento;
            desplazar %= CANTIDAD_LETRAS;
            for (int i = 0; i < pCadena.Length; i++)						// para todos los caracteres de la cadena
            {
                bool minuscula = false;
                ascii = (Convert.ToInt32(pCadena[i]));						// convertimos el caracter a encriptar en su valor ascii
                if ((ascii >= 48) && (ascii <= 57))
                {
                    ascii += desplazar;
                    if (ascii > 57)									        // si al sumar el desplazamiento nos pasamos del ultimo caracter permitido, volvemos a empezar desde el primero 
                    {
                        ascii -= 10;
                    }
                }
                if ((ascii >= MINUS_A) && (ascii <= MINUS_Z))               // verifica si la letra es minuscula
                {
                    ascii -= 32;                                            // de ser asi, convierte el ascii es la misma letra pero mayuscula
                    minuscula = true;
                }
                if ((ascii >= MAYUS_A) && (ascii <= MAYUS_Z))			    // verifica si el caracter a encriptar es soportado por el encriptador.
                {
                    ascii += desplazar;
                    if (ascii > MAYUS_Z)									// si al sumar el desplazamiento nos pasamos del ultimo caracter permitido, volvemos a empezar desde el primero 
                    {
                        ascii -= CANTIDAD_LETRAS;
                    }
                }
                if (minuscula)                                              // si el caracter originalmente era una letra minuscula, vuelve a serlo
                {
                    ascii += 32;
                }
                caracter = (Convert.ToChar(ascii));							// convertimos el valor ascii en el caracter que representa
                encriptado.Append(caracter);
            }
            return encriptado.ToString();
        }

        /// <summary>
        /// Desencripta una cadena mediante el método Cesar. Soporta solo las 26 letras del abecedario, en mayuscula o minuscula, y numeros
        /// </summary>
        /// <param name="pCadena">Cadena a desencriptar</param>
        /// <returns>Cadena desencriptada</returns>
        public override string Desencriptar(string pCadena)
        {
            int ascii;
            char caracter;
            StringBuilder desencriptado = new StringBuilder();
            int desplazar = Desplazamiento;
            desplazar %= CANTIDAD_LETRAS;
            for (int i = 0; i < pCadena.Length; i++)						// para todos los caracteres de la cadena
            {
                bool minuscula = false;
                ascii = (Convert.ToInt32(pCadena[i]));						// convertimos el caracter a encriptar en su valor ascii
                if ((ascii >= 48) && (ascii <= 57))   			            // verifica si el caracter a encriptar es soportado por el encriptador.
                {
                    ascii -= desplazar;
                    if (ascii < 48)									        // si al restar el desplazamiento nos pasamos del primer caracter permitido, volvemos a empezar desde el ultimo 
                    {
                        ascii += 10;
                    }
                }
                if ((ascii >= MINUS_A) && (ascii <= MINUS_Z))               // verifica si la letra es minuscula
                {
                    ascii -= 32;                                            // de ser asi, convierte el ascii es la misma letra pero mayuscula
                    minuscula = true;
                }
                if ((ascii >= MAYUS_A) && (ascii <= MAYUS_Z))   			// verifica si el caracter a encriptar es soportado por el encriptador.
                {
                    ascii -= desplazar;
                    if (ascii < MAYUS_A)									// si al restar el desplazamiento nos pasamos del primer caracter permitido, volvemos a empezar desde el ultimo 
                    {
                        ascii += CANTIDAD_LETRAS;
                    }
                }
                if (minuscula)                                              // si el caracter originalmente era una letra minuscula, vuelve a serlo
                {
                    ascii += 32;
                }
                caracter = (Convert.ToChar(ascii));							// convertimos el valor ascii en el caracter que representa
                desencriptado.Append(caracter);
            }
            return desencriptado.ToString();
        }
    }
}
