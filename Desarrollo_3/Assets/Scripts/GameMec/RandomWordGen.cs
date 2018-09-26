using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWordGen : MonoBehaviour {
    private static List<string> words = new List<string>() {      "freckle",
            "fresh",
            "charge",
            "steep",
            "avant",
            "cruel",
            "work"
    ,"reputation"
    ,"valid"
    ,"dive"
    ,"branch"
    ,"tax"
    ,"notebook"
    ,"compact"
    ,"flatware"
    ,"cotton"
    ,"rock"
    ,"combination"
    ,"stuff"
    ,"hero"
    ,"pray"
    ,"primary"
    ,"monkey"
    ,"publication"
    ,"repeat"
    ,"climate"
    ,"computer"
    ,"drama"
    ,"literacy"
    ,"film"
    ,"fund"
    ,"notorious"
    ,"architect"
    ,"ignorant"
    ,"trouser"}
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
