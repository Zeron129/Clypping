using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {
    [SerializeField] private Vector3 center;
    [SerializeField] private Vector3 size;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int ObjMin;
    [SerializeField] private int ObjMax;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < Random.Range(ObjMin,ObjMax); i++)
        {
            Invoke("spawmRocks", 0);
        }
        
	}
	
    void spawmRocks() {
        Vector3 pos = gameObject.transform.position + center + new Vector3(Random.Range(-size.x/2,size.x/2), Random.Range(-size.y / 2,size.y/2), Vector3.zero.z);
        Instantiate(prefab, pos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0.5f,0.5f);
        Gizmos.DrawCube(gameObject.transform.position + center,size);
    }
}
