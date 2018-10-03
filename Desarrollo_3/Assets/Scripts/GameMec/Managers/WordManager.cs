using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

    public static WordManager instance = null;

    [SerializeField]List<Word> words;
    [SerializeField] PointsManager pointsManager;
    [SerializeField] LevelManager levelManager;

    private bool hasActiveWord;
    private Word activeWord=new Word("inicial");

    void Awake(){
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
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
                pointsManager.SumarPuntaje();
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
                    pointsManager.SumarPuntaje();
                    break;

                }
            }
        }
        if (hasActiveWord && activeWord.WordTyped()) {
            pointsManager.SumarCantidadDePalabras();
            levelManager.RestablecerEnergia();
            hasActiveWord = false;
            words.Remove(activeWord);
        }

    }

    public Word getActiveWord() {
        return activeWord;
    }
}
