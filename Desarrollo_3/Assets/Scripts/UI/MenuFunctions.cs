using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuFunctions : MonoBehaviour {

    [SerializeField] GameObject loadingscreen;
    [SerializeField] Slider slider;
    [SerializeField] Text progressText;
    [SerializeField] Text TitleText;
    [SerializeField] Text VersionText;

    [SerializeField] AudioMixer Master;
    [SerializeField] AudioSource Music;

    [SerializeField] LevelManager levelManager;
    [SerializeField] GameManager gameManager;


    void Awake(){
        if (levelManager == null){
            TitleText.text = Application.productName;
            VersionText.text = Application.productName + "_V." + Application.version;
        }
        Music.mute = gameManager.GetMuteStatus();
    }

    public void SetPause(bool pause)
    {
        levelManager.SetPauseStatus(pause);
    }


    public void LoadLevel(int sceneIndex) {
        StartCoroutine(LoadAsynchnously(sceneIndex));
    }

    IEnumerator LoadAsynchnously(int sceneIndex){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingscreen.SetActive(true);

        while (!operation.isDone){
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void SetVolume(float volume){
        Master.SetFloat("MasterVolume", volume);
    }

    public void SetMute(bool mute)
    {
        Music.mute = mute;
        gameManager.SetMuteStatus(mute);
    }

    public void setQuality(int QualityIndex){
        QualitySettings.SetQualityLevel(QualityIndex);
    }

    public void FullscreenChange(bool fullscreen){
        Screen.fullScreen = fullscreen;
    }
}
