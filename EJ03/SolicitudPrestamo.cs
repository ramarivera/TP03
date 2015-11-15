using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
	/// <summary>
	/// Representa una solicitud de prestamo
	/// </summary>
	public class SolicitudPrestamo
	{
		/// <summary>
		/// Representa el monto del prestamo solicitado
		/// </summary>
		private double iMonto;

		/// <summary>
		/// Representa la cantidad de cuotas del prestamo solicitado
		/// </summary>
		private int iCantidadCuotas;

		/// <summary>
		/// Representa el Cliente que solicitado el prestamo
		/// </summary>
		private Cliente iCliente;

		/// <summary>
		/// Propiedad Monto, solo lectura
		/// </summary>
		public double Monto
		{
			get { return this.iMonto; }
			private set { this.iMonto = value; }
		}

		/// <summary>
		/// Propiedad CantidadCuotas, solo lectura
		/// </summary>
		public int CantidadCuotas
		{
			get { return this.iCantidadCuotas; }
			private set { this.iCantidadCuotas = value; }
		}

		/// <summary>
		/// Propiedad Cliente, solo lectura
		/// </summary>
		public Cliente Cliente
		{
			get { return this.iCliente; }
			private set { this.iCliente = value; }
		}

		/// <summary>
		/// Inicializa una nueva instancia de <see cref="SolicitudPrestamo"/>
		/// </summary>
		/// <param name="pCliente">Cliente que solicita el prestamo</param>
		/// <param name="pMonto">Monto del prestamo</param>
		/// <param name="pCantidadCuotas">Cantidad de cuotas para pagar el prestamo</param>
		public SolicitudPrestamo(Cliente pCliente, double pMonto, int pCantidadCuotas )
		{
			this.Cliente = pCliente;
			this.Monto = pMonto;
			this.CantidadCuotas = pCantidadCuotas;
		}
	}
}
