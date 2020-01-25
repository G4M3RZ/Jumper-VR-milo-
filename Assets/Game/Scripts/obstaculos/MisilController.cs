using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilController : MonoBehaviour {
    public GameObject Misil;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Misil.GetComponent<Misil>().MisilCollision == true)
        {
            Destroy(this.gameObject);
        }
	}
}
