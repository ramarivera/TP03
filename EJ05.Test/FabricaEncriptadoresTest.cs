using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ05;
using EJ04;

namespace EJ05.Test
{
    [TestClass]
    public class FabricaEncriptadoresTest
    {
        [TestMethod]
        public void GetEncriptador_WithAlfabetico_All_ReturnsTrue()
        {
            string lCadena = "Ramiro Rivera";
            string lResultado;
            string lResultadoEsperado = lCadena;

            EJ05.FabricaEncriptadores lFabrida = EJ05.FabricaEncriptadores.Instancia;

            IEncriptador lEncriptadorNulo = lFabrida.GetEncriptador("NULO");
            IEncriptador lEncriptadorCesar = lFabrida.GetEncriptador("CESAR");
            IEncriptador lEncriptadorAES = lFabrida.GetEncriptador("AES");
            IEncriptador lEncriptadorEnigma = lFabrida.GetEncriptador("ENIGMA");

            lResultado = lEncriptadorCesar.Encriptar(lCadena);
            lResultado = lEncriptadorEnigma.Encriptar(lResultado);
            lResultado = lEncriptadorAES.Encriptar(lResultado);
            lResultado = lEncriptadorNulo.Encriptar(lResultado);

            lResultado = lEncriptadorNulo.Desencriptar(lResultado);
            lResultado = lEncriptadorAES.Desencriptar(lResultado);
            lResultado = lEncriptadorEnigma.Desencriptar(lResultado);
            lResultado = lEncriptadorCesar.Desencriptar(lResultado);


            Assert.AreEqual(lResultadoEsperado, lResultado);

        }
    }
}
