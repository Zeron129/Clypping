using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLetter : MonoBehaviour {
    [SerializeField] int offsetx;
    [SerializeField] GameObject Letra;
    [SerializeField] GameObject Roca;
    [SerializeField] Sprite[] Sprites;
    private char[] StrgToChar;

    public void MakeSprite(string MyStrg) {
        string UpperSTR = MyStrg.ToUpper();
        
        StrgToChar = UpperSTR.ToCharArray();
        GameObject String = Instantiate(Roca);
        String.name = MyStrg;

        for (int i = 0; i < StrgToChar.Length; i++) {
            if (MakeLetter(StrgToChar[i],i,String.transform))
            {
                Debug.Log(StrgToChar[i]);

            }
            else
            {
                Debug.Log("No se encontro la letra");
            }
        }
    }

    public bool MakeLetter(char Letter,int pos,Transform Padre) {
        for (int i = 0; i < Sprites.Length; i++)
        {
            if (Sprites[i].name == Letter.ToString()) {
                Vector3 posicion=new Vector3();
                posicion.x = (Sprites[i].bounds.size.x*pos)+offsetx;
                GameObject Character = Instantiate(Letra,Padre);
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
