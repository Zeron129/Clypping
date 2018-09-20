using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionFunctions : MonoBehaviour {
    [SerializeField] AudioMixer Master;
    public void SetVolume(float volume) {
        Master.SetFloat("MasterVolume", volume);
    }

    public void setQuality(int QualityIndex) {
        QualitySettings.SetQualityLevel(QualityIndex);
    }

    public void FullscreenChange(bool fullscreen) {
        Screen.fullScreen=fullscreen;
    }
}
