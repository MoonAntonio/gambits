//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EstadoComprobarGambit.cs (29/09/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estado comprobar gambit										\\
// Fecha Mod:		29/09/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio
{
	/// <summary>
	/// <para>Estado comprobar gambit</para>
	/// </summary>
	public class EstadoComprobarGambit : Estado 
	{
		#region Constructor
		public EstadoComprobarGambit(MaquinaEstados obj) : base(obj)
		{

		}
		#endregion

		#region Eventos
		public override void Entrar()
		{
			Debug.Log(Maquina.name + " Comprobando gambits");

		}

		public override void Ejecutando()
		{
			//this.gameObject.GetComponent<Unidad>().gambits;
		}

		public override void Salir()
		{
			Debug.Log("Saliendo de la comprobacion");
		}
		#endregion
	}
}