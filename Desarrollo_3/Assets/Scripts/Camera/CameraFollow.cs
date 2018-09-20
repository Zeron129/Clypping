using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField] Transform Target;
    [SerializeField] float smooth =0.125f;
    [SerializeField] Vector3 offset;
    // Update is called once per frame
    private void LateUpdate() {
        Vector3 desiredPos = Target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smooth);
        transform.position = smoothedPos;
    }
}
