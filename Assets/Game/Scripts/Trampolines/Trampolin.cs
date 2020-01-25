using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour {

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        Movimiento();
    }
    void Movimiento()
    {
        transform.Translate(0, 0, -30f * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ObstEnd")
        {
            Destroy(this.gameObject);
        }
    }
}
