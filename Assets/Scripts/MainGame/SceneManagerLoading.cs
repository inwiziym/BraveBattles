using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerLoading : MonoBehaviour
{
    public int indexScene;
    public int[] randomScene;
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
        SceneManager.LoadScene(randomScene[randomIndex]);
    }
}
