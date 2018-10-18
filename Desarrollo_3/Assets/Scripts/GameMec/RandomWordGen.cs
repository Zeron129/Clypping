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
    }
      ;

    private static void Start()
    {/*
        for (int i = 0; i < wordList.Length; i++)
        {
            words.Add(wordList[i]);
        }*/
    }

    public static string GetRandomWord () {
        Debug.Log("Hay " + words.Count + " palabras");
        int randomIndex = Random.Range(0, words.Count);
        string randomWord = words[randomIndex];
        words.Remove(randomWord);
        return randomWord;
    }
}
