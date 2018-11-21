using UnityEngine;

public class PointsManager : MonoBehaviour {

    public static PointsManager instance = null;

    int _LetterScore;
    int _ScoreForVictory;

    int _Score = 0;
    int _WordsAmount = 0;

    void Awake(){
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }

    public void InitScore(){
        _Score = 0;
        _WordsAmount = 0;
    }

    public void UpdateScore(int LetterScore, int ScoreForVictory) {
        _LetterScore= LetterScore;
        _ScoreForVictory= ScoreForVictory;
    }

    public int GetScore() {
        return _Score;
    }

    public int GetScoreForWinning(){
        return _ScoreForVictory;
    }

    public int GetWordsAmount(){
        return _WordsAmount;
    }

    public void AddScore(){
        _Score += _LetterScore;
    }

    public bool ScoreForWinningReached(){
        if (_Score > _ScoreForVictory && _ScoreForVictory >= 0) return true;
        else return false;
    }
}
