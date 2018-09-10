using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControl : MonoBehaviour {

    [SerializeField] Transform LeftHand;
    [SerializeField] Transform RightHand;
    [SerializeField] float smoothfloat;
    [SerializeField] WordManager wordManager;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "stones") {
            Word word = new Word(RandomWordGen.GetRandomWord());
            wordManager.AddWord(word,collision.gameObject);
            CreateLetter(collision.gameObject, word);
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
}

/*
if(collision.tag == "ragdoll") {
            foreach (char letter in Input.inputString)
            {
                Debug.Log(letter);
                wordManager.TypeLetter(letter);
            }

            Vector3 lerpedpos = Vector3.Lerp(LeftHand.position, collision.transform.position, smoothfloat);
LeftHand.position =lerpedpos;
       
        }*/
