using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
    /// <summary>
    /// Representa el Evaluador por el sueldo que percibe el Cliente
    /// </summary>
	public class EvaluadorSueldo:IEvaluador
    {
        /// <summary>
        /// Representa el sueldo minimo que debe percibir un Cliente para solicitar un prestamo
        /// </summary>
        private double iSueldoMinimo;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="pSueldoMinimo">Sueldo minimo que debe percibir un Cliente</param>
        public EvaluadorSueldo(double pSueldoMinimo)
        {
            this.iSueldoMinimo = pSueldoMinimo;
        }

        /// <summary>
        /// Verifica si la solicitud es valida segun el sueldo que percibe el Cliente
        /// </summary>
        /// <param name="pSolicitud">Solicitud a evaluar</param>
        /// <returns>Devuelve verdadero si la solicitud es valida</returns>
        bool IEvaluador.EsValida(SolicitudPrestamo pSolicitud)
        {
            return (pSolicitud.Cliente.Empleo.Sueldo > iSueldoMinimo);
        }
    }
}
