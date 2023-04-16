using UnityEngine;

public class SettingsLevel : MonoBehaviour
{
    public void Start()
    {
        Application.targetFrameRate = 120;
        QualitySettings.vSyncCount = 1;
    }
}
