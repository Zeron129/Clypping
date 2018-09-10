using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

    [SerializeField]List<Word> words;
    //[SerializeField] SpawnLetter Spawner;
    private bool hasActiveWord;
    private Word activeWord;
    private GameObject Roca;

    public void AddWord(Word word,GameObject Roca) {
        words.Add(word);
        Roca = Roca;
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
            Destroy(Roca);
            words.Remove(activeWord);
        }

    }
}
