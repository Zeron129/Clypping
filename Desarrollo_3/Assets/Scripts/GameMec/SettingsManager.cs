using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour {

    [SerializeField] int _puntajePorLetra;
    [SerializeField] int _puntajePorPalabra;
    [SerializeField] int _puntajeParaGanar;

    [SerializeField] float _maxEnergy;
    [SerializeField] float _energyDrainVelocity;
    [SerializeField] float _restaPorError;

    [SerializeField] Image _currentEnergyBar;
    [SerializeField] Text _ratioText;
    [SerializeField] Text _PalabraText;
    [SerializeField] Text _PuntosText;

    public void ActualizarPuntajes(ref int letra, ref int palabra, ref int ganar) {
        letra = _puntajePorLetra;
        palabra = _puntajePorPalabra;
        ganar = _puntajeParaGanar;
    }

    public void ActualizarEnergia(ref float max, ref float drain, ref float error)
    {
        max = _maxEnergy;
        drain = _energyDrainVelocity;
        error = _restaPorError;
    }

    public void ActualizarUI(ref Image bar, ref Text ratio, ref Text palabra, ref Text puntos)
    {
        bar = _currentEnergyBar;
        ratio = _ratioText;
        palabra = _PalabraText;
        puntos = _PuntosText;
    }
}
