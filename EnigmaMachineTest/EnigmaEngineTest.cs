using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnigmaMachine;
using System.Reflection;

namespace EnigmaMachineTest
{
	[TestClass]
	public class EnigmaEngineTest
	{
		[TestMethod]
		public void CifrarChar_WithA_ReturnsTrue()
		{
			int[] lConfRotores = { 1, 2, 3 };
			char[] lConfAnillos = { 'A', 'A', 'A' };
			string lConfTablero = "ABGHRTYUPC";
			char lLetra = 'R';
			char lResultado;
			char lResultadoEsperado = lLetra;

			EnigmaEngine lEnigma = new EnigmaEngine();
			lEnigma.Configurar(lConfRotores, lConfAnillos, lConfTablero);
			MethodInfo methodInfo = lEnigma.GetType().GetMethod("CifrarChar", BindingFlags.Instance | BindingFlags.NonPublic);
			lResultado = (char) methodInfo.Invoke(lEnigma, new object[] { lLetra });              // lEnigma.CifrarChar(lLetra);

			lEnigma.Configurar(lConfRotores, lConfAnillos, lConfTablero);
			methodInfo = lEnigma.GetType().GetMethod("CifrarChar", BindingFlags.Instance | BindingFlags.NonPublic);
			lResultado = (char)methodInfo.Invoke(lEnigma, new object[] { lResultado });              // lEnigma.CifrarChar(lLetra);

			Assert.AreEqual(lResultadoEsperado, lResultado);
		}

		[TestMethod]
		public void CifrarCadena_WithRRivera_ReturnsTrue()
		{
			int[] lConfRotores = { 1, 2, 3 };
			char[] lConfAnillos = { 'A', 'A', 'A' };
			string lConfTablero = "ABGHRTYUPC";
			string lCadena = "Ramiro25 Rivera!";
			string lResultado;
			string lResultadoEsperado = lCadena;

			EnigmaEngine lEnigma = new EnigmaEngine();
			lEnigma.Configurar(lConfRotores, lConfAnillos, lConfTablero);
			lResultado = lEnigma.Encriptar(lCadena);
			lEnigma.Configurar(lConfRotores, lConfAnillos, lConfTablero);
			lResultado = lEnigma.Desencriptar(lResultado); 

			Assert.AreEqual(lResultadoEsperado, lResultado);
		}

		[TestMethod]
		public void PrepararCadena_WithA15_ReturnsTrue()
		{

			string lCadena = "A15 !F";
			string lResultado;
			string lResultadoEsperado = lCadena;

			EnigmaEngine lEnigma = new EnigmaEngine();
			
			MethodInfo methodInfo = lEnigma.GetType().GetMethod("PrepararCadenaEncriptacion", BindingFlags.Instance | BindingFlags.NonPublic);
			lResultado = (string) methodInfo.Invoke(lEnigma, new object[] { lCadena });              // lEnigma.CifrarChar(lLetra);

		
			methodInfo = lEnigma.GetType().GetMethod("PrepararCadenaDesencriptacion", BindingFlags.Instance | BindingFlags.NonPublic);
			lResultado = (string) methodInfo.Invoke(lEnigma, new object[] { lResultado });              // lEnigma.CifrarChar(lLetra);

			Assert.AreEqual(lResultadoEsperado, lResultado);
		}
	}
}
