using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControl : MonoBehaviour {

    [SerializeField]  Transform LeftHand;
    [SerializeField]  Transform RightHand;
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

        if (Lhand && LeftHand.position != RightHand.position)
        {
            while (roca.position!=RightHand.position)
            {
                Debug.Log("Movimineto de mano Der");
                Vector3 lerpedpos = Vector3.Lerp(RightHand.position, roca.position, smoothfloat);
                RightHand.position = lerpedpos;
            }
            

        }
        else if (!Lhand && LeftHand.position != RightHand.position)
        {
            while (roca.position!=LeftHand.position)
            {
                Debug.Log("Movimineto de mano Izq");
                Vector3 lerpedpos = Vector3.Lerp(LeftHand.position, roca.position, smoothfloat);
                LeftHand.position = lerpedpos;
            }
            
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
