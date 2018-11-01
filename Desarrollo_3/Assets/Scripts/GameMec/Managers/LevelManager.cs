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
    Image _currentEnergyBar;
    //Text _ratioText;
    //Text _palabraText;
    Text _puntosText;
    
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
        // SceneManager.LoadScene(_nombreEscenaVictoria);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Lose(){
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
    }

    private void MainGameLoop()
    {
        float ratio = _energy / _maxEnergy;
        //_currentEnergyBar.rectTransform.localScale = new Vector3(1, ratio, 1);
        _currentEnergyBar.fillAmount = ratio;
       // _ratioText.text = (ratio * 100).ToString("0") + '%';
       // _palabraText.text = "Palabras: " + pointsManager.GetCantidadDePalabras().ToString();
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

    public void ActualzarUI(Image CurrentEnergyBar,/* Text RatioText, Text PalabraText,*/ Text PuntosText){
        _currentEnergyBar = CurrentEnergyBar;
       // _ratioText = RatioText;
        //_palabraText = PalabraText;
        _puntosText = PuntosText;
    }
}
