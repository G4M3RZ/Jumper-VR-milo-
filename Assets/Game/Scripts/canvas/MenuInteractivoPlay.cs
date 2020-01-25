using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInteractivoPlay : MonoBehaviour {
    public GameObject PlayButon;
    public GameObject Options;
    public GameObject TutorialButton;
    public GameObject FadeInicial;
    public GameObject FadeFinal;

    private bool fadeSpawn = true;


    private float contadorCambioScenas = 1.5f;
    // Use this for initialization
    void Start ()
    {
        Instantiate(FadeInicial, new Vector3 (0,3.5f,4.42f), transform.rotation);
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayGame();
        Tutorial();
        Opciones();
    }
    public void PlayGame()
    {
        if (PlayButon.GetComponent<BotonInteractivo>().ActivarBoton)
        {
            if (fadeSpawn)
            {
                Instantiate(FadeFinal, new Vector3(0, 3.5f, 4.42f), transform.rotation);
                fadeSpawn = false;
            }
            contadorCambioScenas -= Time.deltaTime;
            if (contadorCambioScenas <= 0)
            {
                SceneManager.LoadScene(1);
                PlayButon.GetComponent<BotonInteractivo>().ActivarBoton = false;
            }
        }
    }
    public void Tutorial()
    {
        if (TutorialButton.GetComponent<BotonInteractivo>().ActivarBoton)
        {
            if (fadeSpawn)
            {
                Instantiate(FadeFinal, new Vector3(0, 3.5f, 4.42f), transform.rotation);
                fadeSpawn = false;
            }
            contadorCambioScenas -= Time.deltaTime;
            if (contadorCambioScenas <= 0)
            {
                SceneManager.LoadScene(3);
                TutorialButton.GetComponent<BotonInteractivo>().ActivarBoton = false;
            }
        }
    }
    public void Opciones()
    {
        if (Options.GetComponent<BotonInteractivo>().ActivarBoton)
        {
            if (fadeSpawn)
            {
                Instantiate(FadeFinal, new Vector3(0, 3.5f, 4.42f), transform.rotation);
                fadeSpawn = false;
            }
            contadorCambioScenas -= Time.deltaTime;
            if (contadorCambioScenas <= 0)
            {
                SceneManager.LoadScene(2);
                Options.GetComponent<BotonInteractivo>().ActivarBoton = false;
            }
        }
    }
}
