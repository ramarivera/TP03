using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
	/// <summary>
	/// Representa un Evaluador de Solicitudes, este en particular verifica la edad del solicitante.
	/// </summary>
	public class EvaluadorEdad : IEvaluador
    {
		/// <summary>
		/// Edad maxima para solicitar un prestamo
		/// </summary>
        private int iEdadMinima;

		/// <summary>
		/// Edad minima para solicitar un prestamo
		/// </summary>
        private int iEdadMaxima;

		/// <summary>
        /// Inicializa una nueva instancia de <see cref="EvaluadorEdad"/>
		/// </summary>
		/// <param name="pEdadMinima"></param>
		/// <param name="pEdadMaxima"></param>
        public EvaluadorEdad(int pEdadMinima, int pEdadMaxima)
        {
            this.iEdadMinima = pEdadMinima;
            this.iEdadMaxima = pEdadMaxima;
        }

		/// <summary>
		/// Evalua si la edad del solicitante esta dentro de los parametros validos
		/// </summary>
		/// <param name="pSolicitud">Solicitud a Evaluar</param>
		/// <returns>Verdadero si la solicitud es valida, falso caso contrario</returns>
        bool IEvaluador.EsValida(SolicitudPrestamo pSolicitud)
        {
            int edad = ((DateTime.Today - pSolicitud.Cliente.FechaNacimiento).Days) / 365;
            return ((iEdadMinima <= edad) && (iEdadMaxima >= edad));
        }
    }
}
