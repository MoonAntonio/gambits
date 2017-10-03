//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MaquinaEstados.cs (29/09/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Maquina de estados											\\
// Fecha Mod:		29/09/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio
{
	/// <summary>
	/// <para>Maquina de estados</para>
	/// </summary>
	public class MaquinaEstados : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Estado anterior</para>
		/// </summary>
		public Estado estadoAnterior;								// Estado anterior
		/// <summary>
		/// <para>Estado actual</para>
		/// </summary>
		public Estado estadoActual;                                 // Estado actual
		/// <summary>
		/// <para>Unidad</para>
		/// </summary>
		public Unidad unidad;										// Unidad
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializa <see cref="MaquinaEstados"/>.</para>
		/// </summary>
		private void Start()// Inicializa MaquinaEstados
		{
			// Inicializar variables
			unidad = this.GetComponent<Unidad>();
			estadoActual = new EstadoInit(this);
		}
		#endregion

		#region Actualizador
		/// <summary>
		/// <para>Actualizador de <see cref="MaquinaEstados"/>.</para>
		/// </summary>
		private void Update()// Actualizador de MaquinaEstados
		{
			unidad.Cuenta++;
			estadoActual.Ejecutando();
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Cambia el estado</para>
		/// </summary>
		/// <param name="newEstado">Nuevo estado</param>
		public void CambiarEstado(Estado newEstado)// Cambia el estado
		{
			estadoAnterior = estadoActual;
			estadoAnterior.Salir();
			estadoActual = newEstado;
			estadoActual.Entrar();
		}
		#endregion
	}
}