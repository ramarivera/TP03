using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ04
{
    public class FabricaEncriptadores
    {
        private static FabricaEncriptadores cInstancia;
        private static Dictionary<string,IEncriptador> iEncriptadores;
        private static readonly int CESAR_DESP = 10;
        private static readonly string AES_SALT = "Rivera";
        private static readonly string AES_PASSWORD = "pFlEmEL5_¡4#pF";

        private FabricaEncriptadores()
        {
            iEncriptadores = new Dictionary<string,IEncriptador>();
          
            iEncriptadores.Add("CESAR", new EncriptadorCesar(CESAR_DESP));
            iEncriptadores.Add("AES", new EncriptadorAES(AES_PASSWORD, AES_SALT));
            iEncriptadores.Add("NULO", new EncriptadorNulo());
        }

        public static FabricaEncriptadores Instancia
        {
            get {if (cInstancia == null)
                  cInstancia = new FabricaEncriptadores();
                return cInstancia;}
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
                return iEncriptadores["NULO"];
            }
        }


    }
}
