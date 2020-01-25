using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMilo : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        RotacionEfect();
	}
    void RotacionEfect()
    {
        transform.Rotate(0, 0, 80 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
