using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] int _puntajePorLetra;
    [SerializeField] int _puntajePorPalabra;
    int _puntaje = 0;

    
    
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
    }
    private void Update() {
        VerificarGameOver();
    }
    public void AumentarPuntaje () {
        _puntaje += _puntajePorPalabra;
    }

    public int GetPuntaje() {
        return _puntaje;
    }

    //verifica la condicion de victoria/derrota
    void VerificarGameOver() {

    }
}
