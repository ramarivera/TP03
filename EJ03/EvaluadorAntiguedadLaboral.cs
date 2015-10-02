using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
    /// <summary>
    /// Representa el Evaluador por Antiguedad Laboral del Cliente
    /// </summary>
	public class EvaluadorAntiguedadLaboral : IEvaluador
    {
        /// <summary>
        /// Representa la antiguedad minima para poder pedir un prestamo
        /// </summary>
        private int iAntiguedadMinima;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="pAntiguedadMinima">Antiguedad minima para poder pedir un prestamo</param>
        public EvaluadorAntiguedadLaboral(int pAntiguedadMinima)
        {
            this.iAntiguedadMinima = pAntiguedadMinima;
        }

        /// <summary>
        /// Verifica si una solicitud es valida segun la antiguedad del Cliente
        /// </summary>
        /// <param name="pSolicitud">Solicitud a evaluar</param>
        /// <returns>Devuelve verdadero si la solicitud es valida</returns>
        bool IEvaluador.EsValida(SolicitudPrestamo pSolicitud)
        {
            int antiguedad = Math.Abs((DateTime.Today.Month - pSolicitud.Cliente.Empleo.FechaIngreso.Month) + 12 * (DateTime.Today.Year - pSolicitud.Cliente.Empleo.FechaIngreso.Year));
            return antiguedad >= this.iAntiguedadMinima;
        } 
    }
}
