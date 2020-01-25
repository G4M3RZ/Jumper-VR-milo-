using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedMovedisa : MonoBehaviour {

    public float contador = 2.5f;
    public bool moverse = false;
    public bool TerminoDeMoverse = false;
    // Use this for initialization
    void Start ()
    {
        TerminoDeMoverse = false;
        moverse = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Engaño();
    }
    void Engaño()
    {
        contador -= Time.deltaTime;
        if(moverse)
        {
            if(contador >= 0)
            {
                transform.Translate(-1 * Time.deltaTime * 6, 0, 0);
            }
            else
            {
                contador = 0;
            }
        }
        else
        {
            if(TerminoDeMoverse == false)
            {
                if (contador <= 0)
                {
                    contador = 0.6f;
                    moverse = true;
                    TerminoDeMoverse = true;
                }
            }
        }
    }
}
