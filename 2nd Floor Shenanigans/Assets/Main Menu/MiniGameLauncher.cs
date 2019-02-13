
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameLauncher : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;

    public void StartMiniGame(int scene)
    {
        //StartCoroutine(LoadAsynchronously(scene));
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    private IEnumerator LoadAsynchronously(int scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;

            yield return null;
        }
    }
}
