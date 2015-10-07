using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
    /// <summary>
    /// Representa el Evaluador por Cantidad de Cuotas maximas
    /// </summary>
	public class EvaluadorCantidadCuotas : IEvaluador
    {
        /// <summary>
        /// Representa la cantidad de cuotas maximas para pagar un prestamo
        /// </summary>
        private int iCantidadMaximaCuotas;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="EvaluadorCantidadCuotas"/>
        /// </summary>
        /// <param name="pCantidadMaxima">Cnatidad de cuotas maximas para pagar un prestamo</param>
        public EvaluadorCantidadCuotas(int pCantidadMaxima)
        {
            this.iCantidadMaximaCuotas = pCantidadMaxima;
        }

        /// <summary>
        /// Verifica si la solicitud es valida segun la cantidad de cuotas maximas
        /// </summary>
        /// <param name="pSolicitud">Solicitud a evaluar</param>
        /// <returns>Devuelve verdadero si la solicitud es valida</returns>
        bool IEvaluador.EsValida(SolicitudPrestamo pSolicitud)
        {
            return (pSolicitud.CantidadCuotas <= iCantidadMaximaCuotas);
        }
    }
}
