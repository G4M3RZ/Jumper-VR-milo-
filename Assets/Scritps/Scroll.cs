using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
	public float scrollx = 0.5f;
	public float scrolly = 0.5f;
	public float speed = 0.2f;

	void Update () {
		float offsetX = Time.time * scrollx *speed;
		float offsetY = Time.time * scrolly *speed;
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (offsetX,offsetY);
		
	}
}
