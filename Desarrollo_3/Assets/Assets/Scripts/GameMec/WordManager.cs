using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

    [SerializeField]List<Word> words;
    private bool hasActiveWord;
    private Word activeWord=new Word("inicial");

    public void AddWord(Word word) {
        words.Add(word);
    }
    public void TypeLetter(char Letter) {

        Debug.Log("Typeletter activado");
        if (hasActiveWord)
        {
            if (activeWord.getNextLetter() == Letter) {
                activeWord.TypedLetter();
            }
        }
        else {
            foreach (Word word in words) {
                if (word.getNextLetter() == Letter) {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypedLetter();
                    break;

                }
            }
        }
        if (hasActiveWord && activeWord.WordTyped()) {
            hasActiveWord = false;
            words.Remove(activeWord);
        }

    }

    public Word getActiveWord() {
        return activeWord;
    }
}
