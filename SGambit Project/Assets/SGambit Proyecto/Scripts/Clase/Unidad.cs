//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Unidad.cs (29/09/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base de Unidad										\\
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
	/// <para>Clase base de Unidad</para>
	/// </summary>
	public class Unidad : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Magias de la unidad</para>
		/// </summary>
		public List<string> magias = new List<string>();			// Magias de la unidad
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Vida maxima de la unidad.</para>
		/// </summary>
		private float vidaMax;										// Vida maxima de la unidad
		/// <summary>
		/// <para>Vida Actual de la unidad.</para>
		/// </summary>
		private float vidaActual;									// Vida Actual de la unidad
		/// <summary>
		/// <para>Mana maximo de la unidad.</para>
		/// </summary>
		private float manaMax;										// Mana maximo de la unidad
		/// <summary>
		/// <para>Mana actual de la unidad.</para>
		/// </summary>
		private float manaActual;									// Mana actual de la unidad
		/// <summary>
		/// <para>Ataque de la unidad.</para>
		/// </summary>
		private float ataque;										// Ataque de la unidad
		/// <summary>
		/// <para>Determina si la unidad esta envenenada.</para>
		/// </summary>
		private bool isEnvenenado;									// Determina si la unidad esta envenenada
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Vida maxima de la unidad</para>
		/// </summary>
		public float VidaMax
		{
			get { return vidaMax; }
			set { vidaMax = value; }
		}

		/// <summary>
		/// <para>Vida Actual de la unidad</para>
		/// </summary>
		public float VidaActual
		{
			get { return vidaActual; }
			set { vidaActual = value; }
		}

		/// <summary>
		/// <para>Mana maximo de la unidad</para>
		/// </summary>
		public float ManaMax
		{
			get { return manaMax; }
			set { manaMax = value; }
		}

		/// <summary>
		/// <para>Mana actual de la unidad</para>
		/// </summary>
		public float ManaActual
		{
			get { return manaActual; }
			set { manaActual = value; }
		}

		/// <summary>
		/// <para>Ataque de la unidad</para>
		/// </summary>
		public float Ataque
		{
			get { return ataque; }
			set { ataque = value; }
		}

		/// <summary>
		/// <para>Determina si la unidad esta envenenada</para>
		/// </summary>
		public bool IsEnvenenado
		{
			get { return isEnvenenado; }
			set { isEnvenenado = value; }
		}
		#endregion
	}
}