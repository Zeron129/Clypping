using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

    public static SettingsManager instance = null;

    [SerializeField] PointsManager pointsManager;
    [SerializeField] LevelManager levelManager;

    //puntajes
    [SerializeField] int _puntajePorLetra;
    [SerializeField] int _puntajePorPalabra;
    [SerializeField] int _puntajeParaGanar;
    //datos levelManager
    [SerializeField] float _maxEnergy;
    [SerializeField] float _energyDrainVelocity;
    [SerializeField] float _restaPorError;
    //Scenes
    //[SerializeField] string _nombreEscenaVictoria;
    //UI
    [SerializeField] Image _currentEnergyBar;
    [SerializeField] Text _ratioText;
    [SerializeField] Text _PalabraText;
    [SerializeField] Text _PuntosText;

    void Awake() {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }

    void Start () {
        pointsManager.ActualzarPuntajes(_puntajePorLetra, _puntajePorPalabra, _puntajeParaGanar);
        levelManager.ActualzarLevelManager(_maxEnergy, _energyDrainVelocity, _restaPorError);
        levelManager.ActualzarUI(_currentEnergyBar, _ratioText, _PalabraText, _PuntosText);
	}
	
	void Update () {
        pointsManager.ActualzarPuntajes(_puntajePorLetra, _puntajePorPalabra, _puntajeParaGanar);
        levelManager.ActualzarLevelManager(_maxEnergy, _energyDrainVelocity, _restaPorError);
    }
}
