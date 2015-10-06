using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ04;

namespace EJ04.Test
{
    [TestClass]
    public class EncriptadorAESTest
    {
        [TestMethod]
        public void Encriptar_WithAlfabetico_ReturnsTrue()
        {
            string lCadena = "RamiroRivera";
            string lResultado;
            string lResultadoEsperado = lCadena;
            string lSal = "Rivera";
            string lContraseña = "pFlEmEL5_¡4#pF";
            EncriptadorAES lAes = new EncriptadorAES(lContraseña,lSal);

            lResultado = lAes.Encriptar(lCadena);
            lResultado = lAes.Desencriptar(lResultado);

            Assert.AreEqual(lResultadoEsperado, lResultado);
        }

        [TestMethod]
        public void Encriptar_WithAlfaNumerico_ReturnsTrue()
        {
            string lCadena = "RamiroRivera125";
            string lResultado;
            string lResultadoEsperado = lCadena;
            string lSal = "Rivera";
            string lContraseña = "pFlEmEL5_¡4#pF";
            EncriptadorAES lAes = new EncriptadorAES(lContraseña, lSal);

            lResultado = lAes.Encriptar(lCadena);
            lResultado = lAes.Desencriptar(lResultado);

            Assert.AreEqual(lResultadoEsperado, lResultado);
        }

        [TestMethod]
        public void Encriptar_WithAlfaNumericoEspecial_ReturnsTrue()
        {
            string lCadena = "Ramiro R_iV3ra 12$&";
            string lResultado;
            string lResultadoEsperado = lCadena;
            string lSal = "Rivera";
            string lContraseña = "pFlEmEL5_¡4#pF";
            EncriptadorAES lAes = new EncriptadorAES(lContraseña, lSal);

            lResultado = lAes.Encriptar(lCadena);
            lResultado = lAes.Desencriptar(lResultado);

            Assert.AreEqual(lResultadoEsperado, lResultado);
        }
    }
}
