using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
	/// <summary>
	/// Representa un Evaluador Compuesto, formado por otros elementos IEvaluador
	/// </summary>
	public  class EvaluadorCompuesto : IEvaluador
    {
		/// <summary>
		/// Representa una lista de elementos IEvaluador que forma al evaluador compuesto
		/// </summary>
        private IList<IEvaluador> iEvaluadores;

		/// <summary>
		/// Propiedad Evaluadores, lectura/escritura
		/// </summary>
		private IList<IEvaluador> Evaluadores 
        {
			get { return this.iEvaluadores; }
			set { this.iEvaluadores = value; }
			
		}

		/// <summary>
		/// Constructor de la clase
		/// </summary>
        public EvaluadorCompuesto()
        {
           Evaluadores = new List<IEvaluador>();
        }

		/// <summary>
		/// Agrega un evaluador (individual o compuesto) al evaluador compuesto 
		/// </summary>
		/// <param name="pEvaluador">Evaluador a Agregar</param>
		public void AgregarEvaluador ( IEvaluador pEvaluador)
		{
			Evaluadores.Add(pEvaluador);
		}
		/// <summary>
		/// Verifica si la solicitud es valida segun los distintos evaluadores contenidos
		/// </summary>
		/// <param name="pSolicitud">Solicitud a Evaluar</param>
		/// <returns>Vercadero si la solicitud es valida</returns>
        public bool EsValida(SolicitudPrestamo pSolicitud)
        {
            IEnumerator<IEvaluador> enumerador = Evaluadores.GetEnumerator();
            bool valida = true;
            while (valida && enumerador.MoveNext())
            {
                valida = enumerador.Current.EsValida(pSolicitud);
            }
            return valida;
        }
    }
}
