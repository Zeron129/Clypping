using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionFunctions : MonoBehaviour {

    [SerializeField] GameManager gameManager;

    [SerializeField] AudioMixer Master;
    [SerializeField] AudioSource Music;

    public void SetVolume(float volume) {
        Master.SetFloat("MasterVolume", volume);
    }

    public void SetMute(bool mute) {
        Music.mute = mute;
        gameManager.SetMuteStatus(mute);
    }

    public void setQuality(int QualityIndex) {
        QualitySettings.SetQualityLevel(QualityIndex);
        Debug.Log("Dificulty: " + gameManager.getDifficultyLevel());
    }

    

    public void FullscreenChange(bool fullscreen) {
        Screen.fullScreen=fullscreen;
    }
}
