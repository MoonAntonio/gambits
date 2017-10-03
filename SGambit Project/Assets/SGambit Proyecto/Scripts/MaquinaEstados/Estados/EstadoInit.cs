//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EstadoInit.cs (29/09/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estado inicial												\\
// Fecha Mod:		29/09/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio
{
	/// <summary>
	/// <para>Estado inicial</para>
	/// </summary>
	public class EstadoInit : Estado 
	{
		#region Constructor
		public EstadoInit(MaquinaEstados obj) : base(obj)
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
			Maquina.CambiarEstado(new EstadoEsperandoTurno(Maquina));
		}

		public override void Salir()
		{
			Debug.Log("Saliendo de Init");
		}
		#endregion
	}
}