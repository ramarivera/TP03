using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace EJ04
{
    /// <summary>
    /// Representa un encriptador que utiliza el metodo AES
    /// </summary>
    internal class EncriptadorAES : Encriptador
    {
        private string Contraseña { get; set; }

        private string Sal { get; set; }

        /// <summary>
		/// Inicializa una nueva instancia de <see cref="EncriptadorAES"/>
		/// </summary>
        public EncriptadorAES() : base("AES") { }

        public EncriptadorAES(string pContraseña, string pSal) : this()
        {
            Contraseña = pContraseña;
            Sal = pSal;
        }

        /// <summary>
        /// Encripta una cadena mediante el método AES. Soporta solo las 26 letras del abecedario, en mayuscula o minuscula, y numeros.
        /// </summary>
        /// <param name="pCadena">Cadena a encriptar</param>
        /// <returns>Cadena encriptada</returns>
        public override string Encriptar(string pCadena)
        {
            DeriveBytes lRfc = new Rfc2898DeriveBytes(Contraseña, Encoding.Unicode.GetBytes(Sal));

            AesManaged lAes = new AesManaged();

            byte[] lKey = lRfc.GetBytes(lAes.KeySize >> 3);
            byte[] lIV = lRfc.GetBytes(lAes.BlockSize >> 3);

            ICryptoTransform transform = lAes.CreateEncryptor(lKey, lIV);

            using (MemoryStream buffer = new MemoryStream())
            {
                using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Write))
                {
                    using (StreamWriter writer = new StreamWriter(stream, Encoding.Unicode))
                    {
                        writer.Write(pCadena);
                    }
                }
                return Convert.ToBase64String(buffer.ToArray());
            }
        }

        /// <summary>
        /// Desencripta una cadena mediante el método AES. Soporta solo las 26 letras del abecedario, en mayuscula o minuscula, y numeros
        /// </summary>
        /// <param name="pCadena">Cadena a desencriptar</param>
        /// <returns>Cadena desencriptada</returns>
        public override string Desencriptar(string pCadena)
        {
            DeriveBytes lRfc = new Rfc2898DeriveBytes(Contraseña, Encoding.Unicode.GetBytes(Sal));

            AesManaged lAes = new AesManaged();

            byte[] lKey = lRfc.GetBytes(lAes.KeySize >> 3);
            byte[] lIV = lRfc.GetBytes(lAes.BlockSize >> 3);

            ICryptoTransform transform = lAes.CreateDecryptor(lKey, lIV);

            using (MemoryStream buffer = new MemoryStream(Convert.FromBase64String(pCadena)))
            {
                using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.Unicode))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }
}