using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
	/// <summary>
	/// Representa un Gestor de Prestamos, el cual maneja el flujo de las evaluaciones de las solicitudes
	/// </summary>
	public class GestorPrestamos
    {
		/// <summary>
		/// Diccionario donde se guardan los evaluadores (Value) segun el tipo de cliente (Key)
		/// </summary>
        private IDictionary<TipoCliente, IEvaluador> iEvaluadoresPorCliente;
		/// <summary>
		/// Propiedad EvaluadoresPorCliente
		/// </summary>
		private IDictionary<TipoCliente, IEvaluador> EvaluadoresPorCliente
		{
			get { return this.iEvaluadoresPorCliente;}
			set { this.iEvaluadoresPorCliente = value; }
		}
		/// <summary>
        /// Inicializa una nueva instancia de <see cref="GestorPrestamos"/>.Inicializa tambien los evaluadores correspondientes
		/// </summary>
        public GestorPrestamos()
        {
            EvaluadoresPorCliente = new Dictionary<TipoCliente, IEvaluador>();
			EvaluadoresPorCliente[TipoCliente.NoCliente] = InicializarEvaluadorNoCliente();
			EvaluadoresPorCliente[TipoCliente.Cliente] = InicializarEvaluadorCliente();
			EvaluadoresPorCliente[TipoCliente.ClienteGold] = InicializarEvaluadorClienteGold();
			EvaluadoresPorCliente[TipoCliente.ClientePlatinum] = InicializarEvaluadorClientePlatinum();
		}

		/// <summary>
		/// Inicializa el Evaluador de No Clientes  con los valores por defecto
		/// </summary>
		/// <returns>Evaluador para No Clientes </returns>
		private EvaluadorCompuesto InicializarEvaluadorNoCliente()
		{
			EvaluadorCompuesto iEvalComp = new EvaluadorCompuesto();
			iEvalComp.AgregarEvaluador(new EvaluadorEdad(18, 75));
			iEvalComp.AgregarEvaluador(new EvaluadorAntiguedadLaboral(6));
			iEvalComp.AgregarEvaluador(new EvaluadorSueldo(5000));
			iEvalComp.AgregarEvaluador(new EvaluadorMonto(20000));
			iEvalComp.AgregarEvaluador(new EvaluadorCantidadCuotas(12));
			return iEvalComp;
		}

		/// <summary>
		/// Inicializa el Evaluador de Clientes  con los valores por defecto
		/// </summary>
		/// <returns>Evaluador para Clientes </returns>
		private EvaluadorCompuesto InicializarEvaluadorCliente()
		{
			EvaluadorCompuesto iEvalComp = new EvaluadorCompuesto();
			iEvalComp.AgregarEvaluador(new EvaluadorEdad(18, 75));
			iEvalComp.AgregarEvaluador(new EvaluadorAntiguedadLaboral(6));
			iEvalComp.AgregarEvaluador(new EvaluadorSueldo(5000));
			iEvalComp.AgregarEvaluador(new EvaluadorMonto(100000));
			iEvalComp.AgregarEvaluador(new EvaluadorCantidadCuotas(32));
			return iEvalComp;
		}

		/// <summary>
		/// Inicializa el Evaluador de Clientes Gold con los valores por defecto
		/// </summary>
		/// <returns>Evaluador para Clientes Gold</returns>
		private EvaluadorCompuesto InicializarEvaluadorClienteGold()
		{
			EvaluadorCompuesto iEvalComp = new EvaluadorCompuesto();
			iEvalComp.AgregarEvaluador(new EvaluadorEdad(18, 75));
			iEvalComp.AgregarEvaluador(new EvaluadorAntiguedadLaboral(6));
			iEvalComp.AgregarEvaluador(new EvaluadorSueldo(5000));
			iEvalComp.AgregarEvaluador(new EvaluadorMonto(150000));
			iEvalComp.AgregarEvaluador(new EvaluadorCantidadCuotas(60));
			return iEvalComp;

		}

		/// <summary>
		/// Inicializa el Evaluador de Clientes Platinum con los valores por defecto
		/// </summary>
		/// <returns>Evaluador para Clientes Platinum</returns>
		private EvaluadorCompuesto InicializarEvaluadorClientePlatinum()
		{
			EvaluadorCompuesto iEvalComp = new EvaluadorCompuesto();
			iEvalComp.AgregarEvaluador(new EvaluadorEdad(18, 75));
			iEvalComp.AgregarEvaluador(new EvaluadorAntiguedadLaboral(6));
			iEvalComp.AgregarEvaluador(new EvaluadorSueldo(5000));
			iEvalComp.AgregarEvaluador(new EvaluadorMonto(200000));
			iEvalComp.AgregarEvaluador(new EvaluadorCantidadCuotas(60));
			return iEvalComp;
		}
		/// <summary>
		/// Verifica si una solicitud es valida, invocando al evaluador correspondiente segun el tipo de cliente
		/// </summary>
		/// <param name="pSolicitud">Solicitud a evaluar</param>
		/// <returns>Verdadero si la solicitud es valida</returns>
		public bool EsValida(SolicitudPrestamo pSolicitud)
        {
            return EvaluadoresPorCliente[pSolicitud.Cliente.TipoCliente].EsValida(pSolicitud);
        }
    }
}
