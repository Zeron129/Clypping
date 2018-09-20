
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField] int _puntajePorLetra;
    [SerializeField] int _puntajePorPalabra;
    [SerializeField] int _puntajeParaGanar;
    [SerializeField] float _maxEnergy;
    [SerializeField] float _energyDrainVelocity;
    [SerializeField] float _restaPorError;
    //[SerializeField] string _nombreEscenaVictoria;
    //[SerializeField] string _nombreEscenaDerrota;
    int _puntaje = 0;
    float _energy = 0;
    int _canidadPalabras = 0;
    [SerializeField] Image _currentEnergyBar;
    [SerializeField] Text _ratioText;
    [SerializeField] Text _PalabraText;
    [SerializeField] Text _PuntosText;


    private GameObject gameObject;

    private static GameManager _instance;
    public static GameManager Instance {
        get {
            if(_instance == null) {
                _instance = new GameManager();
                _instance.gameObject = new GameObject("_gameManager");
            }
            return _instance;
        }
    }
    private void Awake() {
        _puntaje = 0;
        _energy = _maxEnergy;
        int _canidadPalabras = 0;
    }
    private void Update() {
       // StateMachine();
        Playng();
        Debug.Log("Energy: " + _energy);
    }
    public void AumentarPuntajePalabra () {
        _canidadPalabras += 1;
        _puntaje += _puntajePorPalabra;
    }
    public void AumentarPuntajeLetra(){
       _puntaje += _puntajePorLetra;
    }
    public void RestarEnergiaPorError()
    {
      _energy -= _restaPorError;
    }

    public int GetPuntaje() {
        return _puntaje;
    }

    //verifica la condicion de victoria/derrota
    int StateMachine() {
        if (_puntaje >= _puntajeParaGanar){
            Win();
            return 2;
        }
         if (_energy <= 0){
            Lose();
            return 0;
         }
         Playng();
         return 1;
    }

    private void Win(){
        // SceneManager.LoadScene(_nombreEscenaVictoria);
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Lose(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Playng(){
        float ratio = _energy / _maxEnergy;
        _currentEnergyBar.rectTransform.localScale = new Vector3(1, ratio, 1);
        _ratioText.text = (ratio * 100).ToString("0") + '%';
        _PalabraText.text = "Palabras: " + _canidadPalabras.ToString();
        _PuntosText.text = "Puntos: " + _puntaje.ToString();

        _energy -= 1f * Time.deltaTime * _energyDrainVelocity;

    }

}
