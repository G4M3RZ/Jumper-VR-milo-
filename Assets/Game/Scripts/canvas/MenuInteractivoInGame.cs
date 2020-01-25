using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInteractivoInGame : MonoBehaviour {
    public GameObject Player;
    public GameObject Camara;
    public GameObject PauseMenuUI;
    public GameObject DeadMenuUI;
    public GameObject BotonRestart;
    public GameObject BotonResume;
    public GameObject BotonMenuPause;
    public GameObject BotonMenuDead;
    public bool IsPause = false;

    public GameObject FadeInicial;
    public GameObject FadeFinal;

    private bool fadeSpawn = true;

    public float contadorCambioScenas = 1.5f;

    public bool tePuedesMover = false;
	// Use this for initialization
	void Start ()
    {
        Instantiate(FadeInicial, new Vector3(0, 3.5f, 4.42f), transform.rotation);

        tePuedesMover = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Restart();
        //Resume();
        //MenuPausa();
        MenuDead();
        Pause();
        Dead();
    }
    public void Dead()
    {
        if (Player.GetComponent<Player>().PlayerDead)
        {
            DeadMenuUI.SetActive(true);
        }
        else
        {
            DeadMenuUI.SetActive(false);
        }
    }
    public void Pause()
    {
        if (Player.GetComponent<Player>().PlayerDead == false)
        {
            if (IsPause == false)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Time.timeScale = 0f;
                    PauseMenuUI.SetActive(true);
                    IsPause = true;
                    Camara.GetComponent<RotateCamera>().AllStop = false;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Time.timeScale = 1f;
                    PauseMenuUI.SetActive(false);
                    IsPause = false;
                    if (tePuedesMover)
                    {
                        Camara.GetComponent<RotateCamera>().AllStop = true;
                    }
                }
            }
        }
    }
    public void Restart()
    {
        if (BotonRestart.GetComponent<BotonInteractivo>().ActivarBoton)
        {
            if (fadeSpawn)
            {
                Instantiate(FadeFinal, new Vector3(transform.position.x, 3.5f, 4.42f), transform.rotation);
                fadeSpawn = false;
            }
            contadorCambioScenas -= Time.deltaTime;
            if (contadorCambioScenas <= 0)
            {
                Application.LoadLevel(Application.loadedLevel);
                Time.timeScale = 1f;
                BotonRestart.GetComponent<BotonInteractivo>().CooldownBoton = 1f;
                BotonRestart.GetComponent<BotonInteractivo>().Touch = false;
                BotonRestart.GetComponent<BotonInteractivo>().ActivarBoton = false;
                Camara.GetComponent<RotateCamera>().AllStop = true;
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
        IsPause = false;
        if (tePuedesMover)
        {
            Camara.GetComponent<RotateCamera>().AllStop = true;
        }
        /*if (BotonResume.GetComponent<BotonInteractivo>().ActivarBoton)
        {
            Time.timeScale = 1f;
            PauseMenuUI.SetActive(false);
            IsPause = false;
            BotonResume.GetComponent<BotonInteractivo>().CooldownBoton = 1f;
            BotonResume.GetComponent<BotonInteractivo>().Touch = false;
            BotonResume.GetComponent<BotonInteractivo>().ActivarBoton =false;
        }*/
    }
    public void MenuPausa()
    {
        if (fadeSpawn)
        {
            Instantiate(FadeFinal, new Vector3(transform.position.x, 3.5f, 4.42f), transform.rotation);
            fadeSpawn = false;
        }
        contadorCambioScenas = 0;
        if (contadorCambioScenas <= 0)
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
            Camara.GetComponent<RotateCamera>().AllStop = true;
            BotonRestart.GetComponent<BotonInteractivo>().ActivarBoton = false;
        }
        /*if (BotonMenuPause.GetComponent<BotonInteractivo>().ActivarBoton)
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
            BotonMenuPause.GetComponent<BotonInteractivo>().CooldownBoton = 1f;
            BotonMenuPause.GetComponent<BotonInteractivo>().Touch = false;
            BotonMenuPause.GetComponent<BotonInteractivo>().ActivarBoton = false;
        }*/
    }
    public void MenuDead()
    {
        if (BotonMenuDead.GetComponent<BotonInteractivo>().ActivarBoton)
        {
            if (fadeSpawn)
            {
                Instantiate(FadeFinal, new Vector3(transform.position.x, 3.5f, 4.42f), transform.rotation);
                fadeSpawn = false;
            }
            contadorCambioScenas -= Time.deltaTime;
            if (contadorCambioScenas <= 0)
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1f;
                BotonMenuDead.GetComponent<BotonInteractivo>().CooldownBoton = 1f;
                BotonMenuDead.GetComponent<BotonInteractivo>().Touch = false;
                BotonMenuDead.GetComponent<BotonInteractivo>().ActivarBoton = false;
                Camara.GetComponent<RotateCamera>().AllStop = true;
            }
        }
    }
}
