﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControl : MonoBehaviour {
    [SerializeField] RandomWordGen RandomWordGen;
    [SerializeField]  GameObject LeftHand;
    [SerializeField]  GameObject RightHand;
    [SerializeField]  float smoothfloat;
    [SerializeField] WordManager wordManager;
    private bool Lhand = true;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "stones") {
            if (collision.GetComponent<SpawnLetter>().OneActivation==true)
            {
                Word word = new Word(RandomWordGen.GetRandomWord());
                wordManager.AddWord(word);
                CreateLetter(collision.gameObject, word);
            }
        }       
    }
    

    private void CreateLetter(GameObject collision, Word word) {

        if (collision.GetComponent<SpawnLetter>())
        {
            SpawnLetter spawner = collision.GetComponent<SpawnLetter>();
            spawner.MakeSprite(word.word);
        }
        else {
            Debug.Log("NoSpawner");
        }
    }

    public void HandMoves(Transform roca) {

        Lhand = !Lhand;

        if (Lhand )
        {
            LeftHand.GetComponent<HandControl>().Movement(true,roca);
        }
        else if (!Lhand)
        {
            RightHand.GetComponent<HandControl>().Movement(true, roca);
        }
    }
    
}