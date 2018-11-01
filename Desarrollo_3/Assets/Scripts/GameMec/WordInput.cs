using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour {
    [SerializeField] WordManager wordManager;
    [SerializeField] LevelManager levelManager;

    // Update is called once per frame

    void Update () {
        if (!levelManager.GetPauseStatus()){
            foreach (char letter in Input.inputString){
                Debug.Log(letter);
                char LowerChar = char.ToLower(letter);
                wordManager.TypeLetter(LowerChar);
            }
        }
	}
}
