using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHands : MonoBehaviour {
    [SerializeField] Transform Hand1;
    [SerializeField] Transform Hand2;
    [SerializeField] float smooth = 0.125f;
    [SerializeField] Vector3 offset;
    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 smoothedPos = Vector3.Lerp(Hand1.localPosition, Hand2.localPosition, 0.5f);
        transform.localPosition = smoothedPos + offset;
    }
}
