using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3 : MonoBehaviour {
    public Transform[] spawnLocation;
    public GameObject[] prefab;
    public GameObject[] clone;
    public GameObject menuPausa;

    public bool spawn = false;
    public bool Bloqueo2 = false;

    public int numCambiador = 0;
    public int spawnRandom = 7;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (spawn && menuPausa.GetComponent<MenuInteractivoInGame>().IsPause == false)
        {
            numCambiador = Random.Range(0, spawnRandom);
            Spawn3();
            spawn = false;
        }

    }
    void Spawn3()
    {
        if (numCambiador == 0)
        {
            clone[numCambiador] = Instantiate(prefab[numCambiador], spawnLocation[0].transform.position, Quaternion.Euler(-90, -0.25f, 0)) as GameObject;
        }
        else
        {
            clone[numCambiador] = Instantiate(prefab[numCambiador], spawnLocation[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bloqueo")
        {
            Bloqueo2 = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Bloqueo")
        {
            Bloqueo2 = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bloqueo")
        {
            Bloqueo2 = false;
        }
    }
}
