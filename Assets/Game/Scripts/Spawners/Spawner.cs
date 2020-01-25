using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public Transform[] spawnLocation;
    public GameObject[] prefab;
    public GameObject[] clone;
    public GameObject menuPausa;

    public bool spawn = false;

    public bool Bloqueo1 = false;

    public int numCambiador = 0;
    public int spawnRandom = 7;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
       
        if (spawn && menuPausa.GetComponent<MenuInteractivoInGame>().IsPause == false)
        {
            numCambiador = Random.Range(0, spawnRandom);
            Spawn();
            spawn = false;
        }
    }
    void Spawn()
    {
        if(numCambiador == 0)
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
        if(other.gameObject.tag == "Bloqueo")
        {
            Bloqueo1 = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Bloqueo")
        {
            Bloqueo1 = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bloqueo")
        {
            Bloqueo1 = false;
        }
    }
}
