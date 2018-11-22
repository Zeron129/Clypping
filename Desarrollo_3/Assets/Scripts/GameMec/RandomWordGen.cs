using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class RandomWordGen : MonoBehaviour {
    private  List<string> words = new List<string>();
    string line;
    private StreamReader SR;
    private  List<string> auxwords = new List<string>();
    private  string randomWord;
    private  bool List1=true;

    private void Start()
    {
        SR = new StreamReader(@"C:\Users\Administrador\Desktop\Clypping\Desarrollo_3\Assets\StringsFiles\WORDS.txt");
        while ((line = SR.ReadLine()) != null) {
            Debug.Log(line);
            words.Add(line);
        }
    }

    public string GetRandomWord () {
        if (List1)
        {
            //Debug.Log("Hay " + words.Count + " palabras");
            int randomIndex = Random.Range(0, words.Count);
            randomWord = words[randomIndex];
            auxwords.Add(randomWord);
            words.Remove(randomWord);
        }
        else {
            //Debug.Log("Hay " + auxwords.Count + " palabras");
            int randomIndex = Random.Range(0, auxwords.Count);
            randomWord = auxwords[randomIndex];
            words.Add(randomWord);
            auxwords.Remove(randomWord);
        }
        if (words.Count >= 35)
            List1 = true;
        if (words.Count<=0)
            List1 = false;
        
        return randomWord;
    }
}
