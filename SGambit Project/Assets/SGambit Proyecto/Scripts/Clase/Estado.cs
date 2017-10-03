//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Estado.cs (29/09/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base de estado										\\
// Fecha Mod:		29/09/2017													\\
// Ultima Mod:																	\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio
{
	[System.Serializable]
	/// <summary>
	/// <para>Clase base de estado</para>
	/// </summary>
	public class Estado : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Maquina de estados</para>
		/// </summary>
		public MaquinaEstados Maquina;						// Maquina de estados
		#endregion

		#region Constructor
		/// <summary>
		/// <para>Constructor de <see cref="Estado"/>.</para>
		/// </summary>
		/// <param name="obj">Maquina de estados</param>
		public Estado(MaquinaEstados obj)// Constructor de Estado
		{
			Maquina = obj;
		}
		#endregion

		#region Metodos Eventos
		public virtual void Entrar() { }
		public virtual void Salir() { }
		#endregion
	}
}