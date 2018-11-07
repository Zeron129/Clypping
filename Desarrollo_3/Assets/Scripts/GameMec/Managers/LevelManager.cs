using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance = null;

    [SerializeField] PointsManager pointsManager;


    float _maxEnergy = 100;
    float _energyDrainVelocity = 10;
    float _restaPorError = 30;
    float _energy = 100;
    bool _pauseIsActive = false;
    GameObject _victoryScreen;
    GameObject _defeatScreen;
    GameObject _botones;
    Image _currentEnergyBar;
    Text _puntosText;
    Text _puntosfinalVText;
    Text _puntosfinalDText;

    void Awake(){
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        _pauseIsActive = false;
    }

    void Start () {
        pointsManager.InicilizarPuntajes();
        RestablecerEnergia();
    }
	
	void Update () {
        StateMachine();
        //MainGameLoop();
    }

    public void RestarEnergiaPorError(){
        _energy -= _restaPorError;
    }

    public void RestablecerEnergia(){
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
        if (pointsManager.PuntajeParaAanarAlcanzado()) Win();
        if (_energy <= 0) Lose();
        MainGameLoop();
    }

    private void Win(){
        _victoryScreen.SetActive(true);
        _botones.SetActive(false);
        _pauseIsActive = true;
        _puntosfinalVText.text = "Puntos: " + pointsManager.GetPuntaje().ToString();
    }

    private void Lose(){
        _defeatScreen.SetActive(true);
        _botones.SetActive(false);
        _pauseIsActive = true;
        _puntosfinalDText.text = "Puntos: " + pointsManager.GetPuntaje().ToString();
    }

    private void MainGameLoop()
    {
        float ratio = _energy / _maxEnergy;
        _currentEnergyBar.fillAmount = ratio;
        _puntosText.text =  pointsManager.GetPuntaje().ToString();
        if (!_pauseIsActive)
            _energy -= 1f * Time.deltaTime * _energyDrainVelocity;

        Debug.Log("pause: "+_pauseIsActive);

    }

    public void ActualzarLevelManager(float MaxEnergy, float EnergyDrainVelocity, float RestaPorError){
        _maxEnergy = MaxEnergy;
        _energyDrainVelocity = EnergyDrainVelocity;
        _restaPorError = RestaPorError;
    }

    public void ActualzarUI(Image CurrentEnergyBar, Text PuntosText, Text PuntosFinalVText, Text PuntosFinalDText, GameObject VictoryScreen,
                            GameObject DefeatScreen, GameObject Botones){
        _currentEnergyBar = CurrentEnergyBar;
        _puntosText = PuntosText;
        _puntosfinalVText = PuntosFinalVText;
        _puntosfinalDText = PuntosFinalDText;
        _victoryScreen = VictoryScreen;
        _defeatScreen = DefeatScreen;
        _botones = Botones;
    }
}
