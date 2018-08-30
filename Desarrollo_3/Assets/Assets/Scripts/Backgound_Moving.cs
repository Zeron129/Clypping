using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgound_Moving : MonoBehaviour {

	[SerializeField] float X_Offset = 0f;
	[SerializeField] float Y_Offset = 0f;

	Material materialBackgrond; // material containig the formost bacground 
								// (the rock of the montain, the wall of a castle, etc)
	Vector2 offset = Vector2.zero;

	void Awake () {
		materialBackgrond = GetComponent<Renderer>().material;
	}
	void Start() {
		//offset = new Vector2(X_Offset, Y_Offset);
	}

	void Update () {
		offset = new Vector2(X_Offset, Y_Offset);
		materialBackgrond.mainTextureOffset += offset * Time.deltaTime;
	}

	public void SetBOffset(float X, float Y) {
		X_Offset = X;
		Y_Offset = Y;
	}
}
