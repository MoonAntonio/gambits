//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EstadoEsperandoTurno.cs (29/09/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estado esperando turno										\\
// Fecha Mod:		29/09/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio
{
	/// <summary>
	/// <para>Estado esperando turno</para>
	/// </summary>
	public class EstadoEsperandoTurno : Estado 
	{
		#region Constructor
		public EstadoEsperandoTurno(MaquinaEstados obj) : base(obj)
		{

		}
		#endregion

		#region Eventos
		public override void Entrar()
		{
			Debug.Log(Maquina.name + " Esperando turno");
		}

		public override void Ejecutando()
		{
			Maquina.unidad.Cuenta++;

			if (Maquina.unidad.Cuenta >= Maquina.unidad.CuentaMax)
			{
				Maquina.CambiarEstado(new EstadoComprobarGambit(Maquina));
			}
		}

		public override void Salir()
		{
			Debug.Log(Maquina.name + " Saliendo de Esperando Turno");
		}
		#endregion
	}
}