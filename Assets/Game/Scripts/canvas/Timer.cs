using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timerNum = 100;

    public Text TimerController;

    public GameObject SpawnerController;
    public GameObject Canvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		TimerController.text = timerNum.ToString("0");

        TimerDown();
    }
    void TimerDown()
    {
        if(Canvas.GetComponent<MenuInteractivoInGame>().IsPause == false)
        {
            timerNum -= Time.deltaTime;
        }
        if (timerNum <= 0)
        {
            timerNum = 0;
            SpawnerController.GetComponent<spawnerController>().terminarContador = true;
        }
    }
}
