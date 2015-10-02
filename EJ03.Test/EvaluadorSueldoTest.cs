using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EJ03.Test
{
	[TestClass]
	public class EvaluadorSueldoTest
	{
		[TestMethod]
		public void EsValida_WithSueldoMenor_ReturnsFalse()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 12;
			double iMonto = 20000;
			double iSueldo = 3500;
			DateTime iFechaNac = new DateTime(1993, 07, 11);
			DateTime iFechaIng = new DateTime(2014, 03, 14);


			Empleo iEmpleo = new Empleo(iSueldo, iFechaIng);
			Cliente iCliente = new Cliente(iNombre, iApellido, iFechaNac, iEmpleo);
			iCliente.TipoCliente = TipoCliente.NoCliente;
			SolicitudPrestamo iSolicitudPrestamo = new SolicitudPrestamo(iCliente, iMonto, iCantidadCuotas);

			GestorPrestamos iGestorPrestamos = new GestorPrestamos();
			Assert.IsFalse(iGestorPrestamos.EsValida(iSolicitudPrestamo));
		}


		[TestMethod]
		public void EsValida_WithSueldoMayor_ReturnsTrue()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 12;
			double iMonto = 20000;
			double iSueldo = 15000;
			DateTime iFechaNac = new DateTime(1993, 07, 11);
			DateTime iFechaIng = new DateTime(2014, 03, 14);


			Empleo iEmpleo = new Empleo(iSueldo, iFechaIng);
			Cliente iCliente = new Cliente(iNombre, iApellido, iFechaNac, iEmpleo);
			iCliente.TipoCliente = TipoCliente.NoCliente;
			SolicitudPrestamo iSolicitudPrestamo = new SolicitudPrestamo(iCliente, iMonto, iCantidadCuotas);

			GestorPrestamos iGestorPrestamos = new GestorPrestamos();
			Assert.IsTrue(iGestorPrestamos.EsValida(iSolicitudPrestamo));
		}

	}
}
