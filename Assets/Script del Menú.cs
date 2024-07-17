using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptdelMenú : MonoBehaviour
{
	[SerializeField] public GameObject panel_principal;
	[SerializeField] public GameObject panel_jugar;
	[SerializeField] public GameObject panel_opciones;
	[SerializeField] public GameObject panel_opciones_en_pausa;
	[SerializeField] public Slider volumen_slider;
	[SerializeField] public GameObject panel_pausa;

	[Header("Niveles")]
	public GameObject nivel1;
	public GameObject fps1;
	public GameObject nivel2;
	public GameObject fps2;
	public GameObject nivel3;
	public GameObject fps3;

	// private bool activar_pausa = false;
	private bool estado_pausa = true;
	private GameObject fps;
	private GameObject nivel;

	public void Cambiar_panel (GameObject panel)
	{
		panel_principal.SetActive(false);
		panel_jugar.SetActive(false);
		panel_opciones.SetActive(false);
		panel_opciones_en_pausa.SetActive(false);
		panel_pausa.SetActive(false);
		// activar_pausa = false;

		panel.SetActive(true);
	}

	public void Ajustar_volumen ()
	{
		AudioListener.volume = volumen_slider.value;
		PlayerPrefs.SetFloat("volumenAudio",volumen_slider.value);
	}

	public void Silenciar_volumen ()
	{
		if (AudioListener.volume != 0)
		{
			AudioListener.volume = 0;
			PlayerPrefs.SetFloat("volumenAudio",0);
		}
		else
		{
			AudioListener.volume = 1;
			PlayerPrefs.SetFloat("volumenAudio",1);
		}
	}

	public void Salir ()
	{
		Application.Quit();
	}

	public void Activar_nivel (GameObject aux)
	{
		panel_jugar.SetActive(false);
		nivel = aux;
		nivel.SetActive(true);

		// activar_pausa = true;
	}

	public void Desactivar_nivel ()
	{
		fps.SetActive(true);
		Cambiar_panel(panel_jugar);
		nivel.SetActive(false);
		// activar_pausa = true;
	}

	public void Establecer_fps (GameObject camara)
	{
		fps = camara;
	}

	public void Pausar ()
	{
		estado_pausa = true;
		fps.SetActive(false);
		panel_pausa.SetActive(true);
	}

	public void Renaudar ()
	{
		estado_pausa = false;
		fps.SetActive(true);
		panel_pausa.SetActive(false);
	}

    // Start is called before the first frame update
    void Start()
    {
		Cambiar_panel(panel_principal);
        
		nivel1.SetActive(false);
		nivel2.SetActive(false);
		nivel3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    	// if (Input.GetKeyDown(KeyCode.Escape) && activar_pausa == true)
    	if (Input.GetKeyDown(KeyCode.Escape))
		{
        	if (estado_pausa == false)
			{
				Pausar();
			}
			else if (estado_pausa == true)
			{
				Renaudar();
			}
		} 
    }
}