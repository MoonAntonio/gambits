//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Elemento.cs (03/10/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base del elemento del gambit							\\
// Fecha Mod:		03/10/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace MoonAntonio
{
	/// <summary>
	/// <para>Clase base del elemento del gambit</para>
	/// </summary>
	public class Elemento : MonoBehaviour 
	{
		#region Variables Publicas
		public Image clrImagen;
		public Text txtID;
		public Dropdown dropEstado;
		public Dropdown dropCondicion;
		public Dropdown dropAccion;
		public EstadoElemento estadoElemento = EstadoElemento.ON;
		#endregion

		#region Variables Privadas
		private Color clrON = new Color(51, 255, 0, 255);
		private Color clrOFF = new Color(255, 0, 0, 255);
		
		#endregion
	}

	public enum EstadoElemento
	{
		ON,
		OFF
	}
}