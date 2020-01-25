using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour {
    //private Vector3 rotation;
    public float currentRotationX;
    public float currentRotationY;
    public bool AllStop = true;

	// Use this for initialization
	void Start ()
    {
        currentRotationY = 0;
	}
	// Update is called once per frame
	void Update () {
        if (AllStop)
        {
            currentRotationY += transform.rotation.y * Time.deltaTime * 50;
        }
    }
    public float GetCurrentRotationY()
    {
        return currentRotationY;
    }
}
