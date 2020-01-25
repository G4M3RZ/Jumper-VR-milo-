using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinParticulas : MonoBehaviour {

    public float contador = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        contador -= Time.deltaTime*1;
        if (contador <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
