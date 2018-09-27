using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour {
    WordManager wordManager;

    void Awake(){
        wordManager = GameManager.Instance.WordManager;
    }

    void Update () {
        foreach (char letter in Input.inputString) {
            Debug.Log(letter);
            wordManager.TypeLetter(letter);
        }
	}
}
