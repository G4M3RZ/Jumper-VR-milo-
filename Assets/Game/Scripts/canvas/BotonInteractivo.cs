using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonInteractivo : MonoBehaviour {
    public bool Touch = false;
    public bool ActivarBoton = false;
    public float CooldownBoton = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Touch)
        {
            CoolDown();
        }
        else
        {
            CooldownBoton = 1f;
        }
        if (CooldownBoton <= 0)
        {
            ActivarBoton = true;
        }
        /*else
        {
            ActivarBoton = false;
        }*/
	}
    void CoolDown()
    {
        CooldownBoton -= 1 * Time.deltaTime; 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Seleccionador")
        {
            Touch = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Seleccionador")
        {
            Touch = false;
        }
    }
}
