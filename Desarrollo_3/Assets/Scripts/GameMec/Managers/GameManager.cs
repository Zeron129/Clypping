using UnityEngine;

public class GameManager : MonoBehaviour {

    bool _Mute = false;
    string[] _difficultyIndex = { "Easy", "Normal", "Hard", "Infinite" };
    string _difficultyLevel = "Normal";
    int _lastIndexValue = 1;
    int[] _HighScore = new int[5] { 0, 0, 0, 0, 0 };
    string[] _HighScoreNames = new string[5] { "", "", "", "", "" };

    private GameObject managerGameObject;
    public static GameManager instance = null;

    private void Awake(){
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }



    public void setDifficultyLevel(int dificultyIndex) {
        _difficultyLevel = _difficultyIndex[dificultyIndex];
    }

    public string getDifficultyLevel(){
        return _difficultyLevel;
    }

    public void UploadScore(int score, string name) {
        for (int i = 0; i < 5; i++) {
            if(score > _HighScore[i]) {
                int AuxInt = 0;
                string AuxString = "";
                AuxInt = _HighScore[i];
                AuxString = _HighScoreNames[i];
                _HighScore[i] = score;
                _HighScoreNames[i] = name;
                score = AuxInt;
                name = AuxString;
                for (int e = i + 1; e < 5; e++){
                    AuxInt = _HighScore[e];
                    AuxString = _HighScoreNames[e];
                    _HighScore[e] = score;
                    _HighScoreNames[e] = name;
                    score = AuxInt;
                    name = AuxString;
                }
            }
        }
    }

    public int getHighScoreIntI(int i) {
        return _HighScore[i];
    }
    public string getHighScoreStringI(int i){
        return _HighScoreNames[i];
    }

    public void setLastGetValue(int newIndexValue) {
        _lastIndexValue = newIndexValue;
    }

    public int getLastGetValue() {
        return _lastIndexValue;
    }

    public bool GetMuteStatus() {
        return _Mute;
    }

    public void SetMuteStatus(bool mute) {
        _Mute = mute;
    }

    void Update(){
        Debug.Log("Dificulty: " + getDifficultyLevel());
    }
}