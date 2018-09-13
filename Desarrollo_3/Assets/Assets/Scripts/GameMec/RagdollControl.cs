using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControl : MonoBehaviour {

    [SerializeField]  Transform LeftHand;
    [SerializeField]  Transform RightHand;
    [SerializeField]  float smoothfloat;
    [SerializeField] WordManager wordManager;
    private bool WhichHand = false;

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

    private void OnTriggerStay2D(Collider2D collision)
    {
       /* if (collision.tag =="stones")
        {
            Debug.Log("debug typeletter");
            foreach (char letter in Input.inputString)
            {
                wordManager.TypeLetter(letter);
            }
        }*/
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
         Debug.Log("Movimineto de manos");
         Vector3 lerpedpos = Vector3.Lerp(LeftHand.position, roca.position, smoothfloat);
         LeftHand.position = lerpedpos;
        LeftHand.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //LeftHand.position = roca.position;
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
