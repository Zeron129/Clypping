
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    int _highscore = 0;
    bool _Mute = false;

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

    public void UpdateHighscore(int score) {
        if (_highscore < score)
            _highscore = score;
    }

    public bool GetMuteStatus() {
        return _Mute;
    }

    public void SetMuteStatus(bool mute) {
        _Mute = mute;
    }
}
