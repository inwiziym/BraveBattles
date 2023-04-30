using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerLoading : MonoBehaviour
{
    public int indexScene;

    public void LoadSceneIndex()
    {
        SceneManager.LoadScene(indexScene);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
