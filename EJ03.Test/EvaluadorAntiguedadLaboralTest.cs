using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ03;

namespace EJ03.Test
{
	[TestClass]
	public class EvaluadorAntiguedadLaboralTest
	{
		[TestMethod]
		public void EsValida_WithAntiguedadMenor_ReturnsFalse()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 12;
			double iMonto = 20000;
			double iSueldo = 5500;
			DateTime iFechaNac = new DateTime(1993, 07, 11);
			DateTime iFechaIng = DateTime.Today;


			Empleo iEmpleo = new Empleo(iSueldo, iFechaIng);
			Cliente iCliente = new Cliente(iNombre, iApellido, iFechaNac, iEmpleo);
			iCliente.TipoCliente = TipoCliente.NoCliente;
			SolicitudPrestamo iSolicitudPrestamo = new SolicitudPrestamo(iCliente, iMonto, iCantidadCuotas);

			GestorPrestamos iGestorPrestamos = new GestorPrestamos();
			Assert.IsFalse(iGestorPrestamos.EsValida(iSolicitudPrestamo));
		}

		[TestMethod]
		public void EsValida_WithAntiguedadMayor_ReturnsTrue()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 12;
			double iMonto = 20000;
			double iSueldo = 5500;
			DateTime iFechaNac = new DateTime(1993, 07, 11);
			DateTime iFechaIng = new DateTime(2000, 09, 11);


			Empleo iEmpleo = new Empleo(iSueldo, iFechaIng);
			Cliente iCliente = new Cliente(iNombre, iApellido, iFechaNac, iEmpleo);
			iCliente.TipoCliente = TipoCliente.NoCliente;
			SolicitudPrestamo iSolicitudPrestamo = new SolicitudPrestamo(iCliente, iMonto, iCantidadCuotas);

			GestorPrestamos iGestorPrestamos = new GestorPrestamos();
			Assert.IsTrue(iGestorPrestamos.EsValida(iSolicitudPrestamo));
		}
	}
}
