using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
    /// <summary>
    /// Representa un Empleo de un Cliente
    /// </summary>
	public  class Empleo
    {
        /// <summary>
        /// Representa el sueldo del Empleo
        /// </summary>
        private double iSueldo;

        /// <summary>
        /// Representa la fecha de ingreso al Empleo
        /// </summary>
        private DateTime iFechaIngreso;

        /// <summary>
        /// Propiedad Sueldo, solo lectura
        /// </summary>
        public double Sueldo
        {
            get { return this.iSueldo;}
            private set { this.iSueldo = value;}
        }

        /// <summary>
        /// Propiedad FechaIngreso, solo lectura
        /// </summary>
        public DateTime FechaIngreso
        {
            get { return this.iFechaIngreso; }
            private set { this.iFechaIngreso = value; }
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="pSueldo">Sueldo del Empleo</param>
        /// <param name="pFechaIngreso">Fecha de Ingreso al Empleo</param>
        public Empleo(double pSueldo, DateTime pFechaIngreso)
        {
            this.Sueldo = pSueldo;
            this.FechaIngreso = pFechaIngreso;
        }
    }
}
