using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public RotateCamera compRotateCamera;
    public GameObject MenuInteractivoInGame;
    public GameObject Player;
    private float initialPosX;
    private float initialPosY;
    private float movementFactor = 1.5f;

    public bool estaMirandoArriba = false;

    // Use this for initialization
    void Start ()
    {
        initialPosX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

        float rotY = compRotateCamera.GetCurrentRotationY();
        float offset2 = rotY * movementFactor;

        if (MenuInteractivoInGame.GetComponent<MenuInteractivoInGame>().IsPause == false && Player.GetComponent<Player>().PlayerDead == false)
        {
            transform.position = new Vector3(initialPosX + offset2 * 2 ,transform.position.y, transform.position.z);
        }
        
        if (offset2 >= 20)
        {
            offset2 = 20;
        }
        if (offset2 <= -20)
        {
            offset2 = -20;
        }
    }
}
