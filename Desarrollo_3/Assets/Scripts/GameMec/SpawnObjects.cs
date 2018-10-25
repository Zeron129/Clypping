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
    private void Awake()
    {

        center = this.gameObject.transform.position;
    }
    private void Start()
    {
        for (int i = 0; i < Random.Range(ObjMin, ObjMax); i++)
        {
            spawmRocks(i * 3);
        }
    }
    void spawmRocks(int i) {
        Vector3 pos = gameObject.transform.position + center + new Vector3(Random.Range(-size.x/2,size.x/2), -size.y/2 + i, Vector3.zero.z);
        Instantiate(prefab, pos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0.5f,0.5f);
        Gizmos.DrawCube(gameObject.transform.position + center,size);
    }
}
