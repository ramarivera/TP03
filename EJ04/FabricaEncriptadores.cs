using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
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
        /// Inicializa una nueva instancia de <see cref="FabricaEncriptadores"/>.
        ///  Ademas inicializa los metodos de encriptacion y los coloca en el diccionario
        /// </summary>
        private FabricaEncriptadores()
        {
            iEncriptadores = new Dictionary<string, IEncriptador>();

            iEncriptadores.Add("Cesar", new EncriptadorCesar(GetCesarDesplazamiento()));
            iEncriptadores.Add("AES", new EncriptadorAES(GetAESContraseña(), GetAESSal()));
            iEncriptadores.Add("Null", new EncriptadorNulo());
        }

        /// <summary>
        /// Obtiene el desplazamiento para inicializar el Encriptador Cesar del archivo de configuracion SettingsEJ04.settings
        /// </summary>
        /// <returns>Desplazamiento para inicializar el Encriptador Cesar</returns>
        private static int GetCesarDesplazamiento()
        {
            return SettingsEJ04.Default.CesDesplazamiento;
        }

        /// <summary>
        /// Obtiene la sal para inicializar el Encriptador AES del archivo de configuracion SettingsEJ04.settings
        /// </summary>
        /// <returns>Sal para inicializar el Encriptador AES</returns>
        private static string GetAESSal()
        {
            return SettingsEJ04.Default.AESSal;

            /* const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890$&";
             StringBuilder res = new StringBuilder();
             int len = 10;
             using (System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
             {
                 byte[] uintBuffer = new byte[sizeof(uint)];

                 while (len-- > 0)
                 {
                     rng.GetBytes(uintBuffer);
                     uint num = BitConverter.ToUInt32(uintBuffer, 0);
                     res.Append(valid[(int)(num % (uint)valid.Length)]);
                 }
             }

             SettingsEJ04.Default.AESSal = res.ToString();
             SettingsEJ04.Default.Save();
             return res.ToString();*/
        }

        /// <summary>
        /// Obtiene la contraseña para inicializar el Encriptador AES del archivo de configuracion SettingsEJ04.settings
        /// </summary>
        /// <returns>Contraseña para inicializar el Encriptador AES</returns>
        private static string GetAESContraseña()
        {
            return SettingsEJ04.Default.AESContraseña;
        }


        /// <summary>
        /// Propiedad Estatica Instancia, Solo Lectura
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
