using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlladorDeMisiles : MonoBehaviour {

    public Transform[] spawnLocation;
    public GameObject[] prefab;
    public GameObject[] clone;

    public GameObject Canvas;

    int RandomNumber = 1;

    int SwitschMisil = 0;

    public float contador = 2f;
    public float ContadorTerminarDeLansar = 16f;
    public float misilTiempo;

    public bool ActivarMisiles = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Canvas.GetComponent<MenuInteractivoInGame>().IsPause == false)
        {
            if (ActivarMisiles)
            {
                if (ContadorTerminarDeLansar >= 0)
                {
                    SwitchMisilRandom();
                    ContadorRegresivoDeLansamiento();
                    TerminarDeLanzar();
                }
                else
                {
                    ActivarMisiles = false;
                    ContadorTerminarDeLansar = 16f;
                    SwitschMisil = 0;
                }
            }
        }
    }
    void SwitchMisilRandom()
    {
        switch (SwitschMisil)
        {
            case 1: clone[0] =  Instantiate(prefab[0], spawnLocation[RandomNumber].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject; break;
        }
    }
    void ContadorRegresivoDeLansamiento()
    {
        contador -= Time.deltaTime;
        SwitschMisil = 0;
        if (contador <= 0)
        {
            RandomNumber = Random.Range(0, 6);
            SwitschMisil = 1;
            contador = misilTiempo;
        }
    }
    void TerminarDeLanzar()
    {
        ContadorTerminarDeLansar -= Time.deltaTime;
    }
}
