using UnityEngine;

public class Pause : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 1;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
    }
}
