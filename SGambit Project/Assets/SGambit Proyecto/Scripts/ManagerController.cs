//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ManagerController.cs (29/09/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Manager del sistema											\\
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
	/// <para>Manager del sistema	</para>
	/// </summary>
	public class ManagerController : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Lista de unidades</para>
		/// </summary>
		public List<Unidad> unidades = new List<Unidad>();          // Lista de unidades
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializa <see cref="MaquinaEstados"/>.</para>
		/// </summary>
		private void Start()// Inicializa MaquinaEstados
		{
			// Generar root de unidades
			GameObject go = Instantiate(new GameObject());
			go.transform.name = "Unidades";
			go.transform.parent = this.transform;

			// Generar unidades
			GenerarUnidades(go.transform);
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Genera unidades aleatoriamente</para>
		/// </summary>
		/// <param name="root">Root de las unidades</param>
		private void GenerarUnidades(Transform root)// Genera unidades aleatoriamente
		{
			// Obtener unidades totales del escenario
			int unidadesTotales = Random.Range(2, 10);

			Debug.Log("Unidades en Stock: " + unidadesTotales);

			// Generar unidades
			for (int n = 0; n < unidadesTotales; n++)
			{
				// Instanciacion
				GameObject go = Instantiate(new GameObject());
				go.transform.name = "Unidad" + n;
				go.transform.parent = root;
				go.AddComponent<MaquinaEstados>();
				go.AddComponent<Unidad>();

				// Generar stats
				go.GetComponent<Unidad>().VidaMax = Random.Range(10, 20);
				go.GetComponent<Unidad>().VidaActual = go.GetComponent<Unidad>().VidaMax;
				go.GetComponent<Unidad>().ManaMax = Random.Range(10, 20);
				go.GetComponent<Unidad>().ManaActual = go.GetComponent<Unidad>().ManaMax;
				go.GetComponent<Unidad>().Ataque = Random.Range(2, 4);
				go.GetComponent<Unidad>().IsEnvenenado = false;
				go.GetComponent<Unidad>().CuentaMax = Random.Range(3, 8);
				go.GetComponent<Unidad>().Cuenta = 0;

				// Generar Magias
				go.GetComponent<Unidad>().magias = GetMagias(Random.Range(0, 4));

				// Agregar a la lista
				unidades.Add(go.GetComponent<Unidad>());

				Debug.Log("Generada " + go.transform.name);
			}
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Obtiene las magias de la unidad.</para>
		/// </summary>
		/// <param name="id">Id</param>
		/// <returns></returns>
		private List<string> GetMagias(int id)// Obtiene las magias de la unidad
		{
			// Lista de magias
			List<string> mag = new List<string>();

			// Procesar id
			switch (id)
			{
				case 0:
					mag.Add("Atacar");
					return mag;

				case 1:
					mag.Add("Atacar");
					mag.Add("Cura");
					return mag;

				case 2:
					mag.Add("Atacar");
					mag.Add("Cura");
					mag.Add("Veneno");
					return mag;

				case 3:
					mag.Add("Atacar");
					mag.Add("Cura");
					mag.Add("Veneno");
					mag.Add("Concentracion");
					return mag;

				case 4:
					mag.Add("Atacar");
					mag.Add("Cura");
					mag.Add("Veneno");
					mag.Add("Concentracion");
					mag.Add("Prisa");
					return mag;

				default:
					mag.Add("Atacar");
					mag.Add("Cura");
					mag.Add("Veneno");
					mag.Add("Concentracion");
					return mag;
			}
		}
		#endregion
	}
}