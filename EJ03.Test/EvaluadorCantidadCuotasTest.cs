using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EJ03.Test
{
	[TestClass]
	public class EvaluadorCantidadCuotasTest
	{
		[TestMethod]
		public void EsValida_WithNoCliente_CuotasMayores_ReturnsFalse()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 13;
			double iMonto = 20000;
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
		public void EsValida_WithNoCliente_CuotasMenores_ReturnsTrue()
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
		public void EsValida_WithCliente_CuotasMayores_ReturnsFalse()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 33;
			double iMonto = 20000;
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
		public void EsValida_WithCliente_CuotasMenores_ReturnsTrue()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 32;
			double iMonto = 20000;
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
		public void EsValida_WithClienteGold_CuotasMayores_ReturnsFalse()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 61;
			double iMonto = 20000;
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
		public void EsValida_WithClienteGold_CuotasMenores_ReturnsTrue()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 60;
			double iMonto = 20000;
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
		public void EsValida_WithClientePlatinum_CuotasMayores_ReturnsFalse()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 61;
			double iMonto = 20000;
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
		public void EsValida_WithClientePlatinum_CuotasMenores_ReturnsTrue()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 60;
			double iMonto = 20000;
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
