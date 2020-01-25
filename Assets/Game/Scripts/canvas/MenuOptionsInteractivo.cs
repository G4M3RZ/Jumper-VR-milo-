using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuOptionsInteractivo : MonoBehaviour {
    public GameObject ultra;
    public GameObject veryHigh;
    public GameObject high;
    public GameObject medium;
    public GameObject low;
    public GameObject veryLow;
    public GameObject Menu;

    public GameObject FadeInicial;
    public GameObject FadeFinal;

    private bool fadeSpawn = true;

    private float contadorCambioScenas = 1.5f;

    // Use this for initialization
    void Start ()
    {
        Instantiate(FadeInicial, new Vector3(0, 3.5f, 4.42f), transform.rotation);

        switch (QualitySettings.currentLevel)
        {
            case QualityLevel.Fantastic:
                ultra.GetComponent<BotonInteractivo>().ActivarBoton = true;
                break;
            case QualityLevel.Beautiful:
                veryHigh.GetComponent<BotonInteractivo>().ActivarBoton = true;
                break;
            case QualityLevel.Good:
                high.GetComponent<BotonInteractivo>().ActivarBoton = true;
                break;
            case QualityLevel.Simple:
                medium.GetComponent<BotonInteractivo>().ActivarBoton = true;
                break;
            case QualityLevel.Fast:
                low.GetComponent<BotonInteractivo>().ActivarBoton = true;
                break;
            case QualityLevel.Fastest:
                veryLow.GetComponent<BotonInteractivo>().ActivarBoton = true;
                break;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        UltraInstinto();
        VeryHigh();
        High();
        Medium();
        Low();
        VeryLow();
        BackToMenu();
    }
    void UltraInstinto()
    {
        if (ultra.GetComponent<BotonInteractivo>().ActivarBoton)
        {
            QualitySettings.currentLevel = QualityLevel.Fantastic;
            ultra.GetComponent<Toggle>().isOn = true;
            veryHigh.GetComponent<Toggle>().isOn = false;
            high.GetComponent<Toggle>().isOn = false;
            medium.GetComponent<Toggle>().isOn = false;
            low.GetComponent<Toggle>().isOn = false;
            veryLow.GetComponent<Toggle>().isOn = false;

            ResetButtonCheck();
        }
    }
    void VeryHigh()
    {
        if (veryHigh.GetComponent<BotonInteractivo>().ActivarBoton)
        {
            QualitySettings.currentLevel = QualityLevel.Beautiful;
            ultra.GetComponent<Toggle>().isOn = false;
            veryHigh.GetComponent<Toggle>().isOn = true;
            high.GetComponent<Toggle>().isOn = false;
            medium.GetComponent<Toggle>().isOn = false;
            low.GetComponent<Toggle>().isOn = false;
            veryLow.GetComponent<Toggle>().isOn = false;

            ResetButtonCheck();
        }
    }
    void High()
    {
        if (high.GetComponent<BotonInteractivo>().ActivarBoton)
        {
            QualitySettings.currentLevel = QualityLevel.Good;
            ultra.GetComponent<Toggle>().isOn = false;
            veryHigh.GetComponent<Toggle>().isOn = false;
            high.GetComponent<Toggle>().isOn = true;
            medium.GetComponent<Toggle>().isOn = false;
            low.GetComponent<Toggle>().isOn = false;
            veryLow.GetComponent<Toggle>().isOn = false;

            ResetButtonCheck();
        }
    }
    void Medium()
    {
        if (medium.GetComponent<BotonInteractivo>().ActivarBoton)
        {
            QualitySettings.currentLevel = QualityLevel.Simple;
            ultra.GetComponent<Toggle>().isOn = false;
            veryHigh.GetComponent<Toggle>().isOn = false;
            high.GetComponent<Toggle>().isOn = false;
            medium.GetComponent<Toggle>().isOn = true;
            low.GetComponent<Toggle>().isOn = false;
            veryLow.GetComponent<Toggle>().isOn = false;

            ResetButtonCheck();
        }
    }
    void Low()
    {
        if (low.GetComponent<BotonInteractivo>().ActivarBoton)
        {
            QualitySettings.currentLevel = QualityLevel.Fast;
            ultra.GetComponent<Toggle>().isOn = false;
            veryHigh.GetComponent<Toggle>().isOn = false;
            high.GetComponent<Toggle>().isOn = false;
            medium.GetComponent<Toggle>().isOn = false;
            low.GetComponent<Toggle>().isOn = true;
            veryLow.GetComponent<Toggle>().isOn = false;

            ResetButtonCheck();
        }
    }
    void VeryLow()
    {
        if (veryLow.GetComponent<BotonInteractivo>().ActivarBoton)
        {
            QualitySettings.currentLevel = QualityLevel.Fastest;
            ultra.GetComponent<Toggle>().isOn = false;
            veryHigh.GetComponent<Toggle>().isOn = false;
            high.GetComponent<Toggle>().isOn = false;
            medium.GetComponent<Toggle>().isOn = false;
            low.GetComponent<Toggle>().isOn = false;
            veryLow.GetComponent<Toggle>().isOn = true;

            ResetButtonCheck();
        }
    }
    void BackToMenu()
    {
        if (Menu.GetComponent<BotonInteractivo>().ActivarBoton)
        {
            if (fadeSpawn)
            {
                Instantiate(FadeFinal, new Vector3(0, 3.5f, 4.42f), transform.rotation);
                fadeSpawn = false;
            }
            contadorCambioScenas -= Time.deltaTime;
            if (contadorCambioScenas <= 0)
            {
                SceneManager.LoadScene(0);
                Menu.GetComponent<BotonInteractivo>().ActivarBoton = false;
            }
        }
    }

    void ResetButtonCheck()
    {
        ultra.GetComponent<BotonInteractivo>().ActivarBoton = false;
        veryHigh.GetComponent<BotonInteractivo>().ActivarBoton = false;
        high.GetComponent<BotonInteractivo>().ActivarBoton = false;
        medium.GetComponent<BotonInteractivo>().ActivarBoton = false;
        low.GetComponent<BotonInteractivo>().ActivarBoton = false;
        veryLow.GetComponent<BotonInteractivo>().ActivarBoton = false;
    }
}
