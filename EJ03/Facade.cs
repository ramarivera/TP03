using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
	class Facade
	{
		/// <summary>
		/// Gestor de Prestamos usado para validar solicitudes
		/// </summary>
		private GestorPrestamos iGestorPrestamos;

		/// <summary>
		/// Empleo cargado en la fachada
		/// </summary>
		private Empleo iEmpleo;

		/// <summary>
		/// Cliente cargado en la fachada
		/// </summary>
		private Cliente iCliente;

		/// <summary>
		/// Inicializa una nueva instancia de la class <see cref="Facade"/> .
		/// </summary>
		public Facade ()
		{
			this.iGestorPrestamos = new GestorPrestamos();
		}

		/// <summary>
		/// Carga un <see cref="Empleo"/> para luego usarlo en la validacion de una solicitud de prestamo
		/// </summary>
		/// <param name="pSueldo">Sueldo del Empleo</param>
		/// <param name="pFechaIngreso">Fecha de Ingreso al Empleo</param>
		public void CargarEmpleo(double pSueldo, DateTime pFechaIngreso)
		{
			this.iEmpleo =  (new Empleo( pSueldo, pFechaIngreso));
		}

		/// <summary>
		/// Carga un nuevo <see cref="Cliente"/> para luego usarlo en la validacion de una solicitud de prestamo
		/// </summary>
		/// <param name="pNombre">Nombre del Cliente</param>
		/// <param name="pApellido">Apellido del Cliente</param>
		/// <param name="pFechaNacimiento">Fecha de Nacimiento del Cliente</param>
		/// <param name="pTipoCliente">Tipo del nuevo Cliente</param>
		/// <returns>True si se pudo cargar el cliente, False caso contrario</returns>
		public bool CargarCliente(string pNombre, string pApellido, DateTime pFechaNacimiento, String pTipoCliente)
		{
			bool lResult = true;

			if (this.iEmpleo == null)
			{
				lResult = false;
			}
			else
			{
				TipoCliente lTipo;
				this.iCliente = new Cliente(pNombre, pApellido, pFechaNacimiento, this.iEmpleo);

				if (Enum.TryParse(pTipoCliente.Replace(" ", String.Empty), out lTipo))
				{
					this.iCliente.TipoCliente = lTipo;
				}
				else
				{
					lResult = false;
				}
			}
			

			return lResult;
		}

		/// <summary>
		///  Valida una <see cref="SolicitudPrestamo"/>
		/// </summary>
		/// <param name="pMonto">Monto del prestamo solicitado</param>
		/// <param name="pCantidadCuotas">Numero de cuotas en las cuales se debera cancelar el prestamo</param>
		/// <returns>True si la solicitud es valida, False caso contrario</returns>
		public bool ValidarSolicitudPrestamo (double pMonto, int pCantidadCuotas)
		{
			SolicitudPrestamo lSolicitud = new SolicitudPrestamo(this.iCliente, pMonto, pCantidadCuotas);
			return (this.iGestorPrestamos.EsValida(lSolicitud));
		}

		/// <summary>
		/// Obteners the nombre cuentas.
		/// </summary>
		/// <returns></returns>
		public List<String> ObtenerNombreCuentas()
		{
			return new List<string>() { "No Cliente", "Cliente", "Cliente Gold", "Cliente Platinum" };
		}
	}
}
