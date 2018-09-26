using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

    PointsManager pointsManager;
    LevelManager levelManager;




    [SerializeField]List<Word> words;
    [SerializeField] GameManager game;
    private bool hasActiveWord;
    private Word activeWord=new Word("inicial");

    void Awake()
    {
        levelManager = GameManager.Instance.LevelManager;
        pointsManager = GameManager.Instance.PointsManager;
    }

    public void AddWord(Word word) {
        words.Add(word);
    }
    public void TypeLetter(char Letter) {
     
        Debug.Log("Typeletter activado");
        if (hasActiveWord)
        {
            if (activeWord.getNextLetter() == Letter)
            {
                activeWord.TypedLetter();
                pointsManager.AumentarPuntajeLetra();
            }
            else
                levelManager.RestarEnergiaPorError();
        }
        else {
            foreach (Word word in words) {
                if (word.getNextLetter() == Letter) {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypedLetter();
                    pointsManager.AumentarPuntajeLetra();
                    break;

                }
            }
        }
        if (hasActiveWord && activeWord.WordTyped()) {
            pointsManager.AumentarPuntajePalabra();
            levelManager.ReStartEnergia();
            hasActiveWord = false;
            words.Remove(activeWord);
        }

    }

    public Word getActiveWord() {
        return activeWord;
    }
}
