using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ03
{
	/// <summary>
	/// Representa un Cliente del banco
	/// </summary>
	public  class Cliente
    {
		/// <summary>
		/// Reprensenta el Nombre del Cliente
		/// </summary>
        private string iNombre;

		/// <summary>
		/// Representa el Apellido del Cliente
		/// </summary>
        private string iApellido;

		/// <summary>
		/// Representa la Fecha de Nacimiento del Cliente
		/// </summary>
        private DateTime iFechaNacimiento;

		/// <summary>
		/// Representa el tipo de Cliente de cada instancia de Cliente
		/// </summary>
        private TipoCliente iTipoCliente;

		/// <summary>
		/// Reprensenta el empleo de un Cliente
		/// </summary>
        private Empleo iEmpleo;

		/// <summary>
		/// Propiedad Nombre, solo lectura
		/// </summary>
        public string Nombre
        {
            get { return this.iNombre; }
            private set { this.iNombre = value; }
        }

		/// <summary>
        /// Propiedad Apellido, solo lectura 
		/// </summary>
        public string Apellido
        {
            get { return this.iApellido; }
            private set { this.iApellido = value; }
        }

		/// <summary>
        /// Propiedad FechaNacimiento, solo lectura
		/// </summary>
        public DateTime FechaNacimiento
        {
            get { return this.iFechaNacimiento; }
            private set { this.iFechaNacimiento = value; }
        }

		/// <summary>
        /// Propiedad Nombre, lectura/escritura
		/// </summary>
        public TipoCliente TipoCliente
        {
            get { return this.iTipoCliente; }
            set {this.iTipoCliente = value;}
        }

		/// <summary>
        /// Propiedad Empleo, solo lectura 
		/// </summary>
        public Empleo Empleo
        {
            get { return this.iEmpleo; }
            private set { this.iEmpleo = value; }
        }

		/// <summary>
        /// Inicializa una nueva instancia de <see cref="Cliente"/>
		/// </summary>
		/// <param name="pNombre">Nombre del Cliente</param>
		/// <param name="pApellido">Apellido del Cliente</param>
		/// <param name="pFechaNacimiento">Fecha de Nacimiento del Cliente</param>
		/// <param name="pEmpleo">Empleo del Cliente</param>
        public Cliente(string pNombre, string pApellido, DateTime pFechaNacimiento, Empleo pEmpleo)
        {
            this.Nombre = pNombre;
            this.Apellido = pApellido;
            this.FechaNacimiento = pFechaNacimiento;
            this.Empleo = pEmpleo;
			this.TipoCliente = TipoCliente.NoCliente;
        }
    }
}
