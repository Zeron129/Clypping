using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLetter : MonoBehaviour {
    [SerializeField] float offsetx=-3;
    [SerializeField] GameObject Letter;
    [SerializeField] Sprite[] Sprites;
    private WordManager managertest;
    public bool OneActivation = true;
    private bool handed=false;
    RagdollControl ragdoll;
    private char[] StrgToChar;
    //private WordManager managertest;

    private void Start()
    {
        managertest = Object.FindObjectOfType<WordManager>();
       /* if (managertest)
        {
            Debug.Log("se encontro wordmanager");
        }
        else {
            Debug.Log("Wordmanager nop encontrado");
        }*/
    }
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

    public bool MakeLetter(char Letter,int pos,Transform Parent) {
        //Debug.Log("Creando letras");
        for (int i = 0; i < Sprites.Length; i++)
        {
            if (Sprites[i].name == Letter.ToString()) {
                GameObject Character = Instantiate(this.Letter, Parent);
                Vector3 ParetPos = Parent.transform.position;
                ParetPos.x = (Sprites[i].bounds.size.x*pos) + offsetx +Parent.position.x;
                Character.transform.position = ParetPos;
                Character.name = Sprites[i].name;
                Character.GetComponent<SpriteRenderer>().sortingOrder = 3;
                Character.GetComponent<SpriteRenderer>().sprite = Sprites[i];

                return true;
            }
            
        }
        return false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "ragdoll") {
            //Debug.Log("detecto ragdoll");
            ragdoll = collision.GetComponent<RagdollControl>();
        }
            
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag=="ragdoll"&& managertest.getActiveWord().word == gameObject.name)
        {
            Destroyed();
        }
        
        if (collision.tag == "ragdoll") {
            if (!managertest.getActiveWord().WordTyped()) {
                if (managertest.getActiveWord().word == this.gameObject.name)
                {
                    string ChildName = managertest.getActiveWord().CurrentLetter().ToString();
                    
                    if (transform.Find(ChildName.ToUpper()))
                    {
                        Debug.Log("hijo encontrado");
                        Destroy(transform.Find(ChildName.ToUpper()).gameObject);
                        
                    }
                    else {
                        Debug.Log("no se encontro hijo");
                    }
                
                }
                else {
                    //Debug.Log("no funcionas");
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OneActivation = false;
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }

        if (OneActivation == false) {
            Destroy(this);
        }
    }
    public void Destroyed() {
        if (managertest.getActiveWord().word==gameObject.name&&managertest.getActiveWord().WordTyped()==true)
        {
            foreach (Transform child in gameObject.transform)
            {
                Destroy(child.gameObject);
            }

            Invoke("MoveHand",0);
        }

    }

    private void MoveHand() {
        if(!ragdoll) {
            Debug.Log("no ragdoll");
        }
        else if(!handed) {
            ragdoll.HandMoves(gameObject.transform);
            handed = true;
        }
       
    }
    
}