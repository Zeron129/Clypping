using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControl : MonoBehaviour {
    [SerializeField] Transform LeftHand;
    [SerializeField] Transform RightHand;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("TriggerEnter2D");
    }
}
