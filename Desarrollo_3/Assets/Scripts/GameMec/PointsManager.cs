using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour {

    int _puntajePorLetra;
    int _puntajePorPalabra;
    int _puntajeParaGanar;

    int _puntaje = 0;
    int _canidadPalabras = 0;

    public void ReStartPoints () {
        _puntaje = 0;
        _canidadPalabras = 0;
    }

    public void SetSettings(int PPL, int PPP, int PPG) {
         _puntajePorLetra = PPL;
        _puntajePorPalabra = PPP;
        _puntajeParaGanar = PPG;
    }

    public int GetPuntaje()
    {
        return _puntaje;
    }

    public int GetPalabras()
    {
        return _canidadPalabras;
    }

    public int GetPuntajeFaltante()
    {
        int puntajeFaltante;
        puntajeFaltante = _puntajeParaGanar - _puntaje;
        return puntajeFaltante;
    }

    public void AumentarPuntajePalabra()
    {
        _canidadPalabras += 1;
        _puntaje += _puntajePorPalabra;
    }

    public void AumentarPuntajeLetra()
    {
        _puntaje += _puntajePorLetra;
    }

}
