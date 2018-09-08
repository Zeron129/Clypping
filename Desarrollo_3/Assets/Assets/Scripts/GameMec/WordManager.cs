using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

    [SerializeField]List<Word> words;
    [SerializeField] SpawnLetter Spawner;
    private bool hasActiveWord;
    private Word activeWord;

    private void Start()
    {
        AddWord();
        AddWord();
        AddWord();
    }

    public void AddWord() {
        Word word = new Word(RandomWordGen.GetRandomWord());
        Spawner.MakeSprite(word.word);
        Debug.Log(word.word);
        words.Add(word);
    }
    public void TypeLetter(char Letter) {
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
}
