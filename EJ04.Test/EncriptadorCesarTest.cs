using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ04;

namespace EJ04.Test
{
    [TestClass]
    public class EncriptadorCesarTest
    {
        [TestMethod]
        public void Encriptar_WithHola_ReturnsEqual()
        {
            int desplazar = 5;
            string cadena = "hola";
            string resultado = "mtqf";

            EncriptadorCesar cesar = new EncriptadorCesar(desplazar);
            Assert.AreEqual(resultado, cesar.Encriptar(cadena));
        }

        [TestMethod]
        public void Desencriptar_WithHola_ReturnsEqual()
        {
            int desplazar = 5;
            string cadena = "mtqf";
            string resultado = "hola";

            EncriptadorCesar cesar = new EncriptadorCesar(desplazar);
            Assert.AreEqual(resultado, cesar.Desencriptar(cadena));
        }

        [TestMethod]
        public void EncriptarDesencriptar_WithHola_ReturnsEqual()
        {
            int desplazar = 5;
            string cadena = "hola";

            EncriptadorCesar cesar = new EncriptadorCesar(desplazar);
            string encriptado = cesar.Encriptar(cadena);
            Assert.AreEqual(cadena, cesar.Desencriptar(encriptado));
        }
    }
}
