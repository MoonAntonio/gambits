//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EstadoRealizarAccion.cs (29/09/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estado para realizar la accion								\\
// Fecha Mod:		29/09/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio
{
	/// <summary>
	/// <para>Estado para realizar la accion</para>
	/// </summary>
	public class EstadoRealizarAccion : Estado 
	{
		#region Constructor
		public EstadoRealizarAccion(MaquinaEstados obj) : base(obj)
		{

		}
		#endregion

		#region Eventos
		public override void Entrar()
		{
			Debug.Log(Maquina.name + " Iniciando");

		}

		public override void Ejecutando()
		{
			Debug.Log(Maquina.name + " Iniciado");
		}

		public override void Salir()
		{
			Debug.Log("Saliendo de Init");
		}
		#endregion
	}
}