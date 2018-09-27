using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager {
        
    //[SerializeField] string _nombreEscenaVictoria;
    //[SerializeField] string _nombreEscenaDerrota;




   
    private GameObject managerGameObject;

    private static GameManager _instance = null;
    public static GameManager Instance {
        get {
            if(_instance == null) {
                _instance = new GameManager();
                _instance.managerGameObject = new GameObject("_gameManager");
                _instance.managerGameObject.AddComponent<LevelManager>();
                _instance.managerGameObject.AddComponent<SettingsManager>();
                _instance.managerGameObject.AddComponent<PointsManager>();
            }
            return _instance;
        }
    }

    private LevelManager _LevelManager;
    public LevelManager LevelManager {
        get {
            if (_LevelManager == null)
                _LevelManager = managerGameObject.GetComponent<LevelManager>();
            return _LevelManager;
        }
    }

    private SettingsManager _SettingsManager;
    public SettingsManager SettingsManager {
        get {
            if (_SettingsManager == null)
                _SettingsManager = managerGameObject.GetComponent<SettingsManager>();
            return _SettingsManager;
        }
    }

    private PointsManager _PointsManager;
    public PointsManager PointsManager {
        get {
            if (_PointsManager == null)
                _PointsManager = managerGameObject.GetComponent<PointsManager>();
            return _PointsManager;
        }
    }

    private WordManager _WordManager;
    public WordManager WordManager {
        get {
            if (_WordManager == null)
                _WordManager = managerGameObject.GetComponent<WordManager>();
            return _WordManager;
        }
    }
    
}
