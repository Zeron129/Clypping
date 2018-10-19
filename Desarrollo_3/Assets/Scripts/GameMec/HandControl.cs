using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandControl : MonoBehaviour {

    [SerializeField] Transform Hand;
    [SerializeField] float smoothfloat;
    private Transform target;
    private bool hand;

	void Update () {
        if (hand) {
            Hand.position = Vector3.Lerp(Hand.position, target.position, smoothfloat);
        }
	}

    public void Movement(bool hand_,Transform target_ ) {
        target = target_;
        hand=hand_;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "stones") {
            Debug.Log("toca piedra");
            hand = false;
        }
            
    }
}
