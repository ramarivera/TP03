using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EJ03.Test
{
	[TestClass]
	public class EvaluadorEdadTest
	{
		[TestMethod]
		public void EsValida_WithEdadMenor_ReturnsFalse()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 12;
			double iMonto = 20000;
			double iSueldo = 5500;
			DateTime iFechaNac = new DateTime(2010, 05, 05);
			DateTime iFechaIng = new DateTime(2014, 03, 14);


			Empleo iEmpleo = new Empleo(iSueldo, iFechaIng);
			Cliente iCliente = new Cliente(iNombre, iApellido, iFechaNac, iEmpleo);
			iCliente.TipoCliente = TipoCliente.NoCliente;
			SolicitudPrestamo iSolicitudPrestamo = new SolicitudPrestamo(iCliente, iMonto, iCantidadCuotas);

			GestorPrestamos iGestorPrestamos = new GestorPrestamos();
			Assert.IsFalse(iGestorPrestamos.EsValida(iSolicitudPrestamo));
		}

		[TestMethod]
		public void EsValida_WithEdadMayor_ReturnsFalse()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 12;
			double iMonto = 20000;
			double iSueldo = 5500;
			DateTime iFechaNac = new DateTime(1910, 05, 05);
			DateTime iFechaIng = new DateTime(2014, 03, 14);


			Empleo iEmpleo = new Empleo(iSueldo, iFechaIng);
			Cliente iCliente = new Cliente(iNombre, iApellido, iFechaNac, iEmpleo);
			iCliente.TipoCliente = TipoCliente.NoCliente;
			SolicitudPrestamo iSolicitudPrestamo = new SolicitudPrestamo(iCliente, iMonto, iCantidadCuotas);

			GestorPrestamos iGestorPrestamos = new GestorPrestamos();
			Assert.IsFalse(iGestorPrestamos.EsValida(iSolicitudPrestamo));
		}

		[TestMethod]
		public void EsValida_WithEdadCorrecta_ReturnsTrue()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 12;
			double iMonto = 20000;
			double iSueldo = 5500;
			DateTime iFechaNac = new DateTime(1993, 07 , 11);
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
