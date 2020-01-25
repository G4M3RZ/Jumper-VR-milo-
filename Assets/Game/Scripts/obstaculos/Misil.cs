using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misil : MonoBehaviour {

    public bool MisilCollision = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        MovimientoMisil();
	}
    void MovimientoMisil()
    {
        transform.Translate(0, 0, 50 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ObstEnd")
        {
            MisilCollision = true;
        }
    }
}
