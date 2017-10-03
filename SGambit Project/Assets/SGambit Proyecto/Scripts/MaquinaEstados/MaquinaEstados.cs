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
using System.Collections.Generic;
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
		public Estado estadoActual;									// Estado actual
		/// <summary>
		/// <para>Lista de unidades</para>
		/// </summary>
		public List<Unidad> unidades = new List<Unidad>();			// Lista de unidades
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializa <see cref="MaquinaEstados"/>.</para>
		/// </summary>
		private void Start()// Inicializa MaquinaEstados
		{
			GameObject go = Instantiate(new GameObject());
			go.transform.name = "Unidades";
			go.transform.parent = this.transform;
			GenerarUnidades(go.transform);
		}
		#endregion

		#region Actualizador
		/// <summary>
		/// <para>Actualizador de <see cref="MaquinaEstados"/>.</para>
		/// </summary>
		private void Update()// Actualizador de MaquinaEstados
		{
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

		#region Funcionalidad
		/// <summary>
		/// <para>Genera unidades aleatoriamente</para>
		/// </summary>
		/// <param name="root">Root de las unidades</param>
		private void GenerarUnidades(Transform root)// Genera unidades aleatoriamente
		{

		}
		#endregion
	}
}