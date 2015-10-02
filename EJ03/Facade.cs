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
		/// Abstrae la creacion de un Gestor de Prestamos
		/// </summary>
		/// <returns>GestorPrestamos Inicializado con los valores por defecto</returns>
		public GestorPrestamos CrearGestor()
		{
			return (new GestorPrestamos());
		}
		/// <summary>
		/// Abstrae la creacion de un Empleo
		/// </summary>
		/// <param name="pSueldo">Sueldo del Empleo</param>
		/// <param name="pFechaIngreso">Fecha de Ingreso al Empleo</param>
		/// <returns>Instancia de Empleo con los datos correspondientes</returns>
		public Empleo CrearEmpleo(double pSueldo, DateTime pFechaIngreso)
		{
			return (new Empleo( pSueldo, pFechaIngreso));
		}
		/// <summary>
		/// Abstrae la creacion de un cliente
		/// </summary>
		/// <param name="pNombre">Nombre del Cliente</param>
		/// <param name="pApellido">Apellido del Cliente</param>
		/// <param name="pFechaNacimiento">Fecha de Nacimiento del Cliente</param>
		/// <param name="pEmpleo">Empleo del Cliente</param>
		/// <param name="pTipoCliente">Tipo del nuevo Cliente</param>
		/// <returns>Instancia de Cliente con los datos correspondientes</returns>
		public Cliente CrearCliente(string pNombre, string pApellido, DateTime pFechaNacimiento, Empleo pEmpleo, TipoCliente pTipoCliente)
		{
			Cliente iCliente = new Cliente(pNombre, pApellido, pFechaNacimiento, pEmpleo);
			iCliente.TipoCliente = pTipoCliente;
			return iCliente;
		}
		/// <summary>
		/// Abstrae la creacion de una solicitud de Prestamo
		/// </summary>
		/// <param name="pCliente">Cliente que solicita el prestamo</param>
		/// <param name="pMonto">Monto del prestamo solicitado</param>
		/// <param name="pCantidadCuotas">Numero de cuotas en las cuales se debera cancelar el prestamo</param>
		/// <returns>Instancia de Solicitud Prestamo con los datos correspondientes</returns>
		public SolicitudPrestamo CrearSolicitudPrestamo(Cliente pCliente, double pMonto, int pCantidadCuotas)
		{
			return new SolicitudPrestamo(pCliente, pMonto, pCantidadCuotas);
        }
		/// <summary>
		/// Permite obtener la validacion de una solicitud, indicando que gestor se encargara de realizar la misma
		/// </summary>
		/// <param name="pGestor">Gestor que se encargara de validar la solicitud</param>
		/// <param name="pSolicitud">Solicutd que se desea validar</param>
		/// <returns>Verdadero si la solicitud es validad</returns>
		public bool ValidarSolicitud(GestorPrestamos pGestor, SolicitudPrestamo pSolicitud)
		{
			return pGestor.EsValida(pSolicitud);
		}
	}
}
