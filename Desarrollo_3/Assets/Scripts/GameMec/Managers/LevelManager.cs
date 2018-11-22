using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance = null;

    [SerializeField] PointsManager pointsManager;
    [SerializeField] GameManager gameManager;


    float _maxEnergy = 100;
    float _energyDrainVelocity = 8;
    float _errorPenalty = 10;
    float _energy = 100;
    bool _pauseIsActive = false;
    string _difficulty = "Normal";
    GameObject _victoryScreen;
    GameObject _defeatScreen;
    GameObject _buttons;
    Image _currentEnergyBar;
    Text _scoreText;
    Text _finalScoreVText;
    Text _finalScoreDText;
    Text _DifficultyVText;
    Text _DifficultyDText;

    void Awake(){
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        _pauseIsActive = false;
    }

    void Start () {
        pointsManager.InitScore();
        RestoreEergy();
    }
	
	void Update () {
        StateMachine();
    }

    public void SubstractEnergyError(){
        _energy -= _errorPenalty;
    }

    public void RestoreEergy(){
        _energy = _maxEnergy;
    }

    public void SetPauseStatus(bool pause) {
        _pauseIsActive = pause;
    }

    public bool GetPauseStatus() {
        return _pauseIsActive;
    }


    //verifica la condicion de victoria/derrota
    void StateMachine(){
        if (pointsManager.ScoreForWinningReached()) Win();
        if (_energy <= 0) Lose();
        MainGameLoop();
    }

    private void Win(){
        _victoryScreen.SetActive(true);
        _buttons.SetActive(false);
        _pauseIsActive = true;
        _finalScoreVText.text = "Puntos: " + pointsManager.GetScore().ToString();
        _DifficultyVText.text = gameManager.getDifficultyLevel();
        if (_difficulty == "Infinite") {
            gameManager.UploadScore(pointsManager.GetScore(), "AAA");
        }
    }

    private void Lose(){
        _defeatScreen.SetActive(true);
        _buttons.SetActive(false);
        _pauseIsActive = true;
        _finalScoreDText.text = "Puntos: " + pointsManager.GetScore().ToString();
        _DifficultyDText.text = "Dificultad: " + gameManager.getDifficultyLevel();
        if (_difficulty == "Infinite"){
            gameManager.UploadScore(pointsManager.GetScore(), "AAA");
        }
    }

    private void MainGameLoop(){
        float ratio = _energy / _maxEnergy;
        _currentEnergyBar.fillAmount = ratio;
        _scoreText.text = pointsManager.GetScore().ToString() + "/" + pointsManager.GetScoreForWinning().ToString();
        if (!_pauseIsActive)
            _energy -= 1f * Time.deltaTime * _energyDrainVelocity;
    }

    public void UpdateLevelManager(float MaxEnergy, float EnergyDrainVelocity, float SubstractforError, string difficulty){
        _maxEnergy = MaxEnergy;
        _energyDrainVelocity = EnergyDrainVelocity;
        _errorPenalty = SubstractforError;
        _difficulty = difficulty;
    }

    public void ActualzarUI(Image CurrentEnergyBar, Text ScoreText, Text FinalScoreVText, Text FinalScoreDText, GameObject VictoryScreen,
                            GameObject DefeatScreen, GameObject Buttons, Text DifficultyVText, Text DifficultyDText)
    {
        _currentEnergyBar = CurrentEnergyBar;
        _scoreText = ScoreText;
        _finalScoreVText = FinalScoreVText;
        _finalScoreDText = FinalScoreDText;
        _victoryScreen = VictoryScreen;
        _defeatScreen = DefeatScreen;
        _buttons = Buttons;
        _DifficultyDText = DifficultyVText;
        _DifficultyVText = DifficultyDText;
    }
}
