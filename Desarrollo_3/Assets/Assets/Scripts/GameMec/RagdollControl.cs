using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControl : MonoBehaviour {
    [SerializeField] Transform LeftHand;
    [SerializeField] Transform RightHand;
    [SerializeField] float smoothfloat;

    private void OnTriggerStay2D(Collider2D collision) {
        
        if(collision.tag == "stones") {
            Debug.Log(collision.name);
            Vector3 lerpedpos = Vector3.Lerp(LeftHand.position, collision.transform.position, smoothfloat);
            LeftHand.position =lerpedpos;
            
        }
    }
}

