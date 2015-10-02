using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EJ03;

namespace EJ03.Test01
{
	[TestClass]
	public class GestorPrestamosTest
	{
		[TestMethod]
		[Description("La solicitud es correcta para un NoCliente")]
		public void SolicitudValidaNocliente()
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
		[Description("La solicitud es correcta para un Cliente")]
		public void SolicitudValidaCliente()
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
		[Description("La solicitud es correcta para un Cliente Gold")]
		public void SolicitudValidaClienteGold()
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
		[Description("La solicitud es correcta para un Cliente Platinum")]
		public void SolicitudValidaClientePlatinum()
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
		[TestMethod]
		[Description("La solicitud es correcta para un Cliente Platinum")]
		public void SolicitudNoValidaClientePlatinum()
		{
			string iNombre = "Ramiro";
			string iApellido = "Rivera";
			int iCantidadCuotas = 60;
			double iMonto = 200001;
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
		[Description("El numero de cuotas es mayor al permitido para el NoCliente")]
		public void EvaluadorCantidadCuotasFalso()
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
		[Description("El monto es mayor al permitido para el NoCliente")]
		public void EvaluadorMontoFalso()
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
		[Description("La antiguedad es menor a la minima")]
		public void EvaluadorAntiguedadLaboralFalso()
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
		[Description("La edad es menor a la minima")]
		public void EvaluadorEdadFalso()
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
		[Description("El sueldo es menor al minimo")]
		public void EvaluadorSueldoFalso()
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

	}
}
