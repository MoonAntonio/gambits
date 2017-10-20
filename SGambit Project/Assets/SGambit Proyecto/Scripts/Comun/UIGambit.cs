//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// UIGambit.cs (19/10/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		UI control del gambits										\\
// Fecha Mod:		19/10/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
#endregion

namespace MoonAntonio
{
	public class UIGambit : MonoBehaviour
	{
		#region Variables Publicas
		public int prioridad;
		public string condicion;
		public string accion;
		public Text txtPrioridad;
		public Dropdown dropCondicion;
		public Dropdown dropAccion;
		public List<string> listaCondiciones = new List<string>();
		public List<string> listaAcciones = new List<string>();
		#endregion

		#region Inicializadores
		public void Start()
		{
			txtPrioridad.text = prioridad.ToString();
			dropCondicion.AddOptions(listaCondiciones);
			dropAccion.AddOptions(listaAcciones);

			dropCondicion.value = 0;
			dropAccion.value = 0;
		}
		#endregion
	}
}
