using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Word {
    public string word;
    public bool touched;
    private int typeIndex;


    public Word(string _word) {
        word = _word;
        typeIndex = 0;
    }

    public char getNextLetter() {
        return word[typeIndex];
    }

    public char CurrentLetter()
    {
        return word[typeIndex-1];
    }

    public void TypedLetter() {
        typeIndex++;
    }

    public bool WordTyped() {
        bool wordTyped = (typeIndex >= word.Length);
        return wordTyped;
    }

    public void TouchedBy(bool touch) {
        touched = touch;
    }
    
}
