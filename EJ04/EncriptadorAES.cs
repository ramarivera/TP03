using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace EJ04
{
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
/*
/// <summary>
/// http://www.gutgames.com/post/AES-Encryption-in-C.aspx
/// </summary>
namespace Utilities.Encryption                  
{
	public static class AESEncryption
	{
		/// <param name="Salt">Salt to decrypt with</param>
		/// <param name="HashAlgorithm">Can be either SHA1 or MD5</param>
		/// <param name="PasswordIterations">Number of iterations to do</param>
		/// <param name="InitialVector">Needs to be 16 ASCII characters long</param>
		/// <param name="KeySize">Can be 128, 192, or 256</param>
		private static string InitialVector = "OFRna73m*aze01xY";
		private static string Salt = "Kosher";
		private static string HashAlgorithm = "SHA1";
		private static int PasswordIterations = 2;
		private static int KeySize = 256;

		#region Static Functions

		/// <summary>
		/// Encrypts a string
		/// </summary>
		/// <param name="PlainText">Text to be encrypted</param>
		/// <param name="Password">Password to encrypt with</param>
		/// <returns>An encrypted string</returns>
		public static string Encrypt(string PlainText, string Password)
		{
			if (string.IsNullOrEmpty(PlainText))
				return "";
			byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
			byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);
			byte[] PlainTextBytes = Encoding.UTF8.GetBytes(PlainText);
			PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(Password, SaltValueBytes, HashAlgorithm, PasswordIterations);
			byte[] KeyBytes = DerivedPassword.GetBytes(KeySize / 8);
			RijndaelManaged SymmetricKey = new RijndaelManaged();
			SymmetricKey.Mode = CipherMode.CBC;
			byte[] CipherTextBytes = null;
			using (ICryptoTransform Encryptor = SymmetricKey.CreateEncryptor(KeyBytes, InitialVectorBytes))
			{
				using (MemoryStream MemStream = new MemoryStream())
				{
					using (CryptoStream CryptoStream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write))
					{
						CryptoStream.Write(PlainTextBytes, 0, PlainTextBytes.Length);
						CryptoStream.FlushFinalBlock();
						CipherTextBytes = MemStream.ToArray();
						MemStream.Close();
						CryptoStream.Close();
					}
				}
			}
			SymmetricKey.Clear();
			return Convert.ToBase64String(CipherTextBytes);
		}

		/// <summary>
		/// Decrypts a string
		/// </summary>
		/// <param name="CipherText">Text to be decrypted</param>
		/// <param name="Password">Password to decrypt with</param>
		/// <returns>A decrypted string</returns>
		public static string Decrypt(string CipherText, string Password)
		{
			if (string.IsNullOrEmpty(CipherText))
				return "";
			byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
			byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);
			byte[] CipherTextBytes = Convert.FromBase64String(CipherText);
			PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(Password, SaltValueBytes, HashAlgorithm, PasswordIterations);
			byte[] KeyBytes = DerivedPassword.GetBytes(KeySize / 8);
			RijndaelManaged SymmetricKey = new RijndaelManaged();
			SymmetricKey.Mode = CipherMode.CBC;
			byte[] PlainTextBytes = new byte[CipherTextBytes.Length];
			int ByteCount = 0;
			using (ICryptoTransform Decryptor = SymmetricKey.CreateDecryptor(KeyBytes, InitialVectorBytes))
			{
				using (MemoryStream MemStream = new MemoryStream(CipherTextBytes))
				{
					using (CryptoStream CryptoStream = new CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read))
					{

						ByteCount = CryptoStream.Read(PlainTextBytes, 0, PlainTextBytes.Length);
						MemStream.Close();
						CryptoStream.Close();
					}
				}
			}
			SymmetricKey.Clear();
			return Encoding.UTF8.GetString(PlainTextBytes, 0, ByteCount);
		}

		#endregion
	}
}

/// <summary>
/// http://www.superstarcoders.com/blogs/posts/symmetric-encryption-in-c-sharp.aspx
/// </summary>
namespace SuperStarCoders
{
	using System;
	using System.Text;
	using System.Security.Cryptography;
	using System.IO;

	
}


namespace Microsoft
{
	using System;
	using System.IO;
	using System.Security.Cryptography;


	class AesExample
	{
		/// <summary>
		/// 
		/// </summary>
		public static void Main_2()
		{
			try
			{

				string original = "Here is some data to encrypt!";

				// Create a new instance of the AesManaged
				// class.  This generates a new key and initialization 
				// vector (IV).
				using (AesManaged myAes = new AesManaged())
				{

					// Encrypt the string to an array of bytes.
					byte[] encrypted = EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);

					// Decrypt the bytes to a string.
					string roundtrip = DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

					//Display the original data and the decrypted data.
					Console.WriteLine("Original:   {0}", original);
					Console.WriteLine("Round Trip: {0}", roundtrip);
				}

			}
			catch (Exception e)
			{
				Console.WriteLine("Error: {0}", e.Message);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="plainText"></param>
		/// <param name="Key"></param>
		/// <param name="IV"></param>
		/// <returns></returns>
		static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
		{
			// Check arguments.
			if (plainText == null || plainText.Length <= 0)
				throw new ArgumentNullException("plainText");
			if (Key == null || Key.Length <= 0)
				throw new ArgumentNullException("Key");
			if (IV == null || IV.Length <= 0)
				throw new ArgumentNullException("Key");
			byte[] encrypted;
			// Create an AesManaged object
			// with the specified key and IV.
			using (AesManaged aesAlg = new AesManaged())
			{
				aesAlg.Key = Key;
				aesAlg.IV = IV;

				// Create a decrytor to perform the stream transform.
				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

				// Create the streams used for encryption.
				using (MemoryStream msEncrypt = new MemoryStream())
				{
					using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
						{
							//Write all data to the stream.
							swEncrypt.Write(plainText);
						}
						encrypted = msEncrypt.ToArray();
					}
				}
			}
			// Return the encrypted bytes from the memory stream.
			return encrypted;
		}

		static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
		{
			// Check arguments.
			if (cipherText == null || cipherText.Length <= 0)
				throw new ArgumentNullException("cipherText");
			if (Key == null || Key.Length <= 0)
				throw new ArgumentNullException("Key");
			if (IV == null || IV.Length <= 0)
				throw new ArgumentNullException("Key");

			// Declare the string used to hold
			// the decrypted text.
			string plaintext = null;

			// Create an AesManaged object
			// with the specified key and IV.
			using (AesManaged aesAlg = new AesManaged())
			{
				aesAlg.Key = Key;
				aesAlg.IV = IV;

				// Create a decrytor to perform the stream transform.
				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

				// Create the streams used for decryption.
				using (MemoryStream msDecrypt = new MemoryStream(cipherText))
				{
					using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader srDecrypt = new StreamReader(csDecrypt))
						{

							// Read the decrypted bytes from the decrypting stream
							// and place them in a string.
							plaintext = srDecrypt.ReadToEnd();
						}
					}
				}

			}

			return plaintext;

		}
	}
}

    */