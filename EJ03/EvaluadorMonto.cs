using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
    /// <summary>
    /// Representa el Evalular por el monto del prestamo solicitado
    /// </summary>
	public class EvaluadorMonto:IEvaluador
    {
        /// <summary>
        /// Representa el monto maximo que puede tener el prestamo
        /// </summary>
        private double iMontoMaximo;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="pMontoMaximo">Monto maximo que puede tener el prestamo</param>
        public EvaluadorMonto(double pMontoMaximo)
        {
            this.iMontoMaximo = pMontoMaximo;
        }

        /// <summary>
        /// Verifica si la solicitud es valida segun el monto indicado
        /// </summary>
        /// <param name="pSolicitud">Solicitud a evaluar</param>
        /// <returns>Devuelve verdadero si la solicitud es valida</returns>
        bool IEvaluador.EsValida(SolicitudPrestamo pSolicitud)
        {
            return (pSolicitud.Monto <= iMontoMaximo); 
        }
    }
}
