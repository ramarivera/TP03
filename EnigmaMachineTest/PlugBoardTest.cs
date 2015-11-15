using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnigmaMachine;

namespace EnigmaMachineTest
{
	[TestClass]
	public class PlugBoardTest
	{
		[TestMethod]
		public void Conectar_WithA_1Conexion_ReturnsTrue()
		{
			char lResultado;
			char lResultadoEsperado = 'B';
			char lLetra = 'A';
			TableroConexiones lPlugBoard = new TableroConexiones();
			lPlugBoard.AgregarConexion('A', 'B');
			lResultado = lPlugBoard.Conectar(lLetra);
			Assert.AreEqual(lResultadoEsperado, lResultado);
		}

		[TestMethod]
		public void Conectar_WithA_SinConexion_ReturnsTrue()
		{
			char lResultado;
			char lResultadoEsperado = 'A';
			char lLetra = 'A';
			TableroConexiones lPlugBoard = new TableroConexiones();
			lPlugBoard.AgregarConexion('C', 'B');
			lResultado = lPlugBoard.Conectar(lLetra);
			Assert.AreEqual(lResultadoEsperado, lResultado);
		}

		[TestMethod]
		public void Conectar_WithA_2Conexion_ReturnsTrue()
		{
			char lResultado;
			char l1 = 'A';
			char l2 = 'B';
			char l3 = 'C';
			char l4 = 'D';
			char lResultadoEsperado =l2;
			TableroConexiones lPlugBoard = new TableroConexiones();
			lPlugBoard.AgregarConexion(l1, l2);
			lPlugBoard.AgregarConexion(l1, l3);
			lPlugBoard.AgregarConexion(l2, l4);
			lResultado = lPlugBoard.Conectar(l1);
			Assert.AreEqual(lResultadoEsperado, lResultado);
		}

		[TestMethod]
		public void Conectar_WithB_2Conexion_ReturnsTrue()
		{
			char lResultado;
			char l1 = 'A';
			char l2 = 'B';
			char l3 = 'C';
			char l4 = 'D';
			char lResultadoEsperado = l1;
			TableroConexiones lPlugBoard = new TableroConexiones();
			lPlugBoard.AgregarConexion(l1, l2);
			lPlugBoard.AgregarConexion(l1, l3);
			lPlugBoard.AgregarConexion(l2, l4);
			lResultado = lPlugBoard.Conectar(l2);
			Assert.AreEqual(lResultadoEsperado, lResultado);
		}


		[TestMethod]
		public void ConfiguracionValida_WithACBD_ReturnsTrue()
		{
			char l1 = 'A';
			char l2 = 'B';
			char l3 = 'C';
			char l4 = 'D';
			string lCadena = "ACBD";
			char lResultado;
			char lResultadoEsperado;
			Dictionary<char, char> lConf1 = new Dictionary<char, char>();
			Dictionary<char, char> lConf2 = new Dictionary<char, char>();
			TableroConexiones lPlugBoard = new TableroConexiones();
			if (TableroConexiones.ConfiguracionValida(lCadena))
			{
				lPlugBoard.Configurar(lCadena);
			}
			lResultado = lPlugBoard.Conectar(l2);

			lConf2.Add(l1, l3);
			lConf2.Add(l3, l1);
			lConf2.Add(l2, l4);
			lConf2.Add(l4, l2);
			
			lPlugBoard.Configuracion = lConf2;
			lResultadoEsperado = lPlugBoard.Conectar(l2);
			Assert.AreEqual(lResultadoEsperado, lResultado);
		}
		[TestMethod]
		public void ConfiguracionValida_WithA_ReturnsTrue()
		{
			char lResultado;
			char l1 = 'A';
			char l2 = 'D';

			string lCadena = "ADCB";
			Dictionary<char, char> lConexiones = new Dictionary<char, char>();
			char lResultadoEsperado = l2;

			TableroConexiones lPlugBoard = new TableroConexiones();

			if (TableroConexiones.ConfiguracionValida(lCadena))
			{
				lPlugBoard.Configurar(lCadena);
			}
			
			lResultado = lPlugBoard.Conectar(l1);
			Assert.AreEqual(lResultadoEsperado, lResultado);
		}

		[TestMethod]
		public void ConfiguracionValida_WithAABC_ReturnsFalse()
		{
			string lCadena = "AABC";
			Assert.IsFalse(TableroConexiones.ConfiguracionValida(lCadena));
		}

		[TestMethod]
		public void ConfiguracionValida_WithADEBC_ReturnsFalse()
		{
			string lCadena = "ADEBC";
			Assert.IsFalse(TableroConexiones.ConfiguracionValida(lCadena));
		}
	}
}


