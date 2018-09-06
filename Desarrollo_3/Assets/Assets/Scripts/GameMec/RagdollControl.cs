using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControl : MonoBehaviour {
    [SerializeField] Transform LeftHand;
    [SerializeField] Transform RightHand;

    private void OnTriggerStay2D(Collider2D collision) {
        Debug.Log(collision.name);
        if(collision.tag == "stones") {
            Debug.Log(collision.name);
        }
    }
}

