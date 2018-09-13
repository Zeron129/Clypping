﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLetter : MonoBehaviour {
    [SerializeField] float offsetx=-3;
    [SerializeField] GameObject Letra;
    [SerializeField] Sprite[] Sprites;
    [SerializeField] WordManager wordManager;
    public bool OneActivation = true;
    RagdollControl ragdoll;
    private char[] StrgToChar;

    public void MakeSprite(string MyStrg) {
        
            string UpperSTR = MyStrg.ToUpper();

            StrgToChar = UpperSTR.ToCharArray();
            this.gameObject.name = MyStrg;

            for (int i = 0; i < StrgToChar.Length; i++)
            {
                if (MakeLetter(StrgToChar[i], i, gameObject.transform))
                {
                    //Debug.Log(StrgToChar[i]);

                }
                else
                {
                    Debug.Log("No se encontro la letra");
                }
            }
    }

    public bool MakeLetter(char Letter,int pos,Transform Padre) {
        Debug.Log("Creando letras");
        for (int i = 0; i < Sprites.Length; i++)
        {
            if (Sprites[i].name == Letter.ToString()) {
                GameObject Character = Instantiate(Letra,Padre);
                Vector3 posicion = Padre.transform.position;
                posicion.x = (Sprites[i].bounds.size.x * pos) + offsetx + Padre.position.x;
                Character.transform.position = posicion;
                Character.name = Sprites[i].name;
                Character.GetComponent<SpriteRenderer>().sortingOrder = 1;
                Character.GetComponent<SpriteRenderer>().sprite = Sprites[i];
                
                return true;
            }
            
        }
        return false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="ragdoll")
            ragdoll = collision.GetComponent<RagdollControl>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag=="ragdoll"&& wordManager.getActiveWord().word == gameObject.name)
        {
            Destroyed();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OneActivation = false;
    }
    public void Destroyed() {
        if (wordManager.getActiveWord().word==gameObject.name&&wordManager.getActiveWord().WordTyped()==true)
        {
            foreach (Transform child in gameObject.transform)
            {
                Destroy(child.gameObject);
            }

            //InvokeRepeating("MoveHand", 0, 1);
        }
    }

    private void MoveHand() {
       ragdoll.HandMoves(gameObject.transform);
    }
    
}



/*
[SerializeField] float offsetx;
[SerializeField] GameObject Letra;
[SerializeField] GameObject Roca;
[SerializeField] Sprite[] Sprites;
private char[] StrgToChar;

public void MakeSprite(string MyStrg)
{
    string UpperSTR = MyStrg.ToUpper();

    StrgToChar = UpperSTR.ToCharArray();
    GameObject String = Instantiate(Roca);
    String.name = MyStrg;

    for (int i = 0; i < StrgToChar.Length; i++)
    {
        if (MakeLetter(StrgToChar[i], i, String.transform))
        {
            Debug.Log(StrgToChar[i]);

        }
        else
        {
            Debug.Log("No se encontro la letra");
        }
    }
}

public bool MakeLetter(char Letter, int pos, Transform Padre)
{
    for (int i = 0; i < Sprites.Length; i++)
    {
        if (Sprites[i].name == Letter.ToString())
        {
            Vector3 posicion = new Vector3();
            posicion.x = (Sprites[i].bounds.size.x * pos) + offsetx;
            GameObject Character = Instantiate(Letra, Padre);
            Character.transform.position = posicion;
            Character.name = Sprites[i].name;
            Character.GetComponent<SpriteRenderer>().sortingOrder = 1;
            Character.GetComponent<SpriteRenderer>().sprite = Sprites[i];

            return true;
        }

    }
    return false;
}
}
*/