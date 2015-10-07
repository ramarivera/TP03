using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ05;
using EJ04;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Collections.Specialized;

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

            EJ05.FabricaEncriptadores lFabrica = EJ05.FabricaEncriptadores.Instancia;
			
			IEncriptador lEncriptadorNulo = lFabrica.GetEncriptador("NULO");
            IEncriptador lEncriptadorCesar = lFabrica.GetEncriptador("CESAR");
            IEncriptador lEncriptadorAES = lFabrica.GetEncriptador("AES");
            IEncriptador lEncriptadorEnigma = lFabrica.GetEncriptador("ENIGMA");

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
