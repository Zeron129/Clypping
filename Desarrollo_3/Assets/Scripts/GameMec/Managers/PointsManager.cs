using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour {

    public static PointsManager instance = null;

    int _puntajePorLetra;
    int _puntajePorPalabra;
    int _puntajeParaGanar;

    int _puntaje = 0;
    int _canidadPalabras = 0;

    void Awake(){
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }

    public void InicilizarPuntajes(){
        _puntaje = 0;
        _canidadPalabras = 0;
    }

    public void ActualzarPuntajes(int PuntajePorLetra, int PuntajePorPalabra, int PuntajeParaGanar) {
        _puntajePorLetra= PuntajePorLetra;
        _puntajePorPalabra= PuntajePorPalabra;
        _puntajeParaGanar= PuntajeParaGanar;
    }

    public int GetPuntaje() {
        return _puntaje;
    }

    public int GetPuntajeParaGanar(){
        return _puntajeParaGanar;
    }

    public int GetCantidadDePalabras(){
        return _canidadPalabras;
    }

    public void SumarPuntaje(){
        _puntaje += _puntajePorLetra;
    }

    public void SumarCantidadDePalabras(){
        _canidadPalabras += 1;
        _puntaje += _puntajePorPalabra;
    }

    public bool PuntajeParaAanarAlcanzado(){
        if (_puntaje > _puntajeParaGanar) return true;
        else return false;
    }
}
