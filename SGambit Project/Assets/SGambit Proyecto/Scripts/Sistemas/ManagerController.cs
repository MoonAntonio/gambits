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
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;
#endregion

namespace MoonAntonio
{
	/// <summary>
	/// <para>Manager del sistema.</para>
	/// </summary>
	public class ManagerController : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Lista de unidades</para>
		/// </summary>
		public List<Unidad> unidades = new List<Unidad>();				// Lista de unidades
		/// <summary>
		/// <para>Prefab del boton</para>
		/// </summary>
		public GameObject prefabBtnUnidad;                              // Prefab del boton
		/// <summary>
		/// <para>Prefab del contenedor de los gambits.</para>
		/// </summary>
		public GameObject prefabUIContenedor;							// Prefab del contenedor de los gambits
		/// <summary>
		/// <para>Prefab del gambit.</para>
		/// </summary>
		public GameObject prefabUIGambit;                               // Prefab del gambit
		/// <summary>
		/// <para>Root de la UI de las unidades.</para>
		/// </summary>
		public Transform rootUIUnidades;                                // Root de la UI de las unidades
		/// <summary>
		/// <para>Root de la UI del gambit.</para>
		/// </summary>
		public Transform rootUIGambit;									// Root de la UI del gambit
		/// <summary>
		/// <para>Root de la UI de los gambits.</para>
		/// </summary>
		public List<Transform> uiGambits = new List<Transform>();		// Root de la UI de los gambits
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializa <see cref="ManagerController"/>.</para>
		/// </summary>
		private void Start()// Inicializa ManagerController
		{
			// Generar root de unidades
			GameObject go = new GameObject();
			go.transform.parent = this.transform;
			go.transform.name = "Unidades";

			// Generar unidades
			GenerarUnidades(go.transform);
		}
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Abre la interfaz de la unidad.</para>
		/// </summary>
		/// <param name="n">ID de la unidad.</param>
		public void AbrirInterfazUnidad(int n)// Abre la interfaz de la unidad
		{
			Debug.Log(n);
			CerrarPaneles();
			AbrirPanel(n);
		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Genera unidades aleatoriamente</para>
		/// </summary>
		/// <param name="root">Root de las unidades</param>
		private void GenerarUnidades(Transform root)// Genera unidades aleatoriamente
		{
			// Obtener unidades totales del escenario
			int unidadesTotales = Random.Range(2, 10);

			// Generar unidades
			for (int n = 0; n < unidadesTotales; n++)
			{
				// Instanciacion
				GameObject go = new GameObject();
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

				// Agregar UI
				GameObject goUI = Instantiate(prefabBtnUnidad);
				goUI.transform.parent = rootUIUnidades.transform;
				goUI.GetComponentInChildren<Text>().text = go.transform.name;
				goUI.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

				// Agregar evento
				// BUG No aparece en el inspector, pero si se agrega
				goUI.GetComponent<Button>().onClick.AddListener(() => { AbrirInterfazUnidad(n); });

				// Generar Gambits
				GenerarGambits(n);

				// Agregar UI Gambit
				GameObject goGUIContenedor = Instantiate(prefabUIContenedor);
				goGUIContenedor.transform.parent = rootUIGambit.transform;
				goGUIContenedor.name = "Gambit Contenedor " + n;



				// Cerrar paneles
				CerrarPaneles();
			}
		}

		/// <summary>
		/// <para>Genera los gambits de la unidad.</para>
		/// </summary>
		/// <param name="id">ID de la unidad.</param>
		private void GenerarGambits(int id)// Genera los gambits de la unidad
		{
			Unidad uni = unidades[id].GetComponent<Unidad>();
			unidades[id].gameObject.AddComponent<Gambit>();
			float magMax = uni.magias.Count;

			for (int n = 0; n < uni.magias.Count; n++)
			{
				switch (uni.magias[n])
				{
					case "":
						break;
				}
			}
		}

		/// <summary>
		/// <para>Cierra los paneles.</para>
		/// </summary>
		private void CerrarPaneles()// Cierra los paneles
		{
			foreach (Transform go in uiGambits)
			{
				go.GetComponent<CanvasGroup>().alpha = 0;
			}
		}

		/// <summary>
		/// <para>Abre el panel indicado.</para>
		/// </summary>
		/// <param name="id">ID del panel a abrir.</param>
		private void AbrirPanel(int id)// Abre el panel indicado
		{
			uiGambits[id - 1].GetComponent<CanvasGroup>().alpha = 1;
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