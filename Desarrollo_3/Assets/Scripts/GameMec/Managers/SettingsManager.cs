using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

    public static SettingsManager instance = null;

    [SerializeField] PointsManager pointsManager;
    [SerializeField] LevelManager levelManager;
    GameManager gameManager;

    //puntajes
    [SerializeField] int _ScoreLetter;
    [SerializeField] int _WinningScore;
    //datos levelManager
    [SerializeField] float _maxEnergy;
    [SerializeField] float _energyDrainVelocityEasy;
    [SerializeField] float _energyDrainVelocityNormal;
    [SerializeField] float _energyDrainVelocityHard;
    [SerializeField] float _SubstractForErrorEasy;
    [SerializeField] float _SubstractForErrorNormal; 
    [SerializeField] float _SubstractForErrorHard;
    //UI
    [SerializeField] Image _currentEnergyBar;
    [SerializeField] GameObject _victoryScreen;
    [SerializeField] GameObject _defeatScreen;
    [SerializeField] GameObject _buttons;
    [SerializeField] Text ScoreText;
    [SerializeField] Text _FinalScoreVText;
    [SerializeField] Text _FinalScoreDText;
    [SerializeField] Text _DifficultyVText;
    [SerializeField] Text _DifficultyDText;

    void Awake() {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }

    void Start () {
        gameManager = GameObject.FindGameObjectWithTag("gameManager").GetComponent<GameManager>();
        pointsManager.UpdateScore(_ScoreLetter, _WinningScore);
        UpdateLevelManagerData();
        levelManager.ActualzarUI(_currentEnergyBar, ScoreText, _FinalScoreVText, _FinalScoreDText,
            _victoryScreen, _defeatScreen, _buttons, _DifficultyVText, _DifficultyDText);
	}
	
	void Update () {
        pointsManager.UpdateScore(_ScoreLetter, _WinningScore);
        UpdateLevelManagerData();
    }

    void UpdateLevelManagerData() {
        
        switch (gameManager.getDifficultyLevel()){
            case "Easy":
                pointsManager.UpdateScore(_ScoreLetter, _WinningScore);
                levelManager.UpdateLevelManager(_maxEnergy, _energyDrainVelocityEasy, _SubstractForErrorEasy, gameManager.getDifficultyLevel());
                break;
            case "Normal":
                pointsManager.UpdateScore(_ScoreLetter, _WinningScore);
                levelManager.UpdateLevelManager(_maxEnergy, _energyDrainVelocityNormal, _SubstractForErrorNormal, gameManager.getDifficultyLevel());
                break;
            case "Hard":
                pointsManager.UpdateScore(_ScoreLetter, _WinningScore);
                levelManager.UpdateLevelManager(_maxEnergy, _energyDrainVelocityHard, _SubstractForErrorHard, gameManager.getDifficultyLevel());
                break;
            case "Infinite":
                pointsManager.UpdateScore(_ScoreLetter, -1);
                levelManager.UpdateLevelManager(_maxEnergy, _energyDrainVelocityHard, _SubstractForErrorHard, gameManager.getDifficultyLevel());
                break;
        }

    }
}
