using UnityEngine;

public class GameManager : MonoBehaviour {

    int _highscore = 0;
    bool _Mute = false;
    string[] _difficultyIndex = { "Easy", "Normal", "Hard" , "Infinite"};
    string _difficultyLevel = "Normal";
    int _lastIndexValue = 1;

    private GameObject managerGameObject;

    private static GameManager _instance;
    public static GameManager Instance {
        get {
            if(_instance == null) {
                _instance = new GameManager();
                _instance.managerGameObject = new GameObject("_gameManager");
            }
            return _instance;
        }
    }

    private void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }

    public void setDifficultyLevel(int dificultyIndex) {
        _difficultyLevel = _difficultyIndex[dificultyIndex];
    }

    public string getDifficultyLevel(){
        return _difficultyLevel;
    }

    public void UpdateHighscore(int score) {
        if (_highscore < score)
            _highscore = score;
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
