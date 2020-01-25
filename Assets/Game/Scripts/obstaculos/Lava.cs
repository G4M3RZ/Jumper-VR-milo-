using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {
    public bool TocoLava = false;
    public bool YaMurio = false;

    private float contador = 0.2f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        MuertePorLava();
        Posicionamiento();
    }
    void Posicionamiento()
    {
        if(transform.localPosition.z >= 4.5f)
        {
            transform.Translate(0, 0, -30f * Time.deltaTime);
        }
    }
    void MuertePorLava()
    {
        if (TocoLava)
        {
            contador -= Time.deltaTime;
            if (contador <= 0)
            {
                contador = 0;
                YaMurio = true;
            }
        }
        else
        {
            contador = 0.2f;
            YaMurio = false;
        }
    }
}
