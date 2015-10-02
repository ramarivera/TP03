using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EJ03.Test01
{
	[TestClass]
	public class EvaluadorMontoTest
	{
		[TestMethod]
		public void EsValida_WithNoCliente_MontoMayor_ReturnsFalse()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 12;
			double iMonto = 20001;
			double iSueldo = 5500;
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
		public void EsValida_WithNoCliente_MontoMenor_ReturnsTrue()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 12;
			double iMonto = 20000;
			double iSueldo = 5500;
			DateTime iFechaNac = new DateTime(1993, 07, 11);
			DateTime iFechaIng = new DateTime(2014, 03, 14);

			Empleo iEmpleo = new Empleo(iSueldo, iFechaIng);
			Cliente iCliente = new Cliente(iNombre, iApellido, iFechaNac, iEmpleo);
			iCliente.TipoCliente = TipoCliente.NoCliente;
			SolicitudPrestamo iSolicitudPrestamo = new SolicitudPrestamo(iCliente, iMonto, iCantidadCuotas);

			GestorPrestamos iGestorPrestamos = new GestorPrestamos();
			Assert.IsTrue(iGestorPrestamos.EsValida(iSolicitudPrestamo));
		}

		[TestMethod]
		public void EsValida_WithCliente_MontoMayor_ReturnsFalse()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 32;
			double iMonto = 150000;
			double iSueldo = 5500;
			DateTime iFechaNac = new DateTime(1993, 07, 11);
			DateTime iFechaIng = new DateTime(2014, 03, 14);

			Empleo iEmpleo = new Empleo(iSueldo, iFechaIng);
			Cliente iCliente = new Cliente(iNombre, iApellido, iFechaNac, iEmpleo);
			iCliente.TipoCliente = TipoCliente.Cliente;
			SolicitudPrestamo iSolicitudPrestamo = new SolicitudPrestamo(iCliente, iMonto, iCantidadCuotas);

			GestorPrestamos iGestorPrestamos = new GestorPrestamos();
			Assert.IsFalse(iGestorPrestamos.EsValida(iSolicitudPrestamo));
		}

		[TestMethod]
		public void EsValida_WithCliente_MontoMenor_ReturnsTrue()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 32;
			double iMonto = 100000;
			double iSueldo = 5500;
			DateTime iFechaNac = new DateTime(1993, 07, 11);
			DateTime iFechaIng = new DateTime(2014, 03, 14);

			Empleo iEmpleo = new Empleo(iSueldo, iFechaIng);
			Cliente iCliente = new Cliente(iNombre, iApellido, iFechaNac, iEmpleo);
			iCliente.TipoCliente = TipoCliente.Cliente;
			SolicitudPrestamo iSolicitudPrestamo = new SolicitudPrestamo(iCliente, iMonto, iCantidadCuotas);

			GestorPrestamos iGestorPrestamos = new GestorPrestamos();
			Assert.IsTrue(iGestorPrestamos.EsValida(iSolicitudPrestamo));
		}


		[TestMethod]
		public void EsValida_WithClienteGold_MontoMayor_ReturnsFalse()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 60;
			double iMonto = 200000;
			double iSueldo = 5500;
			DateTime iFechaNac = new DateTime(1993, 07, 11);
			DateTime iFechaIng = new DateTime(2014, 03, 14);

			Empleo iEmpleo = new Empleo(iSueldo, iFechaIng);
			Cliente iCliente = new Cliente(iNombre, iApellido, iFechaNac, iEmpleo);
			iCliente.TipoCliente = TipoCliente.ClienteGold;
			SolicitudPrestamo iSolicitudPrestamo = new SolicitudPrestamo(iCliente, iMonto, iCantidadCuotas);

			GestorPrestamos iGestorPrestamos = new GestorPrestamos();
			Assert.IsFalse(iGestorPrestamos.EsValida(iSolicitudPrestamo));
		}

		[TestMethod]
		public void EsValida_WithClienteGold_MontoMenor_ReturnsTrue()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 60;
			double iMonto = 150000;
			double iSueldo = 5500;
			DateTime iFechaNac = new DateTime(1993, 07, 11);
			DateTime iFechaIng = new DateTime(2014, 03, 14);

			Empleo iEmpleo = new Empleo(iSueldo, iFechaIng);
			Cliente iCliente = new Cliente(iNombre, iApellido, iFechaNac, iEmpleo);
			iCliente.TipoCliente = TipoCliente.ClienteGold;
			SolicitudPrestamo iSolicitudPrestamo = new SolicitudPrestamo(iCliente, iMonto, iCantidadCuotas);

			GestorPrestamos iGestorPrestamos = new GestorPrestamos();
			Assert.IsTrue(iGestorPrestamos.EsValida(iSolicitudPrestamo));
		}


		[TestMethod]
		public void EsValida_WithClientePlatinum_MontoMayor_ReturnsFalse()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 60;
			double iMonto = 300000;
			double iSueldo = 5500;
			DateTime iFechaNac = new DateTime(1993, 07, 11);
			DateTime iFechaIng = new DateTime(2014, 03, 14);

			Empleo iEmpleo = new Empleo(iSueldo, iFechaIng);
			Cliente iCliente = new Cliente(iNombre, iApellido, iFechaNac, iEmpleo);
			iCliente.TipoCliente = TipoCliente.ClientePlatinum;
			SolicitudPrestamo iSolicitudPrestamo = new SolicitudPrestamo(iCliente, iMonto, iCantidadCuotas);

			GestorPrestamos iGestorPrestamos = new GestorPrestamos();
			Assert.IsFalse(iGestorPrestamos.EsValida(iSolicitudPrestamo));
		}

		[TestMethod]
		public void EsValida_WithClientePlatinum_MontoMenor_ReturnsTrue()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 60;
			double iMonto = 200000;
			double iSueldo = 5500;
			DateTime iFechaNac = new DateTime(1993, 07, 11);
			DateTime iFechaIng = new DateTime(2014, 03, 14);

			Empleo iEmpleo = new Empleo(iSueldo, iFechaIng);
			Cliente iCliente = new Cliente(iNombre, iApellido, iFechaNac, iEmpleo);
			iCliente.TipoCliente = TipoCliente.ClientePlatinum;
			SolicitudPrestamo iSolicitudPrestamo = new SolicitudPrestamo(iCliente, iMonto, iCantidadCuotas);

			GestorPrestamos iGestorPrestamos = new GestorPrestamos();
			Assert.IsTrue(iGestorPrestamos.EsValida(iSolicitudPrestamo));
		}
	}
}
