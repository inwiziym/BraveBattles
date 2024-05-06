using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingLevels : MonoBehaviour
{
    public int IndexScene;

    public void LoadScenee()
    {
        SceneManager.LoadScene(IndexScene);
    }

}
