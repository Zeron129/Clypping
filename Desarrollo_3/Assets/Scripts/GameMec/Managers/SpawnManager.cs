using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField] private GameObject GameO;
    [SerializeField] Transform PlayerTransform;
    [SerializeField] GameObject Parent;
    private float spawnY = 0.0f;
    private float spawnX = 5.0f;
    private float ObjectLength = 32.0f;
    private int amnObjectsOnScreen = 3;
	// Use this for  initialization

	void Start () {
        SpawnObj();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SpawnObj() {
        GameObject GO=Instantiate(GameO);
        GameObject GO2 = Instantiate(GameO);
        GO.transform.SetParent(Parent.transform);
        GO.transform.position = new Vector3(-spawnX, Vector3.up.y * spawnY, 0);


        GO2.transform.SetParent(Parent.transform);
        
        GO2.transform.position = new Vector3(spawnX, Vector3.up.y * spawnY, 0);
        
    }
}
