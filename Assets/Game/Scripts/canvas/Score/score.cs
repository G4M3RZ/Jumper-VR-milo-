using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {
    public Text ElScore;
    public Text _miloScore;
    public Text HighScoreDead;
    public Text HighScorePause;
    public GameObject Puntaje;
    public float numb;
    public int _miloNum;
	// Use this for initialization
	void Start ()
    {
        HighScoreDead.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("f0");
        HighScorePause.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("f0");
    }
	
	// Update is called once per frame
	void Update () {
        numb = Puntaje.GetComponent<Puntaje>().Contador;
        Score();
	}

    public void Score()
    {
        ElScore.text = numb.ToString("Score: " + "0");
        _miloScore.text = _miloNum.ToString("Milos: " + "0");
        if (numb > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", numb);
            HighScoreDead.text = numb.ToString("f0");
            HighScorePause.text = numb.ToString("f0");
        }
    }
}
