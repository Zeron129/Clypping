using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField] private GameObject GameO00;
    [SerializeField] private GameObject Background;
    [SerializeField] private Vector3 BackgroundOffset;
    [SerializeField] Transform PlayerTransform;
    [SerializeField] GameObject Parent;
    private float spawnY00 = 0.0f;
    private float spawnY01 = 0.0f;
    private float spawnX = 5.0f;
    private float ObjectLength = 32.0f;
    private int amnObjectsOnScreen = 3;
	// Use this for  initialization

	void Start () {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        SpawnObj();
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerTransform.position.y > (spawnY00 - amnObjectsOnScreen * ObjectLength)) {
            SpawnObj();
            SimpleSpawn();
        }
	}

    private void SpawnObj() {
        GameObject GO=Instantiate(GameO00);
        GameObject GO2 = Instantiate(GameO00);
        GO.transform.SetParent(Parent.transform);
        GO.transform.position = new Vector3(-spawnX, Vector3.up.y * spawnY00, 0);


        GO2.transform.SetParent(Parent.transform);
        
        GO2.transform.position = new Vector3(spawnX, Vector3.up.y * spawnY00, 0);
        spawnY00 += ObjectLength;
    }

    private void SimpleSpawn() {
        GameObject GO = Instantiate(Background);
        GO.transform.SetParent(Parent.transform);

        GO.transform.position = new Vector3(0, Vector3.up.y * spawnY01, 0)+BackgroundOffset;
        spawnY01 += Background.GetComponent<Renderer>().bounds.size.y-1;

    }
}
