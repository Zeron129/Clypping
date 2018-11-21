using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWordGen : MonoBehaviour {
    private static List<string> words = new List<string>() {
        "relato",
        "cita",
        "sable",
        "triple",
        "borla",
        "cruel",
        "cuerdas",
        "modelar",
        "volante",
        "mezquita",
        "vestuario",
        "pua",
        "lugar",
        "lamer",
        "adulto",
        "vida",
        "ramo",
        "bisonte",
        "peca",
        "pecador",
        "alumno",
        "tristeza",
        "moneda",
        "cosa",
        "santo",
        "dentro",
        "china",
        "guante",
        "frasco",
        "fin",
        "film",
        "secar",
        "negro",
        "colgar",
        "hilo"

    };
    private static List<string> auxwords = new List<string>();
    private static string randomWord;
    private static bool List1=true;

   

    public static string GetRandomWord () {
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
