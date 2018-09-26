using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWordGen : MonoBehaviour {
    private List<string> words;
    private static string[] wordList = {"freckle","fresh","charge","steep","avant","cruel" };

    private void Start()
    {

    }

    public static string GetRandomWord () {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];
        return randomWord;
    }
}
