using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnigmaMachine;

namespace EnigmaMachineTest
{
	[TestClass]
	public class ReflectorTest
	{
		[TestMethod]
		public void Reflejar_WithA_ReturnsTrue()
		{
			char lResultado;
			char lResultadoEsperado = 'Z';
			char lLetra = 'A';
			Reflector lReflector = new Reflector();
			lResultado = lReflector.Reflejar(lLetra);
			Assert.AreEqual(lResultadoEsperado, lResultado);
		}

		[TestMethod]
		public void Reflejar_WithZ_ReturnsTrue()
		{
			char lResultado;
			char lResultadoEsperado = 'A';
			char lLetra = 'Z';
			Reflector lReflector = new Reflector();
			lResultado = lReflector.Reflejar(lLetra);
			Assert.AreEqual(lResultadoEsperado, lResultado);
		}

		[TestMethod]
		public void Reflejar_WithG_ReturnsTrue()
		{
			char lResultado;
			char lResultadoEsperado = 'G';
			char lLetra = 'N';
			Reflector lReflector = new Reflector();
			lResultado = lReflector.Reflejar(lLetra);
			Assert.AreEqual(lResultadoEsperado, lResultado);
		}
	}
}
