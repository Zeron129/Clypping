using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLetter : MonoBehaviour {
    [SerializeField] GameObject prefab;
    [SerializeField] Sprite[] Sprites;

    public void MakeSprite() {
        int ArrIndx = Random.Range(0,Sprites.Length);
        Sprite Lettersprite = Sprites[ArrIndx];

        GameObject Character = Instantiate(prefab);

        Character.name = Lettersprite.name;
        Character.GetComponent<SpriteRenderer>().sprite = Lettersprite;
    }
}
