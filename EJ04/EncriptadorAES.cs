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
		/// Encripta una cadena de texto
		/// </summary>
		/// <param name="pCadena">Cadena a encriptar</param>
		/// <returns>Cadena encriptada</returns>
		public override string Encriptar(string pCadena)
		{
			DeriveBytes lRfc = new Rfc2898DeriveBytes(Contraseña, Encoding.Unicode.GetBytes(Sal));                              // Inicializo una clase que me permetira derivar una Key y IV

			AesManaged lAes = new AesManaged();                                                                                 // Inicializo la clase de .Net para realziar el cifrado por el metodo AES
								
			byte[] lKey = lRfc.GetBytes(lAes.KeySize >> 3);                                                                     // Obtengo la Key
			byte[] lIV = lRfc.GetBytes(lAes.BlockSize >> 3);                                                                    // Obtengo el IV o Vector de Inicializacion 

			ICryptoTransform transform = lAes.CreateEncryptor(lKey, lIV);                                                       // Inicializo un encriptador simetrico utilizando la Key y el IV

			using (MemoryStream buffer = new MemoryStream())                                                                    // Utilizamos el Using para definir un contexto especifico de existencia del Objeto
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
		/// Desencripta una cadena de texto previamente encriptada por este encriptador
		/// </summary>
		/// <param name="pCadena">Cadena a desencriptar</param>
		/// <returns>Cadena desencriptada</returns>
		public override string Desencriptar(string pCadena)
		{
			DeriveBytes lRfc = new Rfc2898DeriveBytes(Contraseña, Encoding.Unicode.GetBytes(Sal));                              // Inicializo una clase que me permetira derivar una Key y IV
            //this
			AesManaged lAes = new AesManaged();                                                                                 // Inicializo la clase de .Net para realziar el cifrado por el metodo AES

			byte[] lKey = lRfc.GetBytes(lAes.KeySize >> 3);                                                                     // Obtengo la Key
			byte[] lIV = lRfc.GetBytes(lAes.BlockSize >> 3);                                                                    // Obtengo el IV o Vector de Inicializacion 

			ICryptoTransform transform = lAes.CreateDecryptor(lKey, lIV);                                                       // Inicializo un encriptador simetrico utilizando la Key y el IV

			using (MemoryStream buffer = new MemoryStream(Convert.FromBase64String(pCadena)))                                   // Utilizamos el Using para definir un contexto especifico de existencia del Objeto
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