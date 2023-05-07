using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerLoading : MonoBehaviour
{
    public int indexScene;
    public int[] randomScene;

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    public void LoadSceneIndex()
    {
        SceneManager.LoadScene(indexScene);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadRandomScene()
    {
        int randomIndex = Random.Range(0, randomScene.Length);
        StartCoroutine(LoadAsync(randomScene[randomIndex]));
        Time.timeScale = 0;
    }

    IEnumerator LoadAsync(int randomIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(randomIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;
            progressText.text = Mathf.RoundToInt(progress * 100) + "%";

            yield return null;
        }
        loadingScreen.SetActive(false);
    }
}
