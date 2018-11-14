using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

    public static SettingsManager instance = null;

    [SerializeField] PointsManager pointsManager;
    [SerializeField] LevelManager levelManager;
    [SerializeField] GameManager gameManager;

    //puntajes
    [SerializeField] int _puntajePorLetra;
    [SerializeField] int _puntajeParaGanar;
    //datos levelManager
    [SerializeField] float _maxEnergy;
    [SerializeField] float _energyDrainVelocityEasy;
    [SerializeField] float _energyDrainVelocityNormal;
    [SerializeField] float _energyDrainVelocityHard;
    [SerializeField] float _restaPorErrorEasy;
    [SerializeField] float _restaPorErrorNormal; 
    [SerializeField] float _restaPorErrorHard;
    //UI
    [SerializeField] Image _currentEnergyBar;
    [SerializeField] GameObject _victoryScreen;
    [SerializeField] GameObject _defeatScreen;
    [SerializeField] GameObject _botones;
    [SerializeField] Text _PuntosText;
    [SerializeField] Text _puntosfinalVText;
    [SerializeField] Text _puntosfinalDText;

    void Awake() {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }

    void Start () {
        pointsManager.ActualzarPuntajes(_puntajePorLetra, _puntajeParaGanar);
        UpdateLevelManagerData();
        levelManager.ActualzarUI(_currentEnergyBar, _PuntosText, _puntosfinalVText, _puntosfinalDText, _victoryScreen, _defeatScreen, _botones);
	}
	
	void Update () {
        pointsManager.ActualzarPuntajes(_puntajePorLetra, _puntajeParaGanar);
        UpdateLevelManagerData();
    }

    void UpdateLevelManagerData() {
        
        switch (gameManager.getDifficultyLevel()){
            case "Easy":
                pointsManager.ActualzarPuntajes(_puntajePorLetra, _puntajeParaGanar);
                levelManager.ActualzarLevelManager(_maxEnergy, _energyDrainVelocityEasy, _restaPorErrorEasy);
                break;
            case "Normal":
                pointsManager.ActualzarPuntajes(_puntajePorLetra, _puntajeParaGanar);
                levelManager.ActualzarLevelManager(_maxEnergy, _energyDrainVelocityNormal, _restaPorErrorNormal);
                break;
            case "Hard":
                pointsManager.ActualzarPuntajes(_puntajePorLetra, _puntajeParaGanar);
                levelManager.ActualzarLevelManager(_maxEnergy, _energyDrainVelocityHard, _restaPorErrorHard);
                break;
            case "Infinite":
                pointsManager.ActualzarPuntajes(_puntajePorLetra, -1);
                levelManager.ActualzarLevelManager(_maxEnergy, _energyDrainVelocityHard, _restaPorErrorHard);
                break;
        }

    }
}
