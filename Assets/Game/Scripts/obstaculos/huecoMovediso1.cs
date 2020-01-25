using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huecoMovediso1 : MonoBehaviour {

    bool cambio1 = false;
    bool cambio2 = false;

    float contador;

    public int inicio;
	// Use this for initialization
	void Start ()
    {
        contador = 1f;
        inicio = Random.Range(0, 2);
		if(inicio == 0)
        {
            cambio1 = true;
        }
        else
        {
            cambio2 = true;
        }
	}
	// Update is called once per frame
	void Update ()
    {
        MovimientoNaranja();

    }
    void MovimientoNaranja()
    {
        contador -= Time.deltaTime;
        if (cambio1)
        {
            transform.Translate(3*Time.deltaTime, 0, 0);
            if(contador <= 0)
            {
                contador = 2f;
                cambio2 = true;
                cambio1 = false;
            }
        }
        else if (cambio2)
        {
            transform.Translate(-3 * Time.deltaTime, 0, 0);
            if(contador <= 0)
            {
                contador = 2f;
                cambio2 = false;
                cambio1 = true;
            }
        }
    }
}
