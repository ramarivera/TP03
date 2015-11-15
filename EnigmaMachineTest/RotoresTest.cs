using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnigmaMachine;
using System.Reflection;

namespace EnigmaMachineTest
{
	[TestClass]
	public class RotoresTest
	{
		[TestMethod]
		public void Cifrar_WithA_1Rotor_ReturnsTrue()
		{
			char lResultado;
			char lResultadoEsperado = 'P';
			char lLetra = 'A';
			char lConfInicial = 'A';
			Rotor lRotor = new Rotor(1);
			lRotor.Configurar(lConfInicial);
			Rotores lRotores = new Rotores();

			MethodInfo methodInfo = lRotores.GetType().GetMethod("AgregarRotor", BindingFlags.Instance | BindingFlags.NonPublic);
			methodInfo.Invoke(lRotores, new object[] { lRotor });              // lRotores.AgregarRotor(lRotor1);

			lResultado = lRotores.Cifrar(true, lLetra);
			Assert.AreEqual(lResultadoEsperado, lResultado);
		}
		[TestMethod]
		public void Cifrar_WithA_Derecha_ReturnsTrue()
		{
			char lResultado;
			char lResultadoEsperado = 'T';
			char lLetra = 'A';
			char[] lVectorConfiguracion = new char[] { 'A', 'A' };
			int[] lVectorInicializacion = new int[] { 1, 2 };
            Rotores lRotores = new Rotores();
			lRotores.Inicializar(lVectorInicializacion);
			lRotores.Configurar(lVectorConfiguracion);
			lResultado = lRotores.Cifrar(true,lLetra);
			Assert.AreEqual(lResultadoEsperado, lResultado);
		}
		[TestMethod]
		public void Cifrar_WithT_Izquierda_ReturnsTrue()
		{
			char lResultado;
			char lResultadoEsperado = 'A';
			char lLetra = 'T';
			char[] lVectorConfiguracion = new char[] { 'A', 'A' };
			int[] lVectorInicializacion = new int[] { 1, 2 };
			Rotores lRotores = new Rotores();
			lRotores.Inicializar(lVectorInicializacion);
			lRotores.Configurar(lVectorConfiguracion);
			lResultado = lRotores.Cifrar(false, lLetra);
			Assert.AreEqual(lResultadoEsperado, lResultado);
		}
	}
}
