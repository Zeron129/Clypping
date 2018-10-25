using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFunctions : MonoBehaviour {

    [SerializeField] GameObject loadingscreen;
    [SerializeField] Slider slider;
    [SerializeField] Text progressText;
    [SerializeField] Text TitleText;
    [SerializeField] Text VersionText;

    void Awake(){
        TitleText.text = Application.productName;
        VersionText.text = Application.productName + "_V." + Application.version;
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
}
