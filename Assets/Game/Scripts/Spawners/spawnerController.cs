using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerController : MonoBehaviour
{
    public GameObject Player;
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;

    public GameObject Puntaje;

    public bool terminarContador = false;

    public float contador = 2.3f;
    public float contadorDificulty;

    public int cambiador = 0;
    public int cambSpawn = 1;
    public int minRandomSwitch = 1; 
    public int maxRandomSwitch = 4; 

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (terminarContador == false && Player.GetComponent<Player>().PlayerDead == false)
        {
            Contador();
            Spawn();
        }
        CambiadorDeSwitch();
        CondicionDeBloqueo();
    }
    void Spawn()
    {
        switch (cambiador)
        {
            case 1: spawner1.GetComponent<Spawner>().spawn = true; cambiador = 0; cambSpawn = 1; break;
            case 2: spawner2.GetComponent<Spawner2>().spawn = true; cambiador = 0; cambSpawn = 1; break;
            case 3: spawner3.GetComponent<Spawner3>().spawn = true; cambiador = 0; cambSpawn = 1; break;
        }
    }
    void CambiadorDeSwitch()
    {
        if (contador == 0f)
        {
            switch (cambSpawn)
            {
                case 1: cambiador = Random.Range(minRandomSwitch,maxRandomSwitch); contador = contadorDificulty; break;
            }
        }
    }
    void Contador()
    {
        contador = contador - 1 * Time.deltaTime;
        if (contador < 0)
        {
            contador = 0;
        }
    }
    void CondicionDeBloqueo()
    {
        if (spawner1.GetComponent<Spawner>().Bloqueo1)
        {
            spawner1.GetComponent<Spawner>().spawnRandom = 4;
            spawner2.GetComponent<Spawner2>().spawnRandom = 4;
            spawner3.GetComponent<Spawner3>().spawnRandom = 4;

            minRandomSwitch = 2;
        }
        if (spawner3.GetComponent<Spawner3>().Bloqueo2)
        {
            maxRandomSwitch = 3;

            spawner1.GetComponent<Spawner>().spawnRandom = 4;
            spawner2.GetComponent<Spawner2>().spawnRandom = 4;
            spawner3.GetComponent<Spawner3>().spawnRandom = 4;
        }
        if (Puntaje.GetComponent<Puntaje>().Contador >= 500 && spawner1.GetComponent<Spawner>().Bloqueo1 == false && spawner3.GetComponent<Spawner3>().Bloqueo2 == false)
        {
            minRandomSwitch = 1;
            maxRandomSwitch = 4;

            spawner1.GetComponent<Spawner>().spawnRandom = 7;
            spawner2.GetComponent<Spawner2>().spawnRandom = 8;
            spawner3.GetComponent<Spawner3>().spawnRandom = 7;
        }
    }
}