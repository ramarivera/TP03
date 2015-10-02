using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
    /// <summary>
    /// Clase Interfaz IEvaluador
    /// </summary>
    public interface IEvaluador
    {
        /// <summary>
        /// Verifica si una solicitud es valida
        /// </summary>
        /// <param name="pSolicitud">Solicitud a evaluar</param>
        /// <returns>Devuelve verdadero si la solicitud es valida</returns>
        bool EsValida(SolicitudPrestamo pSolicitud);
    }
}
