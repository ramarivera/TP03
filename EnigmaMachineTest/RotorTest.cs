using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnigmaMachine;

namespace EnigmaMachineTest
{
	[TestClass]
	public class RotorTest
	{
		[TestMethod]
		public void Configurar_WithA_ReturnsTrue()
		{
			string lResultado;
			string lResultadoEsperado = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			Rotor lRotor = new Rotor(1);
			lRotor.Configurar('A');
			lResultado = lRotor.Anillo.ToString();
			Assert.AreEqual(lResultadoEsperado,lResultado);
		}

		[TestMethod]
		public void Configurar_WithR_ReturnsTrue()
		{
			string lResultado;
			string lResultadoEsperado = "RSTUVWXYZABCDEFGHIJKLMNOPQ";
			Rotor lRotor = new Rotor(1);
			lRotor.Configurar('R');
			lResultado = lRotor.Anillo.ToString();
			Assert.AreEqual(lResultadoEsperado, lResultado);
		}

		[TestMethod]
		public void Configurar_WithZ_ReturnsTrue()
		{
			string lResultado;
			string lResultadoEsperado = "ZABCDEFGHIJKLMNOPQRSTUVWXY";
			Rotor lRotor = new Rotor(1);
			lRotor.Configurar('Z');
			lResultado = lRotor.Anillo.ToString();
			Assert.AreEqual(lResultadoEsperado, lResultado);
		}

	
	}
}
