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
	/// <para>Manager del sistema	</para>
	/// </summary>
	public class ManagerController : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Lista de unidades</para>
		/// </summary>
		public List<Unidad> unidades = new List<Unidad>();          // Lista de unidades
		/// <summary>
		/// <para>Prefab del boton</para>
		/// </summary>
		public GameObject prefabBtnUnidad;                          // Prefab del boton
		/// <summary>
		/// <para>Root de la UI de las unidades.</para>
		/// </summary>
		public Transform rootUIUnidades;// Root de la UI de las unidades

		public GameObject prefabElemento;

		public List<Transform> rootElementos = new List<Transform>();

		public List<string> Condiciones = new List<string>();

		public List<string> Acciones = new List<string>();

		public List<GameObject> panelesElementos = new List<GameObject>();
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
				// Limpiar listas
				Acciones.Clear();

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
				Acciones = go.GetComponent<Unidad>().magias;

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
				GenerarOpciones(n);

				// Cerrar paneles
				CerrarPaneles();

				Debug.Log("Generada " + go.transform.name);
			}
		}

		public void GenerarOpciones(int id)
		{
			for (int n = 0; n < Acciones.Count; n++)
			{
				// Agregar gambits
				GameObject goEle = Instantiate(prefabElemento);
				goEle.transform.parent = rootElementos[n].transform;

				// Setup Gambit
				Elemento elemento = goEle.GetComponent<Elemento>();
				elemento.estadoElemento = EstadoElemento.ON;
				elemento.txtID.text = id.ToString();
				elemento.dropEstado.value = 0;
				elemento.dropAccion.ClearOptions();
				elemento.dropAccion.AddOptions(Acciones);
				elemento.dropCondicion.ClearOptions();
				elemento.dropCondicion.AddOptions(Condiciones);

				panelesElementos.Add(goEle);
			}
		}

		public void AbrirInterfazUnidad(int n)
		{
			Debug.Log(n);
			CerrarPaneles();
			AbrirPanel(n);
		}

		public void CerrarPaneles()
		{
			foreach (Transform go in rootElementos)
			{
				go.GetComponent<CanvasGroup>().alpha = 0;
			}
		}

		public void AbrirPanel(int id)
		{
			Debug.Log(id);
			rootElementos[id-1].GetComponent<CanvasGroup>().alpha = 1;
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