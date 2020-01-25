using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntaje : MonoBehaviour {

    public GameObject Player;
    public GameObject MenuInteractivoInGame;
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject Misiles;

    private int randomnum;
    public float Contador = 0f;
    private float contador = 25;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        ContadorInGame();
        AumentadorDeDificultad();
        ComparadorDeRandomNum();
    }
    void ContadorInGame()
    {
        if (Player.GetComponent<Player>().PlayerDead == false && MenuInteractivoInGame.GetComponent<MenuInteractivoInGame>().IsPause == false)
        {
            Contador += 1 * Time.deltaTime * 5;
        }
    }
    void AumentadorDeDificultad()
    {
        if (Contador < 100)
        {
            spawner1.GetComponent<Spawner>().spawnRandom = 1;
            spawner2.GetComponent<Spawner2>().spawnRandom = 1;
            spawner3.GetComponent<Spawner3>().spawnRandom = 1;
        }
        if (Contador >= 100 && Contador < 200)
        {
            spawner1.GetComponent<Spawner>().spawnRandom = 4;
            spawner2.GetComponent<Spawner2>().spawnRandom = 4;
            spawner3.GetComponent<Spawner3>().spawnRandom = 4;
        }
        if (Contador >= 200 && Contador < 300)
        {
            spawner1.GetComponent<Spawner>().spawnRandom = 5;
            spawner2.GetComponent<Spawner2>().spawnRandom = 5;
            spawner3.GetComponent<Spawner3>().spawnRandom = 5;
        }
        if (Contador >= 300 && Contador < 400)
        {
            spawner1.GetComponent<Spawner>().spawnRandom = 6;
            spawner2.GetComponent<Spawner2>().spawnRandom = 5;
            spawner3.GetComponent<Spawner3>().spawnRandom = 6;
        }
        if (Contador >= 400 && Contador < 500)
        {
            spawner1.GetComponent<Spawner>().spawnRandom = 6;
            spawner2.GetComponent<Spawner2>().spawnRandom = 8;
            spawner3.GetComponent<Spawner3>().spawnRandom = 6;
        }
        if (Contador >= 600)
        {
            if(randomnum == 1)
            {
                Misiles.GetComponent<ControlladorDeMisiles>().ActivarMisiles = true;
            }
            else
            {
                Misiles.GetComponent<ControlladorDeMisiles>().ActivarMisiles = false;
            }
        }
    }
    void ComparadorDeRandomNum()
    {
        contador -= Time.deltaTime;
        if(contador <= 0)
        {
            randomnum = Random.Range(0, 8);
            contador = 25;
        }
    }
}
