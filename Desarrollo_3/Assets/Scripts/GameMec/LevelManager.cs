using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public SettingsManager settingsManager;
    public PointsManager pointsManager;

    float _maxEnergy;
    float _energyDrainVelocity;
    float _restaPorError;

    Image _currentEnergyBar;
    Text _ratioText;
    Text _PalabraText;
    Text _PuntosText;

    float _energy = 0;

    void Awake()
    {
        settingsManager = GameManager.Instance.SettingsManager;
        pointsManager = GameManager.Instance.PointsManager;
    }

    void Start()
    {
        Actualizar();
        ReStartEnergia();
    }

    private void Actualizar()
    {
        int auxA = 0, auxB = 0, auxC = 0;

        settingsManager.ActualizarPuntajes(ref auxA, ref auxB, ref auxC);
        pointsManager.SetSettings(auxA, auxB, auxC);

        settingsManager.ActualizarEnergia(ref _maxEnergy, ref _energyDrainVelocity, ref _restaPorError);
        /*_maxEnergy = 150;
        _energyDrainVelocity = 10;
        _restaPorError = 20;*/

        settingsManager.ActualizarUI(ref _currentEnergyBar, ref _ratioText, ref _PalabraText, ref _PuntosText);
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();
    }

    public void RestarEnergiaPorError()
    {
        _energy -= _restaPorError;
    }

    public void ReStartEnergia()
    {
        _energy = _maxEnergy;
    }

    //verifica la condicion de victoria/derrota
    int StateMachine()
    {
       if (pointsManager.GetPuntajeFaltante() < 0)
        {
            Win();
           return 2;
        }
        if (_energy <= 0)
        {
            Lose();
            return 0;
        }
        Playng();
        return 1;
    }

    private void Win()
    {
        // SceneManager.LoadScene(_nombreEscenaVictoria);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Playng()
    {
        float ratio = _energy / _maxEnergy;
        _currentEnergyBar.rectTransform.localScale = new Vector3(1, ratio, 1);
        _ratioText.text = (ratio * 100).ToString("0") + '%';
        _PalabraText.text = "Palabras: " + pointsManager.GetPalabras().ToString();
        _PuntosText.text = "Puntos: " + pointsManager.GetPuntaje().ToString();

        _energy -= 1f * Time.deltaTime * _energyDrainVelocity;

    }

}
