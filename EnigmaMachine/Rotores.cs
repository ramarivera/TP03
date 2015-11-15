using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EnigmaMachine
{
	/// <summary>
	/// Representa un conjunto de Rotores, conectados uno al otro.
	/// </summary>
	internal class Rotores
	{
		/// <summary>
		/// Lista de Rotores
		/// </summary>
		private List<Rotor> iRotores;

		/// <summary>
		/// Inicializa una nueva instancia de <see cref="Rotores"/>
		/// </summary>
		public Rotores()
		{
			ListaRotores = new List<Rotor>();
		}

		/// <summary>
		/// Propiedad ListaRotores, Privada
		/// </summary>
		private List<Rotor> ListaRotores
		{
			get { return this.iRotores; }
			set { this.iRotores = value; }
		}

		/// <summary>
		/// Propiedad CantidadRotores, Privada, SoloLectura
		/// </summary>
		private int CantidadRotores
		{
			get { return ListaRotores.Count; }
		}

		/// <summary>
		/// Obtiene el rotor Correspondiente, empezando a contar desde la derecha hacia la izquierda
		/// </summary>
		/// <param name="pNum">Numero de Rotor</param>
		/// <returns>Rotor numero pNum</returns>
		private Rotor RotorNum(int pNum)
		{
			return ListaRotores[pNum - 1];
		}

		/// <summary>
		/// Agrega un rotor
		/// </summary>
		/// <param name="pRotor">Rotor a agregar</param>
		private void AgregarRotor (Rotor pRotor)
		{
			ListaRotores.Add(pRotor);
		}

		/// <summary>
		/// Elimina todos los rotores
		/// </summary>
		private void EliminarRotores()
		{
			ListaRotores.Clear();
		}

		/// <summary>
		/// Simula la mecanica de Giro de los rotores.
		/// Este metodo controla los giros entre los rotores adyacentes, y emula el Double Step
		/// </summary>
		public void Girar ()
		{
			int i = 1;
			bool seguir = true;
			while ((seguir) && (i < CantidadRotores))
			{
				seguir = RotorNum(i).Girar();				// Seguir es verdadero si se encontro una Muesca en el rotor que giro
				if (i!=1)
				{
					RotorNum(i-1).Girar();					// Salvo que el rotor que giro sea el primero, debo hacer girar el rotor a la derecha (Double Step)
				}
				i++;
			}
		}

		/// <summary>
		/// Inicializa los rotores segun el vector
		/// </summary>
		/// <param name="pRotores">Vector que contiene los numeros de rotor a utilizar</param>
		public void Inicializar(int[] pRotores)
		{
			EliminarRotores();
			for (int i = 1; i <= pRotores.Length; i++)
			{
				Rotor lRotor = new Rotor(i);
				AgregarRotor(lRotor);
			}
		}

		/// <summary>
		/// Configura el estado inicial de los anillos de los rotores
		/// </summary>
		/// <param name="pAnillos"></param>
		public void Configurar(char[] pAnillos)
		{
			int i = 0;
			foreach (Rotor lRotor in ListaRotores)
			{
				lRotor.Configurar(pAnillos[i++]);
			}
		}

        public char[] ConfiguracionActual
        {
            get
            {
                char[] lResult = new char[CantidadRotores];
                int i = 0;
                foreach (Rotor lRotor in ListaRotores)
                {
                    lResult[i++] = lRotor.PosicionActual;
                }
                return lResult;
            }
        }
		/// <summary>
		/// Realizo el cifrado de una letra a lo largo de la cadena de rotores
		/// </summary>
		/// <param name="pDerecha">Verdadero si el cifrado es hacia la derecha, falso en caso contrario</param>
		/// <param name="pLetra">Char a Cifrar</param>
		/// <returns>Char cifrado</returns>
		public char Cifrar (bool pDerecha, char pLetra)
		{
			List<Rotor> lLista = pDerecha ? ListaRotores : Enumerable.Reverse(ListaRotores).ToList();	// Si !pDeracha entonces debo recorrer los rotores al reves
			char lResult = pLetra;
			foreach (Rotor lRotor in lLista)
			{
				lResult = lRotor.Cifrar(pDerecha, lResult);
			}
			return lResult;
		}
	}
}
